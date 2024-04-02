using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Interfaces.Auth;

public interface ITokenService
{
    string GenerateToken(User user);
    string GenerateRefreshToken();
}