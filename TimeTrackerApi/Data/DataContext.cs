namespace TimeTrackerApi.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<TimeEntry> TimeEntries { get; set; }
}