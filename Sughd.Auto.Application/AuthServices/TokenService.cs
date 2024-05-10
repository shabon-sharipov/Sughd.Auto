using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Sughd.Auto.Application.AuthServices.ResponseModels;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Domain.AuthModel;

namespace Sughd.Auto.Application.AuthServices;


public interface ITokenService
{
    Task<JwtTokenResponse> GenerateToken(User user, List<Role> roles);
    Task<JwtTokenResponse> GenerateRefreshToken(string refreshToken);
}

public class TokenService : ITokenService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public TokenService(IUserRepository userRepository, IConfiguration configuration, IMapper mapper)
    {
        _userRepository = userRepository;
        _configuration = configuration;
        _mapper = mapper;
    }

    public async Task<JwtTokenResponse> GenerateToken(User user, List<Role> roles)
    {
        var claims = new List<Claim>
        {
            new (ClaimTypes.Name,user.UserName),
            new (ClaimTypes.Email, user.Email!),
            new (ClaimTypes.NameIdentifier,user.Id.ToString()),
        };
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));

        var jwt = new JwtSecurityToken(
            issuer:_configuration["JwtSettings:Issuer"],
            audience:_configuration["JwtSettings:Audience"],
            claims:claims,
            expires:DateTime.UtcNow.Add(TimeSpan.FromDays(1)),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"])),
                SecurityAlgorithms.HmacSha256));

        var accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);
        var refreshToken = Guid.NewGuid().ToString();
        user.RefreshToken = refreshToken;
        _userRepository.Update(user);
        await _userRepository.SaveChangesAsync();

        var roleResponse = roles.Count != 0 ? _mapper.Map<List<RoleResponseModel>>(roles) : [];
        
            return new JwtTokenResponse
        {
            RefreshToken = refreshToken,
            AccessToken = accessToken,
            Roles = roleResponse
        };
    }

    public async Task<JwtTokenResponse> GenerateRefreshToken(string refreshToken)
    {
        var user = await _userRepository.GetByRefreshToken(refreshToken);
        return await GenerateToken(user, user.Roles);
    }
}