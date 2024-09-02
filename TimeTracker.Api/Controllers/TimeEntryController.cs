using Microsoft.AspNetCore.Mvc;

namespace TimeTrackerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimeEntryController(ITimeEntryService timeEntryService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<TimeEntryResponse>>> GetALlTimeEntries()
    {
        return Ok(await timeEntryService.GetAllTimeEntries());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TimeEntryResponse>> GetTimeEntry(int id)
    {
        var result = await timeEntryService.GetTimeEntry(id);
        if (result == null)
        {
            return NotFound("Time entry with given Id was not found");
        }

        return Ok(result);
    }

    [HttpGet("project/{projectId:int}")]
    public async Task<ActionResult<List<TimeEntryResponse>>> GetTimeEntryByProject(int projectId)
    {
        return Ok(await timeEntryService.GetTimeEntriesByProject(projectId));
    }

    [HttpPost]
    public async Task<ActionResult<List<TimeEntryResponse>>> CreateimeEntry(TimeEntryCreateRequest timeEntry)
    {
        return Ok(await timeEntryService.AddTimeEntry(timeEntry));
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<List<TimeEntryResponse>>> UpdateTimeEntry(int id, TimeEntryUpdateRequest timeEntry)
    {
        var result = await timeEntryService.UpdateTimeEntry(id, timeEntry);
        if (result == null)
        {
            return NotFound("Time entry with given Id was not found");
        }

        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<List<TimeEntryResponse>>> DeleteTimeEntry(int id)
    {
        var result = await timeEntryService.DeleteTimeEntry(id);
        if (result == null)
        {
            return NotFound("Time entry with given Id was not found");
        }

        return Ok(result);
    }
}