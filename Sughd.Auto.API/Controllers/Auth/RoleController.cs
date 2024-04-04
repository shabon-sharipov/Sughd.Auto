using Microsoft.AspNetCore.Mvc;
using Sughd.Auto.Application.Interfaces.Auth;
using Sughd.Auto.Application.RequestModels.Auth;

namespace Sughd.Auto.API.Controllers.Auth;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpPost]
    public async Task<IActionResult> Login(string roleName)
    {
        try
        {
            await _roleService.Add(roleName);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRoleRequest updateRoleRequest)
    {
        try
        {
            await _roleService.UpdateRole(updateRoleRequest.RoleName, updateRoleRequest.NewRoleName);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}