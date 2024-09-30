using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace TimeTrackerApi.Services;

public class UserContextService : IUserContextService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<User> _userManager;

    public UserContextService(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
    {
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
    }

    public async Task<User> GetUser()
    {
        var httpContextUser = (_httpContextAccessor.HttpContext?.User)
            ?? throw new Exception("User not found in HttpContext");
        var user = await _userManager.GetUserAsync(httpContextUser)
            ?? throw new Exception("User not found in database");
        return user;
    }

    public string GetUserId()
    {
        return _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)
            ?? throw new EntityNotFoundException("User not found");
    }
}