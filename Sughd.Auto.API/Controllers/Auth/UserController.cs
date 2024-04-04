using Microsoft.AspNetCore.Mvc;
using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.RequestModels.Auth;

namespace Sughd.Auto.API.Controllers.Auth;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserById(string userId)
    {
        var user = await userService.GetUserById(userId);
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetUserByEmail(string email)
    {
        var user = await userService.GetUserByEmail(email);
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPut("UpdateUserRole")]
    public async Task<IActionResult> UpdateUserRole([FromBody] AddOrUpdateUserRoleRequest updateUserRoleRequest)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await userService.UpdateUserRole(updateUserRoleRequest);

            return Ok("Role updated successfully");
        }
        catch (Exception e)
        {
            return BadRequest("Failed to update user role.");
        }
    }
    
    [HttpPost("AddUserRole")]
    public async Task<IActionResult> AddUserRole([FromBody] AddOrUpdateUserRoleRequest addOrUpdateUserRoleRequest)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await userService.AddUserRole(addOrUpdateUserRoleRequest.UserEmail, addOrUpdateUserRoleRequest.NewRole);

            return Ok("Role added successfully");
        }
        catch (Exception e)
        {
            return BadRequest("Failed to add user role.");
        }
    }
}