using Microsoft.EntityFrameworkCore;
using Sughd.Auto.Application.Interfaces.Auth.AuthRepository;
using Sughd.Auto.Domain.AuthModel;
using Sughd.Auto.Infrastructure.DataBase;
using Sughd.Auto.Infrastructure.Repositories;

namespace Sughd.Auto.Infrastructure.AuthRepositories;

public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(EFContext context) : base(context)
    {
    }
}