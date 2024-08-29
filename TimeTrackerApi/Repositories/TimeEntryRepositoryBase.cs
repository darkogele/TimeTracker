using TimeTracker.Shared.Entities;

namespace TimeTrackerApi.Repositories;

public class TimeEntryRepository : ITimeEntryRepository
{
    private List<TimeEntry> _timeEntries = new()
    {
        new() { Id = 1, Project = "Time Tracker App", Start = DateTime.Now.AddHours(-2), End = DateTime.Now.AddHours(-1) },
        new() { Id = 2, Project = "Project 2", Start = DateTime.Now.AddHours(-1), End = DateTime.Now }
    };

    public TimeEntryRepository()
    {
        _timeEntries.Add(new TimeEntry { Id = 1, Project = "Project 1", Start = DateTime.Now, End = DateTime.Now.AddHours(1) });
        _timeEntries.Add(new TimeEntry { Id = 2, Project = "Project 2", Start = DateTime.Now, End = DateTime.Now.AddHours(2) });
        _timeEntries.Add(new TimeEntry { Id = 3, Project = "Project 3", Start = DateTime.Now, End = DateTime.Now.AddHours(3) });
    }

    public List<TimeEntry> GetAllTimeEntries()
    {
        return _timeEntries;
    }

    public TimeEntry? GetTimeEntry(int id)
    {
        return _timeEntries.FirstOrDefault(x => x.Id == id);
    }

    public List<TimeEntry> AddTimeEntry(TimeEntry timeEntry)
    {
        timeEntry.Id = _timeEntries.Max(x => x.Id) + 1;
        _timeEntries.Add(timeEntry);
        return _timeEntries;
    }

    public List<TimeEntry>? UpdateTimeEntry(int id, TimeEntry timeEntry)
    {
        var existingEntry = _timeEntries.FirstOrDefault(x => x.Id == id);
        if (existingEntry == null)
        {
            return null;
        }

        existingEntry.Project = timeEntry.Project;
        existingEntry.Start = timeEntry.Start;
        existingEntry.End = timeEntry.End;
        existingEntry.UpdatedDate = DateTime.Now;
        return _timeEntries;
    }

    public List<TimeEntry>? DeleteTimeEntry(int id)
    {
        var existingEntry = _timeEntries.FirstOrDefault(x => x.Id == id);
        if (existingEntry == null)
        {
            return null;
        }

        _timeEntries.Remove(existingEntry);
        return _timeEntries;
    }
}