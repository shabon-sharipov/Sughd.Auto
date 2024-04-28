using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sughd.Auto.Application.AuthServices;
using Sughd.Auto.Application.AuthServices.RequestModels;
using Sughd.Auto.Application.Constants;

namespace Sughd.Auto.API.Controllers.AuthController;

[Route("[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [Authorize(Roles = $"{UserRoles.Admin}, {UserRoles.Moderator}")]
    [HttpGet("GetRoles")]
    public async Task<IActionResult> GetRoles()
    {
        var list = await _roleService.GetRolesAsync();
        return Ok(list);
    }

    [Authorize(Roles = $"{UserRoles.Admin}, {UserRoles.Moderator}")]
    [HttpGet("GetUserRole")]
    public async Task<IActionResult> GetUserRole(string userEmail)
    {
        var userClaims = await _roleService.GetUserRolesAsync(userEmail);
        return Ok(userClaims);
    }
    
    [Authorize(Roles = $"{UserRoles.Admin}, {UserRoles.Moderator}")]
    [HttpPost("addRoles")]
    public async Task<ActionResult> AddRole(string[] roles)
    {
        var userrole = await _roleService.AddRolesAsync(roles);
        if (userrole.Count == 0)
        {
            return BadRequest();
        }

        return Ok(userrole);
    }

    [Authorize(Roles = $"{UserRoles.Admin}, {UserRoles.Moderator}")]
    [HttpPost("addUserRoles")]
    public async Task<ActionResult> AddUserRole([FromBody] AddUserRoleRequestModel addUser)
    {
        var result = await _roleService.AddUserRoleAsync(addUser.UserEmail, addUser.RoleIds);

        if (!result)
        {
            return BadRequest();
        }

        return StatusCode((int)HttpStatusCode.Created, result);
    }
}
