using TimeTracker.Shared.Models.Account;

namespace TimeTrackerApi.Services;

public interface IAccountService
{
    Task<AccountRegistrationResponse> RegisterAsync(AccountRegistrationRequest request);
}