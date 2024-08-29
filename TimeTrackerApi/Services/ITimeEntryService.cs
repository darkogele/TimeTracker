using TimeTracker.Shared.Models.TimeEntry;

namespace TimeTrackerApi.Services;

public interface ITimeEntryService
{
    List<TimeEntryResponse> GetAllTimeEntries();
    TimeEntryResponse? GetTimeEntry(int id);
    List<TimeEntryResponse> AddTimeEntry(TimeEntryCreateRequest timeEntry);
    List<TimeEntryResponse>? UpdateTimeEntry(int id, TimeEntryUpdateRequest timeEntry);
    List<TimeEntryResponse>? DeleteTimeEntry(int id);
}