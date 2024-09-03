namespace TimeTracker.Shared.Models.TimeEntry;

public record struct TimeEntryUpdateRequest(int Id, int ProjectId, DateTime Start, DateTime? End);