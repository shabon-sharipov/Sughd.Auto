using Sughd.Auto.Application.Interfaces.Auth.AuthRepository;
using Sughd.Auto.Domain.AuthModel;
using Sughd.Auto.Infrastructure.DataBase;
using Sughd.Auto.Infrastructure.Repositories;

namespace Sughd.Auto.Infrastructure.AuthRepositories;

public class UserTokenRepository : Repository<UserToken>, IUserTokenRepository
{
    public UserTokenRepository(EFContext context) : base(context)
    {
    }
}