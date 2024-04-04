using Sughd.Auto.Application.Constants;

namespace Sughd.Auto.Application.Interfaces.Auth;

public interface IRoleService
{
    Task<bool> IsInRole(string username, string roleName );
    Task Add(string role);
    Task UpdateRole(string roleName, string newRoleName);
}