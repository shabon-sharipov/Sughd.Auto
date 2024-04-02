using Microsoft.AspNetCore.Identity;
using Sughd.Auto.Application.Constants;
using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.RequestModels;
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

    public async Task<User?> Create(CreateUserRequest createUserRequest)
    {
        var user = new User
        {
            UserName = createUserRequest.UserName,
            Email = createUserRequest.Email,
            PhoneNumber = createUserRequest.PhoneNumber
        };

        var result = await _userManager.CreateAsync(user, createUserRequest.Password);

        if (result.Succeeded)
        {
            return null;
        }

        await _userManager.AddToRoleAsync(user, Constant.CustomerRole);
        return user;
    }
}