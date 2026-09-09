using Microsoft.JSInterop;

namespace AnthonyB_Portfolio.Web.Services
{
    // Handles toggling between themes
    public class ThemeService
    {
        private const string StorageLabel = "selected-theme"; 
        private readonly IJSRuntime _jsRunTime;
        public string CurrentTheme { get; private set; } = "";
        public event Action? OnChange;

        public ThemeService(IJSRuntime jsRuntime)
        {
            _jsRunTime = jsRuntime;
        }

        // Retrives the saved theme upon load
        public async Task InitializeAsync()
        {
            // Get the saved theme from LocalStorage
            var savedTheme = await _jsRunTime.InvokeAsync<string>("localStorage.getItem", StorageLabel);

            if (!string.IsNullOrEmpty(savedTheme))
            {
                // Update the displayed theme
                CurrentTheme = savedTheme;
                NotifyStateChanged();

                // Remove the temporary theme used for loading
                await _jsRunTime.InvokeAsync<string>("document.documentElement.removeAttribute", "data-theme");
            }
        }

        // Toggles the theme and saves it to local storage
        public async Task ToggleThemeAsync()
        {
            CurrentTheme = CurrentTheme == "dark" ? "light" : "dark";
            
            await _jsRunTime.InvokeVoidAsync("localStorage.setItem", StorageLabel, CurrentTheme);
            NotifyStateChanged();
        }

        // Updates the subscribers on state change
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}