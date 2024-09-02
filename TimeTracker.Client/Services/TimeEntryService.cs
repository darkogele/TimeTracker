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
}