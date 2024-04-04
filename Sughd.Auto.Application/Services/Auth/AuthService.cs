using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Sughd.Auto.Application.Constants;
using Sughd.Auto.Application.Interfaces.Auth;
using Sughd.Auto.Application.RequestModels.Auth;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Services.Auth;

public class AuthService(UserManager<User> userManager, 
        SignInManager<User> signInManager, 
        ITokenService tokenService,
        RoleManager<IdentityRole<int>> roleManager) : IAuthService
{
    public async Task<string> Login(string userEmail, string password)
    {
        var user = await userManager.FindByEmailAsync(userEmail);

        if (user == null)
            throw new InvalidOperationException("Invalid username or password.");

        var result = await signInManager.CheckPasswordSignInAsync(user, password, false);

        if (!result.Succeeded)
            throw new InvalidOperationException("Invalid username or password.");

        var userRoles = await userManager.GetRolesAsync(user);
        
        return tokenService.GenerateToken(user, JsonConvert.SerializeObject(userRoles));
    }
    
    public async Task Logout()
    {
        await signInManager.SignOutAsync();
    }

    public async Task<string> RefreshToken(string token, string refreshToken)
    {
        return await Task.FromResult( tokenService.GenerateRefreshToken());
    }

    public async Task<User> Register(Register register)
    {
        var user = new User
        {
            UserName = register.UserName,
            Email = register.Email,
            PhoneNumber = register.PhoneNumber
        };

        
        var result = await userManager.CreateAsync(user, register.Password);

        if (!result.Succeeded)
            throw new InvalidOperationException("Failed to register user.");

        if (!await roleManager.RoleExistsAsync(Constant.CustomerRole))
        {
           // _logger.LogError($"Role '{Constant.CustomerRole}' does not exist.");
            throw new InvalidOperationException($"Role '{Constant.CustomerRole}' does not exist.");
        }
        
        await userManager.AddToRolesAsync(user, new[] { Constant.CustomerRole });

        return user;
    }
}