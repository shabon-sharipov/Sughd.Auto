using Microsoft.EntityFrameworkCore;
using Sughd.Auto.Application.Interfaces.Auth.AuthRepository;
using Sughd.Auto.Domain.AuthModel;
using Sughd.Auto.Infrastructure.DataBase;
using Sughd.Auto.Infrastructure.Repositories;

namespace Sughd.Auto.Infrastructure.AuthRepositories;

public class UserRoleRepository : RepositoryV2<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(EFContextV2 context) : base(context)
    {
    }
}