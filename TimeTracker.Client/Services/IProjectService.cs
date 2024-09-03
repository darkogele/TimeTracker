using TimeTracker.Shared.Models.Project;

namespace TimeTracker.Client.Services;

public interface IProjectService
{
    event Action? OnChange;
    List<ProjectResponse> Projects { get; set; }

    Task LoadProjects();
    Task<ProjectResponse> GetProjectById(int id);
    Task CreateProject(ProjectRequest project);
    Task UpdateProject(int id, ProjectRequest project);
    Task DeleteProject(int id);
}