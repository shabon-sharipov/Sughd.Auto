using Microsoft.AspNetCore.Mvc;
using Sughd.Auto.Application.AuthServices;
using Sughd.Auto.Application.RequestModels.Auth;

namespace Sughd.Auto.API.Controllers.AuthController;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(Login model)
    {
        try
        {
            var result = await authService.Login(model.UserEmail, model.Password);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(Register register)
    {
        try
        {
            var user = await authService.Register(register);
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
            await authService.Logout();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken(string refreshToken)
    {
        try
        {
            var response = await authService.RefreshToken(refreshToken);
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}