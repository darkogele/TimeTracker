using Mapster;

namespace TimeTrackerApi.Services;

public class TimeEntryService(ITimeEntryRepository timeEntryRepository) : ITimeEntryService
{
    public async Task<List<TimeEntryResponse>> AddTimeEntry(TimeEntryCreateRequest timeEntry)
    {
        var newEntry = timeEntry.Adapt<TimeEntry>();

        var result = await timeEntryRepository.CreateTimeEntry(newEntry);

        return result.Adapt<List<TimeEntryResponse>>();
    }

    public async Task<List<TimeEntryResponse>?> DeleteTimeEntry(int id)
    {
        var result = await timeEntryRepository.DeleteTimeEntry(id);

        return result?.Adapt<List<TimeEntryResponse>>();
    }

    public async Task<List<TimeEntryResponse>> GetTimeEntriesByProject(int projectId)
    {
        var result = await timeEntryRepository.GetTimeEntriesByProject(projectId);

        return result.Adapt<List<TimeEntryResponse>>();
    }

    public async Task<List<TimeEntryResponse>> GetAllTimeEntries()
    {
        var result = await timeEntryRepository.GetAllTimeEntries();

        return result.Adapt<List<TimeEntryResponse>>();
    }

    public async Task<TimeEntryResponse?> GetTimeEntry(int id)
    {
        var result = await timeEntryRepository.GetTimeEntry(id);
        if (result == null) return null;
        return result.Adapt<TimeEntryResponse>();
    }

    public async Task<List<TimeEntryResponse>?> UpdateTimeEntry(int id, TimeEntryUpdateRequest timeEntry)
    {
        try
        {
            var updatedEntry = timeEntry.Adapt<TimeEntry>();
            var result = await timeEntryRepository.UpdateTimeEntry(id, updatedEntry);

            return result.Adapt<List<TimeEntryResponse>>();
        }
        catch (EntityNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<TimeEntryResponseWrapper> GetTimeEntryWrapper(int skip, int take)
    {
        var timeEntries = await timeEntryRepository.GetTimeEntries(skip, take);
        var count = await timeEntryRepository.GeTimeEntriesCount();

        return new TimeEntryResponseWrapper
        {
            TimeEntries = timeEntries.Adapt<List<TimeEntryResponse>>(),
            TotalCount = count
        };
    }
}