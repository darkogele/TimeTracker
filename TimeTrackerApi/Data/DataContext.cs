namespace TimeTrackerApi.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<TimeEntry> TimeEntries { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectDetails> ProjectDetails { get; set; }
    public DbSet<User> Users { get; set; }
}