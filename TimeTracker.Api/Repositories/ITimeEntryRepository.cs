﻿namespace TimeTrackerApi.Repositories;

public interface ITimeEntryRepository
{
    Task<List<TimeEntry>> GetAllTimeEntries();
    Task<TimeEntry?> GetTimeEntry(int id);
    Task<List<TimeEntry>> GetTimeEntries(int skip, int limit);
    Task<int> GeTimeEntriesCount();
    Task<List<TimeEntry>> CreateTimeEntry(TimeEntry timeEntry);
    Task<List<TimeEntry>> UpdateTimeEntry(int id, TimeEntry timeEntry);
    Task<List<TimeEntry>?> DeleteTimeEntry(int id);
    Task<List<TimeEntry>> GetTimeEntriesByProject(int projectId);
}