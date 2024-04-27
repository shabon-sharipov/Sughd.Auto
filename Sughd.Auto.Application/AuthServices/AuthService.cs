using AutoMapper;
using Microsoft.Extensions.Logging;
using Sughd.Auto.Application.AuthServices.ResponseModels;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Application.AuthServices.RequestModels;
using Sughd.Auto.Domain.AuthModel;

namespace Sughd.Auto.Application.AuthServices;

public interface IAuthService
{
    Task<JwtTokenResponse> Login(string userEmail, string password);
    Task Logout();
    Task<JwtTokenResponse> RefreshToken(string refreshToken);
    Task<UserResponseModel> Register(UserRegisterRequestModel register);
}

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public AuthService(IUserRepository userRepository,
        ITokenService tokenService, IMapper mapper)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        _mapper = mapper;
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

    public async Task<UserResponseModel> Register(UserRegisterRequestModel register)
    {
        var checkEmail = await _userRepository.FindByEmailAsync(register.Email);

        if (checkEmail != null)
        {
            throw new ArithmeticException($"User already exist with {register.Email}");
        }
        
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

        return new UserResponseModel()
        {
            Id = user.Id,
            UserName = user.UserName,
            PhoneNumber = user.PhoneNumber,
            Email = user.Email,
            RefreshToken = user.RefreshToken,
            Roles = _mapper.Map<List<RoleResponseModel>>(user.Roles),
            Password = user.Password
        };
    }
}