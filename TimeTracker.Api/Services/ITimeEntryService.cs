namespace TimeTrackerApi.Services;

public interface ITimeEntryService
{
    Task<List<TimeEntryResponse>> GetAllTimeEntries();
    Task<TimeEntryResponse?> GetTimeEntry(int id);
    Task<List<TimeEntryResponse>> AddTimeEntry(TimeEntryCreateRequest timeEntry);
    Task<List<TimeEntryResponse>?> UpdateTimeEntry(int id, TimeEntryUpdateRequest timeEntry);
    Task<List<TimeEntryResponse>?> DeleteTimeEntry(int id);
    Task<List<TimeEntryResponse>> GetTimeEntriesByProject(int projectId);
}