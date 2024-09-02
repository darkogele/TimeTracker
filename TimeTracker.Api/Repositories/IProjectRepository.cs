namespace TimeTrackerApi.Repositories;

public interface IProjectRepository
{
    Task<List<Project>> GetAllProjects();
    Task<Project?> GetProjectEntry(int id);
    Task<List<Project>> CreateProjectEntry(Project project);
    Task<List<Project>> UpdateProjectEntry(int id, Project project);
    Task<List<Project>> DeleteProject(int id);
}