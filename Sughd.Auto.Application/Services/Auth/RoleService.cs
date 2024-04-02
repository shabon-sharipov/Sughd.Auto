using Microsoft.AspNetCore.Identity;
using Sughd.Auto.Application.Interfaces.Auth;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Services.Auth;

public class RoleService : IRoleService
{
    private readonly UserManager<User> _userManager;

    public RoleService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public Task<bool> IsInRole(string username, string roleName)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateUserRole(string username, string newRole)
    {
        var user = await _userManager.FindByNameAsync(username);

        if (user == null)
            throw new InvalidOperationException("User not found.");

        // Remove all existing roles
        var existingRoles = await _userManager.GetRolesAsync(user);
        await _userManager.RemoveFromRolesAsync(user, existingRoles.ToArray());

        // Add the new role
        await _userManager.AddToRoleAsync(user, newRole);
    }

    public async Task AddUserRole(string username, string role)
    {
        var user = await _userManager.FindByNameAsync(username);

        if (user == null)
            throw new InvalidOperationException("User not found.");

        // Add the new role
        await _userManager.AddToRoleAsync(user, role);
    }
}