using Microsoft.AspNetCore.Mvc;
using TimeTracker.Shared.Entities;
using TimeTracker.Shared.Models.TimeEntry;
using TimeTrackerApi.Repositories;
using TimeTrackerApi.Services;

namespace TimeTrackerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimeEntryController(ITimeEntryService timeEntryService) : ControllerBase
{
    //private readonly ITimeEntryRepository _timeEntryRepository;

    //public TimeEntryController(ITimeEntryRepository timeEntryRepository)
    //{
    //    _timeEntryRepository = timeEntryRepository;
    //}

    //[HttpGet]
    //public async Task<ActionResult<IEnumerable<TimeEntry>>> Get()
    //{
    //    return Ok(await _timeEntryRepository.GetTimeEntries());
    //}

    //[HttpGet("{id}")]
    //public async Task<ActionResult<TimeEntry>> Get(int id)
    //{
    //    var timeEntry = await _timeEntryRepository.GetTimeEntry(id);
    //    if (timeEntry == null)
    //    {
    //        return NotFound();
    //    }

    //    return Ok(timeEntry);
    //}

    //[HttpPost]
    //public async Task<ActionResult<TimeEntry>> Post(TimeEntry timeEntry)
    //{
    //    await _timeEntryRepository.AddTimeEntry(timeEntry);
    //    return CreatedAtAction(nameof(Get), new { id = timeEntry.Id }, timeEntry);
    //}

    //[HttpPut("{id}")]
    //public async Task<IActionResult> Put(int id, TimeEntry timeEntry)
    //{
    //    if (id != timeEntry.Id)
    //    {
    //        return BadRequest();
    //    }

    //    await _timeEntryRepository.UpdateTimeEntry(timeEntry);
    //    return NoContent();
    //}

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> Delete(int id)
    //{
    //    var timeEntry = await _timeEntryRepository.GetTimeEntry(id);
    //    if (timeEntry == null)
    //    {
    //        return NotFound();
    //    }

    //    await _timeEntryRepository.DeleteTimeEntry(id);
    //    return NoContent();
    //}



    [HttpGet]
    public ActionResult<List<TimeEntryResponse>> GetALlTimeEntries()
    {
        return Ok(timeEntryService.GetAllTimeEntries());
    }

    [HttpGet("{id}")]
    public ActionResult<TimeEntryResponse> GetTimeEntry(int id)
    {
        var result = timeEntryService.GetTimeEntry(id);
        if (result == null)
        {
            return NotFound("Time entry with given Id was not found");
        }
        return Ok(result);
    }

    [HttpPost]
    public ActionResult<List<TimeEntryResponse>> CreateimeEntry(TimeEntryCreateRequest timeEntry)
    {
        return Ok(timeEntryService.AddTimeEntry(timeEntry));
    }

    [HttpPut("{id}")]
    public ActionResult<List<TimeEntryResponse>> UpdateTimeEntry(int id, TimeEntryUpdateRequest timeEntry)
    {
        var result = timeEntryService.UpdateTimeEntry(id, timeEntry);
        if (result == null)
        {
            return NotFound("Time entry with given Id was not found");
        }
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public ActionResult<List<TimeEntryResponse>> DeleteTimeEntry(int id)
    {
        var result = timeEntryService.DeleteTimeEntry(id);
        if (result == null)
        {
            return NotFound("Time entry with given Id was not found");
        }
        return Ok(result);
    }
}