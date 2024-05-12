using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sughd.Auto.Application.AuthServices;
using Sughd.Auto.Application.RequestModels;

namespace Sughd.Auto.API.Controllers.AuthController;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private IUserService _userService;

    public UserController(IUserService carService)
    {
        _userService = carService;
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await _userService.GetById(id, CancellationToken.None);
        return Ok(result);
    }
    
    [HttpGet("GetStatistics")]
    public async Task<IActionResult> GetStatistics()
    {
        var result = await _userService.GetStatistics();
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] int pageSize, [FromQuery] int offSet)
    {
        var result = await _userService.Get(pageSize, offSet, CancellationToken.None);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(long id, UserUpdateRequestModel carRequestModel)
    {
        var result = await _userService.Update(id, carRequestModel, CancellationToken.None);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(long id)
    {
        var result = await _userService.Delete(id, CancellationToken.None);
        return Ok(result);
    }

    [HttpGet]
    [Route("me")]
    public async Task<ActionResult> GetCurrentUserProfile()
    {
        var email = HttpContext.User.FindFirst(ClaimTypes.Email).Value;
        return Ok(await _userService.FindByNameAsync(email, CancellationToken.None));
    }
}