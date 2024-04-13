using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Interfaces.Repositories;

public interface ICarModelRepository : IRepository<Model>
{
    Task<List<Model>> GetByMarkaId(long id);
}