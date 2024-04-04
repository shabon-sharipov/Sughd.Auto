using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Sughd.Auto.Application.Interfaces.Auth;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Services.Auth;

public class TokenService : ITokenService
{
    public string GenerateToken(User user, string role)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        
        var key = GenerateKey();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new (ClaimTypes.Name, user.UserName!),
                new (ClaimTypes.Email, user.Email!),
                new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new (ClaimTypes.Role, role)
            }),
            Expires = DateTime.UtcNow.AddMinutes(15),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
    
    public static byte[] GenerateKey()
    {
        //TODO: need move to appsettings.json
        string combinedString = "Sughd,Auto,Khujand";

        using (var sha256 = SHA256.Create())
        {
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(combinedString));
            return hash;
        }
    } 
    
    public class JwtSettings
    {
        public string Secret { get; set; }
        public int AccessTokenExpirationMinutes { get; set; }
        public int RefreshTokenExpirationMinutes { get; set; }
    }
}