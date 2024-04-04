using Microsoft.AspNetCore.Identity;
using Sughd.Auto.Application.Interfaces.Auth;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Services.Auth;

public class RoleService : IRoleService
{
    private readonly RoleManager<IdentityRole<int>> _roleManager;

    public RoleService(RoleManager<IdentityRole<int>> roleManager)
    {
        _roleManager = roleManager;
    }

    public Task<bool> IsInRole(string username, string roleName)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateRole(string roleName, string newRoleName)
    {
        var role = await _roleManager.FindByNameAsync(roleName);
        if (role == null)
        {
            //_logger.LogError($"Role '{roleName}' not found.");
            throw new InvalidOperationException($"Role '{roleName}' not found.");
        }

        role.Name = newRoleName;
        var result = await _roleManager.UpdateAsync(role);
        if (!result.Succeeded)
        {
            var errors = string.Join("\n", result.Errors.Select(e => e.Description));
           // _logger.LogError($"Failed to update role '{roleName}': {errors}");
            throw new InvalidOperationException($"Failed to update role '{roleName}'.");
        }
        //_logger.LogInformation($"Role '{roleName}' updated to '{newRoleName}' successfully.");
    }

    public async Task Add( string roleName)
    {
        if (await _roleManager.RoleExistsAsync(roleName))
        {
            //ToDO: Need write log
            return;
        }

        var newRole = new IdentityRole<int>(roleName);
        var result = await _roleManager.CreateAsync(newRole);
        if (!result.Succeeded)
        {
            var errors = string.Join("\n", result.Errors.Select(e => e.Description));
            //_logger.LogError($"Failed to create role '{roleName}': {errors}");
            throw new InvalidOperationException($"Failed to create role '{roleName}'.");
        }
    }
}