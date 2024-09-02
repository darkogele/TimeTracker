namespace TimeTracker.Shared.Models.TimeEntry;

public record struct TimeEntryUpdateRequest(int Id, string Project, DateTime Start, DateTime? End);