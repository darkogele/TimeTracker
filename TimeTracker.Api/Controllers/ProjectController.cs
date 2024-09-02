using Microsoft.AspNetCore.Mvc;
using TimeTracker.Shared.Models.Project;

namespace TimeTrackerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController(IProjectService projectService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ProjectResponse>>> GetAllProjects()
    {
        return Ok(await projectService.GetAllProjects());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProjectResponse>> GetProjectEntry(int id)
    {
        var result = await projectService.GetProjectEntry(id);
        if (result == null)
        {
            return NotFound("Time entry with given Id was not found");
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<List<ProjectResponse>>> CreateimeEntry(ProjectCreateRequest request)
    {
        return Ok(await projectService.CreateProjectEntry(request));
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<List<ProjectResponse>>> UpdateTimeEntry(int id, ProjectUpdateRequest request)
    {
        var result = await projectService.UpdateProjectEntry(id, request);
        if (result == null)
        {
            return NotFound("Time entry with given Id was not found");
        }

        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<List<ProjectResponse>>> DeleteTimeEntry(int id)
    {
        var result = await projectService.DeleteProject(id);
        if (result == null)
        {
            return NotFound("Time entry with given Id was not found");
        }

        return Ok(result);
    }
}