using Microsoft.EntityFrameworkCore;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.Models;
using Sughd.Auto.Infrastructure.DataBase;

namespace Sughd.Auto.Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(EFContext context) : base(context)
    {
    }

    public async Task<List<UserInfoForSaleCarResponseModel>> SearchByUserName(string phoneNumber)
    {
        var userNames = _dbSet.Where(u => u.PhoneNumber.StartsWith(phoneNumber)).Select(u =>
            new UserInfoForSaleCarResponseModel { Id = u.Id, Name = u.UserName, PhoneNumber = u.PhoneNumber });

        return (await userNames.ToListAsync())!;
    }
}