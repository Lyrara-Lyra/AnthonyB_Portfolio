using System.Globalization;
using AnthonyB_Portfolio.Web.Components;
using AnthonyB_Portfolio.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// =============================================
// SERVICE REGISTRATION
// =============================================

// Register the HttpClient use to communicate with the API 
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"] ?? "http://localhost:5016")
});

// Register necessary services for Blazor components and interactive server-side rendering
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register additional services
builder.Services
    .AddScoped<ThemeService>()
    .AddScoped<PreloadService>();

var app = builder.Build();

// =============================================
// MIDDLEWARE PIPELINE
// =============================================

// Set application culture to French (fr-FR) for formatting
var frCulture = new CultureInfo("fr-FR");
CultureInfo.DefaultThreadCurrentCulture = frCulture;
CultureInfo.DefaultThreadCurrentUICulture = frCulture;

// When in production
if (!app.Environment.IsDevelopment())
{
    // Redirect unhandled exceptions to the "/Error" route
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    
    // Instruct browsers to only access the site via HTTPS
    app.UseHsts();
}

// Redicrect specific HTTP status codes to the "/not-found" route
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

// Redirects incoming HTTP requests to secure HTTPS
app.UseHttpsRedirection();

// Adds Antiforgery middleware to prevent Cross-Site Request Forgery (CSRF) attacks
app.UseAntiforgery();

// Enables serving static files (CSS, JS, images) from the wwwroot directory
app.MapStaticAssets();

// Maps the Blazor SignalR hub and initial Razor components
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();