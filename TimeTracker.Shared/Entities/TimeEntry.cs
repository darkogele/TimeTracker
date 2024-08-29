namespace TimeTracker.Shared.Entities;

public class TimeEntry
{
    public int Id { get; set; }

    public required string Project { get; set; }

    public DateTime Start { get; set; } = DateTime.Now;

    public DateTime? End { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime? UpdatedDate { get; set; }
}