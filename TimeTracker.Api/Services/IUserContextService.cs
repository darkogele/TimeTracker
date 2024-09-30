namespace TimeTrackerApi.Services;

public interface IUserContextService
{
    string GetUserId();
    Task<User> GetUser();
}