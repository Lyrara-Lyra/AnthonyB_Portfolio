using AnthonyB_Portfolio.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Register DbContext with SQLite
builder.Services.AddDbContext<PortfolioDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        SeedData.Initialize(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the database.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// =============================================
// API ENDPOINTS
// =============================================

app.MapGet("/api/categories", async (PortfolioDbContext context) =>
{
    return await context.Categories
        .OrderBy(c => c.DisplayOrder)
        .Include(c => c.Skills.OrderBy(s => s.DisplayOrder))
        .ToListAsync();
});

app.MapGet("/api/skills", async (PortfolioDbContext context) =>
{
    return await context.Skills
        .OrderBy(s => s.Category!.DisplayOrder)
        .ThenBy(s => s.DisplayOrder)
        .Include(s => s.Category)
        .ToListAsync();
});

app.MapGet("/api/projects", async (PortfolioDbContext context) =>
{
    return await context.Projects
        .OrderBy(p => p.DisplayOrder)
        .Include(p => p.Skills.OrderBy(s => s.DisplayOrder))
        .Include(p => p.Details.OrderBy(d => d.DisplayOrder))
        .ToListAsync();
});

app.MapGet("/api/experiences", async (PortfolioDbContext context) =>
{
    return await context.Experiences
        .OrderByDescending(e => e.StartTime)
        .Include(e => e.Responsibilities.OrderBy(r => r.DisplayOrder))
        .Include(e => e.Skills.OrderBy(s => s.DisplayOrder))
        .ToListAsync();
});

app.Run();