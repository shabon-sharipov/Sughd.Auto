using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Interfaces.Repositories;

public interface ITestRepository : IRepository<Test>
{
    Task<List<Test>> SearchByUserName(string text);
}