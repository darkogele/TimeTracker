using Microsoft.AspNetCore.Identity;

namespace TimeTracker.Shared.Entities;

public class User : IdentityUser
{
    public List<Project> Projects { get; set; } = [];
    public List<TimeEntry> TimeEntries { get; set; } = [];
}