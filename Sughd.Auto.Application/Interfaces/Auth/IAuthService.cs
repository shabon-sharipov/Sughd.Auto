using Sughd.Auto.Application.RequestModels.Auth;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Interfaces.Auth;

public interface IAuthService
{
    Task<string> Login(string userEmail, string password);
    Task Logout();
    Task<string> RefreshToken(string token, string refreshToken);
    Task<User> Register(Register register);
}