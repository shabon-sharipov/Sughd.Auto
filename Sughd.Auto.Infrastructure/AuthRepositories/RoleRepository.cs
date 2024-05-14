using Sughd.Auto.Application.Interfaces.Auth.AuthRepository;
using Sughd.Auto.Domain.AuthModel;
using Sughd.Auto.Infrastructure.DataBase;
using Sughd.Auto.Infrastructure.Repositories;

namespace Sughd.Auto.Infrastructure.AuthRepositories;

public class RoleRepository : RepositoryV2<Role>, IRoleRepository
{
    public RoleRepository(EFContextV2 context) : base(context)
    {
    }

    public async Task<bool> RoleExistsAsync(string role)
    {
        var result = _dbSet.Any(r => r.Name.ToLower() == role.ToLower().Trim());

        return await Task.FromResult(result);
    }

    public async Task<Role?> GetByName(string role)
    {
        var result = _dbSet.FirstOrDefault(r => r.Name.ToLower() == role.ToLower().Trim());

        return await Task.FromResult(result);
    }
}