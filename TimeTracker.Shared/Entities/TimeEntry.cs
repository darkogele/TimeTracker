﻿namespace TimeTracker.Shared.Entities;

public class TimeEntry : BaseEntity
{
    public DateTime Start { get; set; } = DateTime.Now;
    public DateTime? End { get; set; }
    
    // Fk
    public int? ProjectId { get; set; }
    public  Project? Project { get; set; }
}