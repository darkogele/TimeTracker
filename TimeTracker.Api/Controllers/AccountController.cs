﻿using Microsoft.AspNetCore.Mvc;
using TimeTracker.Shared.Models.Account;

namespace TimeTrackerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AccountRegistrationResponse>> Register(AccountRegistrationRequest request)
    {
        var result = await _accountService.RegisterAsync(request);
        if (!result.IsSuccessful)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}