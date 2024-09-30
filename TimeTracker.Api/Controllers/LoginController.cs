using Microsoft.AspNetCore.Mvc;
using TimeTracker.Shared.Models.Login;

namespace TimeTrackerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly ILoginService loginService;

    public LoginController(ILoginService loginService)
    {
        this.loginService = loginService;
    }

    [HttpPost]
    public async Task<ActionResult<LoginResponse>> Login(LoginRequest loginRequest)
    {
        var result = await loginService.Login(loginRequest);
        if (!result.IsSuccessful)
            return BadRequest(result);
        return Ok(result);
    }
}