using AnthonyB_Portfolio.Core.Entities;

namespace AnthonyB_Portfolio.Web.Services
{
    public class PreloadService
    {
        public readonly HttpClient _http;
        private Task<List<Project>?> _projectsTask = Task.FromResult<List<Project>?>(null);
        private Task<List<Experience>?> _experiencesTask = Task.FromResult<List<Experience>?>(null);
        private Task<List<Category>?> _categoriesTask = Task.FromResult<List<Category>?>(null);


        public PreloadService(HttpClient http)
        {
            _http = http;
        }

        public void InitializePreload()
        {
            // Start preloading data
            GetProjectsAsync();
            GetExperiencesAsync();
            GetCategoriesAsync();
        }

        public Task<List<Project>?> GetProjectsAsync()
        {
            // The fetch is completed with no result (default)
            if (_projectsTask.IsCompleted && _projectsTask.Result == null)
            {
                // Fetch the projects again
                _projectsTask = FetchProjectsAsync();
            }

            // Return the projects or the fetching task
            return _projectsTask;
        }

        private async Task<List<Project>?> FetchProjectsAsync()
        {
            // Fetch the projects from the API
            var fetchedProjects = await _http.GetFromJsonAsync<List<Project>>("projects");

            // Projects are found
            if (fetchedProjects != null)
            {
                // Sort the projects
                foreach (Project p in fetchedProjects)
                {
                    p.Skills = p.Skills.OrderBy(s => s.DisplayOrder).ToList();
                    p.Details = p.Details.OrderBy(d => d.DisplayOrder).ToList();
                    p.Screenshots = p.Screenshots.OrderBy(s => s.DisplayOrder).ToList();
                }
            }

            // Return the sorted projects
            return fetchedProjects;
        }

        public Task<List<Experience>?> GetExperiencesAsync()
        {
            // The fetch is completed with no result (default)
            if (_experiencesTask.IsCompleted && _experiencesTask.Result == null)
            {
                // Fetch the experiences again
                _experiencesTask = FetchExperiencesAsync();
            }

            // Return the experiences or the fetching task
            return _experiencesTask;
        }


        private async Task<List<Experience>?> FetchExperiencesAsync()
        {
            // Fetch the experiences from the API
            var fetchedExperiences = await _http.GetFromJsonAsync<List<Experience>>("experiences");

            // Experiences are found
            if (fetchedExperiences != null)
            {
                // Save and sort the experiences
                fetchedExperiences = fetchedExperiences.OrderByDescending(e => e.StartDate).ToList();

                foreach (Experience e in fetchedExperiences)
                {
                    e.Responsibilities = e.Responsibilities.OrderBy(r => r.DisplayOrder).ToList();
                    e.Skills = e.Skills.OrderBy(s => s.DisplayOrder).ToList();
                }
            }

            // Return the sorted experiences
            return fetchedExperiences;
        }

        public Task<List<Category>?> GetCategoriesAsync()
        {
            // The fetch is completed with no result (default)
            if (_categoriesTask.IsCompleted && _categoriesTask.Result == null)
            {
                // Fetch the categories again
                _categoriesTask = FetchCategoriesAsync();
            }

            // Return the categories or the fetching task
            return _categoriesTask;
        }

        private async Task<List<Category>?> FetchCategoriesAsync()
        {
            // Fetch the categories from the API
            var fetchedCategories = await _http.GetFromJsonAsync<List<Category>>("cv-skills");

            // Categories are found
            if (fetchedCategories != null)
            {
                // Sort the categories and their skills by display order
                foreach (Category c in fetchedCategories)
                {
                    c.Skills = c.Skills.OrderBy(s => s.DisplayOrder).ToList();
                }
                fetchedCategories = fetchedCategories.OrderBy(c => c.DisplayOrder).ToList();
            }

            // Return the sorted categories
            return fetchedCategories;
        }
    }
}