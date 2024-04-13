using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<List<string>> SearchByUserName(string userName);
}