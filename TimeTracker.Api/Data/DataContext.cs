namespace TimeTrackerApi.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // If we always need to include the ProjectDetails, we can uncomment this line
        //modelBuilder.Entity<TimeEntry>().Navigation(c => c.Project).AutoInclude();
    }

    public DbSet<TimeEntry> TimeEntries { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectDetails> ProjectDetails { get; set; }
    public DbSet<User> Users { get; set; }
}