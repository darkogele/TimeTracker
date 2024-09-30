using TimeTracker.Shared.Models.Login;

namespace TimeTrackerApi.Services;

public interface ILoginService
{
    Task<LoginResponse> Login(LoginRequest loginRequest);
}