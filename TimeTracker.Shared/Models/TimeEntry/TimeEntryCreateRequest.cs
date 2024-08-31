namespace TimeTracker.Shared.Models.TimeEntry;

//public class TimeEntryCreateRequest
//{
//    public required string Project { get; set; }

//    public DateTime Start { get; set; } = DateTime.Now;

//    public DateTime? End { get; set; }
//}

public record struct TimeEntryCreateRequest(string Project, DateTime Start, DateTime? End);