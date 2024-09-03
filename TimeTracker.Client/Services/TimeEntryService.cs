using Mapster;
using System.Net.Http.Json;
using TimeTracker.Shared.Models.TimeEntry;

namespace TimeTracker.Client.Services;

public class TimeEntryService(HttpClient http) : ITimeEntryService
{
    public List<TimeEntryResponse> TimeEntries { get; set; } = [];

    public event Action? OnChange;

    public async Task GetTimeEntriesByProject(int projectId)
    {
        List<TimeEntryResponse>? result;
        if (projectId > 0)
        {
            result = await http.GetFromJsonAsync<List<TimeEntryResponse>>($"api/timeentry/project/{projectId}");
        }
        else
        {
            result = await http.GetFromJsonAsync<List<TimeEntryResponse>>("api/timeentry");
        }

        if (result != null)
        {
            TimeEntries = result;
            OnChange?.Invoke();
        }
    }

    public async Task<TimeEntryResponse> GetTimeEntryById(int id)
    {
        return await http.GetFromJsonAsync<TimeEntryResponse>($"api/timeentry/{id}");
    }

    public async Task CreateTimeEntry(TimeEntryRequest timeEntry)
    {
        //await http.PostAsJsonAsync("api/timeentry", timeEntry.Adapt<TimeEntryCreateRequest>());
        await http.PostAsJsonAsync("api/timeentry", timeEntry);
    }

    public async Task UpdateTimeEntry(int id, TimeEntryRequest timeEntry)
    {
        await http.PutAsJsonAsync($"api/timeentry/{id}", timeEntry.Adapt<TimeEntryUpdateRequest>());
    }

    public async Task DeleteTimeEntry(int id)
    {
        await http.DeleteAsync($"api/timeentry/{id}");
    }
}