using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Interfaces.Repositories;

public interface ICarRepository : IRepository<Car>
{
    Task<List<Car>> Search(Dictionary<string, object> filter);
}