using TimeTrackerApi.Data;

namespace TimeTrackerApi.Repositories;

public class TimeEntryRepository(DataContext dataContext, IUserContextService userContext) : ITimeEntryRepository
{
    public async Task<List<TimeEntry>> GetAllTimeEntries()
    {
        var userId = userContext.GetUserId();
    
        return await dataContext.TimeEntries
           .Where(x => x.User.Id == userId)
           .Include(x => x.Project)
           .ThenInclude(x => x!.ProjectDetails)
           .ToListAsync();
    }

    public async Task<TimeEntry?> GetTimeEntry(int id)
    {
        var userId = userContext.GetUserId();
       
        return await dataContext.TimeEntries
            .Include(x => x.Project)
            .ThenInclude(x => x!.ProjectDetails)
            .FirstOrDefaultAsync(x => x.Id == id && x.User.Id == userId);
    }

    public async Task<List<TimeEntry>> CreateTimeEntry(TimeEntry timeEntry)
    {
        var user = await userContext.GetUser();

        timeEntry.User = user;
        dataContext.TimeEntries.Add(timeEntry);
        await dataContext.SaveChangesAsync();

        return await GetAllTimeEntries();
    }

    public async Task<List<TimeEntry>> UpdateTimeEntry(int id, TimeEntry timeEntry)
    {
        var userId = userContext.GetUserId();
          
        var existingEntry = await dataContext.TimeEntries.FirstOrDefaultAsync(x => x.Id == id && x.User.Id == userId)
                            ?? throw new EntityNotFoundException($"Time entry with Id {id} not found");

        existingEntry.ProjectId = timeEntry.ProjectId;
        existingEntry.Start = timeEntry.Start;
        existingEntry.End = timeEntry.End;
        existingEntry.UpdatedDate = DateTime.Now;

        await dataContext.SaveChangesAsync();

        return await dataContext.TimeEntries.ToListAsync();
    }

    public async Task<List<TimeEntry>?> DeleteTimeEntry(int id)
    {
        var userId = userContext.GetUserId();
    
        var existingEntry = await dataContext.TimeEntries
            .FirstOrDefaultAsync(x => x.Id == id && x.User.Id == userId);
        if (existingEntry == null) return null;

        dataContext.Remove(existingEntry);
        await dataContext.SaveChangesAsync();

        return await GetAllTimeEntries();
    }

    public async Task<List<TimeEntry>> GetTimeEntriesByProject(int projectId)
    {
        var userId = userContext.GetUserId();
            
        return await dataContext.TimeEntries
            .Where(x => x.ProjectId == projectId && x.User.Id == userId)
            .Include(x => x.Project)
            .ThenInclude(x => x!.ProjectDetails)
            .ToListAsync();
    }

    public async Task<List<TimeEntry>> GetTimeEntries(int skip, int limit)
    {
        var userId = userContext.GetUserId();
          
        return await dataContext.TimeEntries
             .Where(x => x.User.Id == userId)
             .Include(x => x.Project)
             .ThenInclude(x => x!.ProjectDetails)
             .Skip(skip)
             .Take(limit)
             .ToListAsync();
    }

    public async Task<int> GeTimeEntriesCount()
    {
        return await dataContext.TimeEntries.CountAsync();
    }
}