using Microsoft.EntityFrameworkCore;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Domain.Models;
using Sughd.Auto.Infrastructure.DataBase;

namespace Sughd.Auto.Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(EFContext context) : base(context)
    {
    }

    public async Task<List<string>> SearchByUserName(string userName)
    {
        var userNames = _dbSet.Where(u => u.UserName.StartsWith(userName)).Select(u => u.UserName);

        return (await userNames.ToListAsync())!;
    }
}