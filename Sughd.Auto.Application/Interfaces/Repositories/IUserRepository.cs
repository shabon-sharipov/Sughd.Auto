using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.AuthModel;

namespace Sughd.Auto.Application.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<List<UserInfoForSaleCarResponseModel>> SearchByPhoneNumber(string phoneNumber);

    Task<User ?> GetByRefreshToken(string refreshToken);
    Task<User ?> FindByEmailAsync(string email);
    Task<User ?> FindByEmailAndPasswordAsync(string email, string password);
    Task<User ?> FindByNameAsync(string userName);
    Task<double[]> GetStatistics();
}