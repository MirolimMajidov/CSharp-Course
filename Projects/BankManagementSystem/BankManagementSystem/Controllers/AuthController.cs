using BankManagementSystem.Contracts;
using BankManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    protected readonly AuthService _authService;
    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> LogIn(string username, string password)
    {
        try
        {
            TokenInfo token = await _authService.Login(username, password);
            return Ok(token);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("RefreshToken")]
    public async Task<IActionResult> RefreshToken(string refreshToken)
    {
        try
        {
            TokenInfo token = await _authService.RefreshToken(refreshToken);
            return Ok(token);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}