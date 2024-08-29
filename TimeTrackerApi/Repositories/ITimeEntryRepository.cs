using TimeTracker.Shared.Entities;
using TimeTracker.Shared.Models.TimeEntry;

namespace TimeTrackerApi.Repositories;

public interface ITimeEntryRepository
{
    List<TimeEntry> GetAllTimeEntries();
    TimeEntry? GetTimeEntry(int id);
    List<TimeEntry> AddTimeEntry(TimeEntry timeEntry);
    List<TimeEntry>? UpdateTimeEntry(int id, TimeEntry timeEntry);
    List<TimeEntry>? DeleteTimeEntry(int id);
}