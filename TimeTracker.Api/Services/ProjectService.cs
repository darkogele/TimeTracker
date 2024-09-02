using Mapster;
using TimeTracker.Shared.Models.Project;

namespace TimeTrackerApi.Services;

public class ProjectService(IProjectRepository projectRepository) : IProjectService
{
    public async Task<List<ProjectResponse>> CreateProjectEntry(ProjectCreateRequest projectCreateRequest)
    {
        var newEntry = projectCreateRequest.Adapt<Project>();
        newEntry.ProjectDetails = projectCreateRequest.Adapt<ProjectDetails>();

        var result = await projectRepository.CreateProjectEntry(newEntry);

        return result.Adapt<List<ProjectResponse>>();
    }

    public async Task<List<ProjectResponse>?> DeleteProject(int id)
    {
        var result = await projectRepository.DeleteProject(id);
        return result.Adapt<List<ProjectResponse>>();
    }

    public async Task<List<ProjectResponse>> GetAllProjects()
    {
        var result = await projectRepository.GetAllProjects();

        return result.Adapt<List<ProjectResponse>>();
    }

    public async Task<ProjectResponse?> GetProjectEntry(int id)
    {
        var result = await projectRepository.GetProjectEntry(id);
        if (result == null) return null;
        return result.Adapt<ProjectResponse>();
    }

    public async Task<List<ProjectResponse>?> UpdateProjectEntry(int id, ProjectUpdateRequest updateRequest)
    {
        try
        {
            var updatedEntry = updateRequest.Adapt<Project>();
            updatedEntry.ProjectDetails = updateRequest.Adapt<ProjectDetails>();
            var result = await projectRepository.UpdateProjectEntry(id, updatedEntry);

            return result.Adapt<List<ProjectResponse>>();
        }
        catch (EntityNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
}