using Sughd.Auto.Application.AuthServices.ResponseModels;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Application.RequestModels.Auth;
using Sughd.Auto.Domain.AuthModel;

namespace Sughd.Auto.Application.AuthServices;

public interface IAuthService
{
    Task<JwtTokenResponse> Login(string userEmail, string password);
    Task Logout();
    Task<JwtTokenResponse> RefreshToken(string refreshToken);
    Task<User> Register(Register register);
}

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
   
    public AuthService(IUserRepository userRepository, 
        ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }
    
    public async Task<JwtTokenResponse> Login(string userEmail, string password)
    {
        var user = await _userRepository.FindByEmailAsync(userEmail);

        if (user == null)
            throw new InvalidOperationException("Invalid username or password.");
        
        return await _tokenService.GenerateToken(user, user.Roles);
    }
    
    public async Task Logout()
    {
        
    }

    public async Task<JwtTokenResponse> RefreshToken(string refreshToken)
    {
        return await _tokenService.GenerateRefreshToken(refreshToken);
    }

    public async Task<User> Register(Register register)
    {
        var user = new User
        {
            UserName = register.UserName,
            Email = register.Email,
            PhoneNumber = register.PhoneNumber,
            Password = register.Password,
            RefreshToken = Guid.NewGuid().ToString()
        };

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();
        return user;
    }
}