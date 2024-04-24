using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Domain.AuthModel;

namespace Sughd.Auto.Application.Interfaces.Auth.AuthRepository;

public interface IRoleRepository : IRepository<Role>
{
    Task<bool> RoleExistsAsync(string role);
}