
namespace TimeTracker.Shared.Models.TimeEntry;

public record struct TimeEntryResponseWrapper(int TotalCount, List<TimeEntryResponse> TimeEntries);
