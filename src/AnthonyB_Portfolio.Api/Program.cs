using AnthonyB_Portfolio.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// =============================================
// SERVICE REGISTRATION
// =============================================

// Use OpenAPI for the API endpoints
builder.Services.AddOpenApi();

// Register the Entity Framework DbContext with SQLite
builder.Services.AddDbContext<PortfolioDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Configure Cross-Origin Resource Sharing (CORS)
builder.Services.AddCors(options =>
{
    // Production: Restricts API to the specified domain
    options.AddPolicy("ProductionCors", corsBuilder => 
        corsBuilder.WithOrigins("https://anthony-b.fr")
                   .AllowAnyHeader()
                   .AllowAnyMethod());
                   
    // Development: Allows requests from any origin
    options.AddPolicy("DevelopmentCors", corsBuilder => 
        corsBuilder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod());
});

var app = builder.Build();

// =============================================
// MIDDLEWARE PIPELINE
// =============================================

// Apply the appropriate CORS policy based on the environment
if (app.Environment.IsDevelopment())
{
    app.UseCors("DevelopmentCors");
    
    // Expose the OpenAPI endpoint only in development
    app.MapOpenApi(); 
}
else
{
    app.UseCors("ProductionCors");
}

// Redirect incoming HTTP requests to secure HTTPS 
app.UseHttpsRedirection();

// Seed the database during startup 
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    
    try
    {
        // Retrieve the database context
        var context = services.GetRequiredService<PortfolioDbContext>();

        // Apply pending migrations to create/update database
        context.Database.Migrate();

        // Seed the database
        SeedData.Initialize(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the database.");
    }
}

// =============================================
// API ENDPOINTS
// =============================================

app.MapGet("/api/categories", async (PortfolioDbContext context) =>
{
    return await context.Categories
        .OrderBy(c => c.DisplayOrder)
        .ToListAsync();
});

app.MapGet("/api/skills", async (PortfolioDbContext context) =>
{
    return await context.Skills
        .OrderBy(s => s.Category!.DisplayOrder)
        .Include(s => s.Category)
        .ToListAsync();
});

app.MapGet("/api/projects", async (PortfolioDbContext context) =>
{
    return await context.Projects
        .Where(p => p.IsVisible)
        .OrderBy(p => p.Id)
        .Include(p => p.Skills.OrderBy(ps => ps.DisplayOrder))
        .ThenInclude(ps => ps.Skill)
        .Include(p => p.Details.OrderBy(d => d.DisplayOrder))
        .Include(p => p.Screenshots.OrderBy(s => s.DisplayOrder))
        .ToListAsync();
});

app.MapGet("/api/experiences", async (PortfolioDbContext context) =>
{
    return await context.Experiences
        .Where(e => e.IsVisible)
        .OrderByDescending(e => e.StartTime)
        .Include(e => e.Responsibilities.OrderBy(r => r.DisplayOrder))
        .Include(e => e.Skills.OrderBy(es => es.DisplayOrder))
        .ThenInclude(es => es.Skill)
        .ToListAsync();
});

app.Run();