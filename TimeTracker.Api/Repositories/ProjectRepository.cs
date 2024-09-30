using TimeTrackerApi.Data;

namespace TimeTrackerApi.Repositories;

public class ProjectRepository(DataContext dataContext, IUserContextService userContext) : IProjectRepository
{
    public async Task<List<Project>> GetAllProjects()
    {
        return await dataContext.Projects
            .Where(d => d.IsDeleted == false && d.Users.Any(u => u.Id == userContext.GetUserId()))
            .Include(x => x.ProjectDetails)
            .ToListAsync();
    }

    public async Task<Project?> GetProjectEntry(int id)
    {
        return await dataContext.Projects
            .Where(d => d.IsDeleted == false && d.Users.Any(u => u.Id == userContext.GetUserId()))
            .Include(x => x.ProjectDetails)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Project>> CreateProjectEntry(Project project)
    {
        var user = await userContext.GetUser();

        project.Users.Add(user);

        dataContext.Projects.Add(project);
        await dataContext.SaveChangesAsync();

        return await GetAllProjects();
    }

    public async Task<List<Project>> UpdateProjectEntry(int id, Project project)
    {
        var existingProject = await dataContext.Projects
                                  .Include(x => x.ProjectDetails)
                                  .FirstOrDefaultAsync(x => x.Id == id &&
                                    x.Users.Any(u => u.Id == userContext.GetUserId()))
                              ?? throw new EntityNotFoundException($"Project with Id {id} not found");

        if (project.ProjectDetails != null && existingProject.ProjectDetails != null)
        {
            existingProject.ProjectDetails.Description = project.ProjectDetails.Description;
            existingProject.ProjectDetails.StartDate = project.ProjectDetails.StartDate;
            existingProject.ProjectDetails.EndDate = project.ProjectDetails.EndDate;
        }
        else if (project.ProjectDetails != null && existingProject.ProjectDetails == null)
        {
            existingProject.ProjectDetails = new ProjectDetails
            {
                Description = project.ProjectDetails.Description,
                StartDate = project.ProjectDetails.StartDate,
                EndDate = project.ProjectDetails.EndDate,
                Project = project
            };
        }

        existingProject.Name = project.Name;
        existingProject.UpdatedDate = DateTime.Now;

        await dataContext.SaveChangesAsync();

        return await GetAllProjects();
    }

    public async Task<List<Project>> DeleteProject(int id)
    {
        var existingEntry = await dataContext.Projects
            .FirstOrDefaultAsync(
                x => x.Id == id && 
                x.IsDeleted == false &&
                x.Users.Any(u => u.Id == userContext.GetUserId()))
                            ?? throw new EntityNotFoundException($"Project with Id {id} not found");

        //soft delete
        existingEntry.IsDeleted = true;
        existingEntry.DeletedDate = DateTime.Now;

        await dataContext.SaveChangesAsync();

        return await GetAllProjects();
    }
}