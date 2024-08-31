﻿using TimeTrackerApi.Data;

namespace TimeTrackerApi.Repositories;

public class TimeEntryRepository(DataContext dataContext) : ITimeEntryRepository
{
    public async Task<List<TimeEntry>> GetAllTimeEntries()
    {
        return await dataContext.TimeEntries.ToListAsync();
    }

    public async Task<TimeEntry?> GetTimeEntry(int id)
    {
        return await dataContext.TimeEntries.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<TimeEntry>> CreateTimeEntry(TimeEntry timeEntry)
    {
        dataContext.TimeEntries.Add(timeEntry);
        await dataContext.SaveChangesAsync();

        return await dataContext.TimeEntries.ToListAsync();
    }

    public async Task<List<TimeEntry>> UpdateTimeEntry(int id, TimeEntry timeEntry)
    {
        var existingEntry = await dataContext.TimeEntries.FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new EntityNotFoundException($"Time entry with Id {id} not found");

        existingEntry.Project = timeEntry.Project;
        existingEntry.Start = timeEntry.Start;
        existingEntry.End = timeEntry.End;
        existingEntry.UpdatedDate = DateTime.Now;

        await dataContext.SaveChangesAsync();

        return await dataContext.TimeEntries.ToListAsync();
    }

    public async Task<List<TimeEntry>?> DeleteTimeEntry(int id)
    {
        var existingEntry = await dataContext.TimeEntries.FirstOrDefaultAsync(x => x.Id == id);
        if (existingEntry == null)
        {
            return null;
        }

        dataContext.Remove(existingEntry);
        await dataContext.SaveChangesAsync();

        return await dataContext.TimeEntries.ToListAsync();
    }
}