using Microsoft.EntityFrameworkCore;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.AuthModel;
using Sughd.Auto.Domain.Models;
using Sughd.Auto.Infrastructure.DataBase;

namespace Sughd.Auto.Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(EFContext context) : base(context)
    {
    }

    public async Task<List<UserInfoForSaleCarResponseModel>> SearchByPhoneNumber(string phoneNumber)
    {
        var userNames = _dbSet.Where(u => u.PhoneNumber.StartsWith(phoneNumber)).Select(u =>
            new UserInfoForSaleCarResponseModel { Id = u.Id, Name = u.UserName, PhoneNumber = u.PhoneNumber });

        return (await userNames.ToListAsync())!;
    }

    public async Task<User ?> GetByRefreshToken(string refreshToken)
    {
        var user = _dbSet.FirstOrDefault(u => u.RefreshToken == refreshToken);

        return await Task.FromResult(user);
    }
    
    public async Task<User ?> FindByEmailAsync(string email)
    {
        var user = _dbSet.Include(s=>s.Roles).FirstOrDefault(u => u.Email == email);

        return await Task.FromResult(user);
    }

    public async Task<User ?> FindByEmailAndPasswordAsync(string email, string password)
    {
        var user = _dbSet.Include(s=>s.Roles).FirstOrDefault(u => u.Email == email && u.Password == password);

        return await Task.FromResult(user);
    }

    public async Task<User ?> FindByNameAsync(string userName)
    {
        var user = _dbSet.FirstOrDefault(u => u.UserName == userName);

        return await Task.FromResult(user);
    }

    public async Task<double[]> GetStatistics()
    {
        var workers = await _dbSet.CountAsync(c => c.Roles.Any());
        var customer = await _dbSet.CountAsync(c => !c.Roles.Any());
        return new double[] { workers, customer};
    }
}