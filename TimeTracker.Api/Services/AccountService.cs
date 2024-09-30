using Microsoft.AspNetCore.Identity;
using TimeTracker.Shared.Models.Account;

namespace TimeTrackerApi.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<User> _userManager;
    //private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;

    public AccountService(UserManager<User> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<AccountRegistrationResponse> RegisterAsync(AccountRegistrationRequest request)
    {
        var newUser = new User { UserName = request.UserName, Email = request.Email, EmailConfirmed = true };
        var result = await _userManager.CreateAsync(newUser, request.Password);

        if (!result.Succeeded)
            return new AccountRegistrationResponse(false, result.Errors.Select(e => e.Description));
        return new AccountRegistrationResponse(true);
    }
}