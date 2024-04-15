using Microsoft.AspNetCore.Identity;
using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.RequestModels.Auth;
using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;

    public UserService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task<User?> GetUserById(string userId)
    {
        var user =  await _userManager.FindByIdAsync(userId);

        if (user is null)
        {
             throw new Exception("User not found"); 
        }
        
        return user;
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        var user =  await _userManager.FindByEmailAsync(email);

        if (user is null)
        {
             throw new Exception("User not found"); 
        }
        
        return user;
    }

    public async Task UpdateUserRole(AddOrUpdateUserRoleRequest updateUserRoleRequest)
    {
        var user = await _userManager.FindByEmailAsync(updateUserRoleRequest.UserEmail);

        if (user == null)
            throw new InvalidOperationException("User not found.");

        // Remove all existing roles
        var existingRoles = await _userManager.GetRolesAsync(user);

        var existingRole = existingRoles.FirstOrDefault(r => r == updateUserRoleRequest.OldRole);
        
        if (existingRole!= null)
            await _userManager.RemoveFromRoleAsync(user, existingRole);
        
        await _userManager.AddToRoleAsync(user, updateUserRoleRequest.NewRole);
    }

    public async Task AddUserRole(string userEmail, string role)
    {
        var user = await _userManager.FindByEmailAsync(userEmail);

        if (user == null)
            throw new InvalidOperationException("User not found.");

        // Add the new role
        await _userManager.AddToRoleAsync(user, role);
    }

    public Task<List<UserResponseModel>> GetAllUsers()
    {
        throw new NotImplementedException();
    }
}