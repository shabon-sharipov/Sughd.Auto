using Sughd.Auto.Application.Interfaces.Auth.AuthRepository;
using Sughd.Auto.Domain.AuthModel;
using Sughd.Auto.Infrastructure.DataBase;
using Sughd.Auto.Infrastructure.Repositories;

namespace Sughd.Auto.Infrastructure.AuthRepositories;

public class UserTokenRepository : RepositoryV2<UserToken>, IUserTokenRepository
{
    public UserTokenRepository(EFContextV2 context) : base(context)
    {
    }
}