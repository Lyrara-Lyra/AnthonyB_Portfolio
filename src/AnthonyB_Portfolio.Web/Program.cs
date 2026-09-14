using System.Globalization;
using AnthonyB_Portfolio.Web.Components;
using AnthonyB_Portfolio.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add HttpClient for calling the Api
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5016")
});

// Add Blazor services
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add other services
builder.Services.AddScoped<ThemeService>();

// Locale
var frCulture = new CultureInfo("fr-FR");
CultureInfo.DefaultThreadCurrentCulture = frCulture;
CultureInfo.DefaultThreadCurrentUICulture = frCulture;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
