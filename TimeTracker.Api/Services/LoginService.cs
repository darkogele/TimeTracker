using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TimeTracker.Shared.Models.Login;

namespace TimeTrackerApi.Services;

public class LoginService : ILoginService
{
    private readonly ILogger<LoginService> _logger;
    private readonly SignInManager<User> _signInManager;
    private readonly IConfiguration _config;
    private readonly UserManager<User> _userManager;

    public LoginService(ILogger<LoginService> logger, SignInManager<User> signInManager, IConfiguration configuration, UserManager<User> userManager)
    {
        _logger = logger;
        _signInManager = signInManager;
        _config = configuration;
        _userManager = userManager;
    }

    public async Task<LoginResponse> Login(LoginRequest loginRequest)
    {
        var result = await _signInManager.PasswordSignInAsync(loginRequest.UserName, loginRequest.Password, false, false);

        if (!result.Succeeded)
        {
            _logger.LogWarning("Failed to login user {UserName}", loginRequest.UserName);
            return new LoginResponse(false, "Invalid username or password");
        }

        _logger.LogInformation("User {UserName} logged in successfully", loginRequest.UserName);

        var user = await _userManager.FindByNameAsync(loginRequest.UserName);
        if (user == null)
        {
            _logger.LogWarning("Failed to find user {UserName}", loginRequest.UserName);
            return new LoginResponse(false, "User doesn't exists.");
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, loginRequest.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSecurityKey"]!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddDays(Convert.ToInt32(_config["JwtExpireInDays"]));

        var token = new JwtSecurityToken(
            _config["JwtIssuer"],
            _config["JwtAudience"],
            claims,
            expires: expires,
            signingCredentials: creds
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return new LoginResponse(true, Token: jwt);
    }
}