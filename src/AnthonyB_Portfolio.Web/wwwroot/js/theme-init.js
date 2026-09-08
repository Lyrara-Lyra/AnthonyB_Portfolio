// Read local storage or use light as default
const savedTheme = localStorage.getItem('selected-theme') || 'light';

// Display the saved theme in the HTML
document.documentElement.setAttribute('data-theme', savedTheme);