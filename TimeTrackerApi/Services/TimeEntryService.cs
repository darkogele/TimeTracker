using Mapster;
using TimeTracker.Shared.Entities;
using TimeTracker.Shared.Models.TimeEntry;
using TimeTrackerApi.Repositories;

namespace TimeTrackerApi.Services;

public class TimeEntryService(ITimeEntryRepository timeEntryRepository)
    : ITimeEntryService
{
    public List<TimeEntryResponse> AddTimeEntry(TimeEntryCreateRequest timeEntry)
    {
        var newEntry = timeEntry.Adapt<TimeEntry>();

        var result = timeEntryRepository.AddTimeEntry(newEntry);

        return result.Adapt<List<TimeEntryResponse>>();
    }

    public List<TimeEntryResponse>? DeleteTimeEntry(int id)
    {
        var result = timeEntryRepository.DeleteTimeEntry(id);
        if (result == null)
        {
            return null;
        }
        return result.Adapt<List<TimeEntryResponse>>();
    }

    public List<TimeEntryResponse> GetAllTimeEntries()
    {
        var result = timeEntryRepository.GetAllTimeEntries();

        return result.Adapt<List<TimeEntryResponse>>();
    }

    public TimeEntryResponse? GetTimeEntry(int id)
    {
        var result = timeEntryRepository.GetTimeEntry(id);
        if (result == null) return null;
        return result.Adapt<TimeEntryResponse>();
    }

    public List<TimeEntryResponse>? UpdateTimeEntry(int id, TimeEntryUpdateRequest timeEntry)
    {
        var updatedEntry = timeEntry.Adapt<TimeEntry>();
        var result = timeEntryRepository.UpdateTimeEntry(id, updatedEntry);
        if (result == null)
        {
            return null;
        }
        return result.Adapt<List<TimeEntryResponse>>();
    }
}