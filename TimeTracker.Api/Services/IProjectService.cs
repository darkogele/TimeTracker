using TimeTracker.Shared.Models.Project;

namespace TimeTrackerApi.Services;

public interface IProjectService
{
    Task<List<ProjectResponse>> GetAllProjects();
    Task<ProjectResponse?> GetProjectEntry(int id);
    Task<List<ProjectResponse>> CreateProjectEntry(ProjectCreateRequest timeEntry);
    Task<List<ProjectResponse>?> UpdateProjectEntry(int id, ProjectUpdateRequest timeEntry);
    Task<List<ProjectResponse>?> DeleteProject(int id);
}