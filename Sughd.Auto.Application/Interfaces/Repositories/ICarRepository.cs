using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Interfaces.Repositories;

public interface ICarRepository : IRepository<Car>
{
    Task<List<Car>> Search(SearchCarRequestModel searchCarRequestModel);
}