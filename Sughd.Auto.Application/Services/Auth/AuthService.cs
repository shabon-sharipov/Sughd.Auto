using Microsoft.AspNetCore.Identity;
using Sughd.Auto.Application.Constants;
using Sughd.Auto.Application.Interfaces.Auth;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Services.Auth;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ITokenService _tokenService;

    public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task<string> Login(string username, string password)
    {
        var user = await _userManager.FindByNameAsync(username);

        if (user == null)
            throw new InvalidOperationException("Invalid username or password.");

        var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

        if (!result.Succeeded)
            throw new InvalidOperationException("Invalid username or password.");

        return _tokenService.GenerateToken(user);
    }
    
    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<string> RefreshToken(string token, string refreshToken)
    {
        return await Task.FromResult( _tokenService.GenerateRefreshToken());
    }

    public async Task<User> Register(string username, string email, string password)
    {
        var user = new User
        {
            UserName = username,
            Email = email
        };

        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
            throw new InvalidOperationException("Failed to register user.");

        await _userManager.AddToRolesAsync(user, new[] { Constant.CustomerRole });

        return user;
    }
}