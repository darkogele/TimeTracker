using System.Net.Http.Json;
using TimeTracker.Shared.Models.Project;

namespace TimeTracker.Client.Services;

public class ProjectService(HttpClient http) : IProjectService
{
    public List<ProjectResponse> Projects { get; set; } = new();

    public event Action? OnChange;

    public async Task CreateProject(ProjectRequest project)
    {
        await http.PostAsJsonAsync("api/project", project);
    }

    public async Task DeleteProject(int id)
    {
        await http.DeleteAsync($"api/project/{id}");
    }

    public async Task<ProjectResponse> GetProjectById(int id)
    {
        return await http.GetFromJsonAsync<ProjectResponse>($"api/project/{id}");
    }

    public async Task LoadProjects()
    {
        var result = await http.GetFromJsonAsync<List<ProjectResponse>>("api/project");
        if (result != null)
        {
            Projects = result;
            OnChange?.Invoke();
        }
    }

    public async Task UpdateProject(int id, ProjectRequest project)
    {
        await http.PutAsJsonAsync($"api/project/{id}", project);
    }
}