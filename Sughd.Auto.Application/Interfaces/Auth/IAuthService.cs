using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Interfaces.Auth;

public interface IAuthService
{
    Task<string> Login(string username, string password);
    Task Logout();
    Task<string> RefreshToken(string token, string refreshToken);
    Task<User> Register(string username, string email, string password);
}