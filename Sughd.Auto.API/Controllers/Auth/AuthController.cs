using Microsoft.AspNetCore.Mvc;
using Sughd.Auto.Application.Interfaces.Auth;
using Sughd.Auto.Application.RequestModels.Auth;

namespace Sughd.Auto.API.Controllers.Auth;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(Login model)
    {
        try
        {
            await _authService.Login(model.Username, model.Password);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(Register model)
    {
        try
        {
            var user = await _authService.Register(model.Username, model.Email, model.Password);
            return Ok(user);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
    
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        try
        {
            await _authService.Logout();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
    // [HttpPost("refresh-token")]
    // public async Task<IActionResult> RefreshToken(RefreshToken model)
    // {
    //     // Implement refresh token endpoint
    // }
}