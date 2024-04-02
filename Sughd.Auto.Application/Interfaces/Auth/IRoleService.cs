using Sughd.Auto.Application.Constants;

namespace Sughd.Auto.Application.Interfaces.Auth;

public interface IRoleService
{
    Task<bool> IsInRole(string username, string roleName );
    Task AddUserRole(string username, string role);
    Task UpdateUserRole(string username, string newRole);
}