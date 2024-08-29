using Microsoft.AspNetCore.Mvc;
using TimeTracker.Shared.Entities;

namespace TimeTrackerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimeEntryController : ControllerBase
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

    private static List<TimeEntry> _timeEntries = new List<TimeEntry>
    {
        new() { Id = 1, Project = "Time Tracker App", Start = DateTime.Now.AddHours(-2), End = DateTime.Now.AddHours(-1) },
        new() { Id = 2, Project = "Project 2", Start = DateTime.Now.AddHours(-1), End = DateTime.Now }
    };

    [HttpGet]
    public ActionResult<List<TimeEntry>> GetALlTimeEntries()
    {
        return Ok(_timeEntries);
    }
}