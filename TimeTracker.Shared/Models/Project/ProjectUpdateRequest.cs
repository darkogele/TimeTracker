namespace TimeTracker.Shared.Models.Project;

public record struct ProjectUpdateRequest(
    int Id, 
    string Name,
    string? Description,
    DateTime StartDate, 
    DateTime? EndDate);