// Determine the active theme
const savedTheme = localStorage.getItem("selected-theme");
const systemPrefersDark = window.matchMedia("(prefers-color-scheme: dark)").matches;

// Use the saved theme, or default to the OS preference
const activeTheme = savedTheme ? savedTheme : (systemPrefersDark ? "dark" : "light");

// Apply the theme attribute to the HTML document
document.documentElement.setAttribute("data-theme", activeTheme);

// Update the favicon based on the active theme
const faviconElement = document.getElementById("dynamic-favicon");
if (faviconElement) {
    faviconElement.href = `/favicon-${activeTheme}.png`;
}