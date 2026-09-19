using Microsoft.JSInterop;

namespace AnthonyB_Portfolio.Web.Services
{
    // Handles toggling between themes
    public class ThemeService
    {
        private const string _storageLabel = "selected-theme"; 
        private readonly IJSRuntime _jsRunTime;
        private bool _isTransitioning = false;
        public string CurrentTheme { get; private set; } = "";
        public event Action? OnChange;

        public ThemeService(IJSRuntime jsRuntime)
        {
            _jsRunTime = jsRuntime;
        }

        // Retrives the saved theme upon load
        public async Task InitializeAsync()
        {
            // Get the saved theme from local storage
            var savedTheme = await _jsRunTime.InvokeAsync<string>("localStorage.getItem", _storageLabel);

            // There is a theme in local storage
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
            // Abort if a transition is currently in progress
            if (_isTransitioning) return;

            // Transition between themes
            try
            {
                // Toggle the currently used theme
                _isTransitioning = true;
                CurrentTheme = CurrentTheme == "dark" ? "light" : "dark";

                // Save the new theme in local storage
                await _jsRunTime.InvokeVoidAsync("localStorage.setItem", _storageLabel, CurrentTheme);
                NotifyStateChanged();

                // Add a temporary class to transition between themes
                await _jsRunTime.InvokeVoidAsync("document.documentElement.classList.add", "theme-change");

                // Theme transition time
                await Task.Delay(600);
            }
            // Always remove the lock at the end
            finally
            {
                // Remove the temporary class
                await _jsRunTime.InvokeVoidAsync("document.documentElement.classList.remove", "theme-change");

                // Transition is over
                _isTransitioning = false;
            }
        }

        // Updates the subscribers on state change
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}