using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Interfaces.Repositories;

public interface ICarMarkaRepository : IRepository<Marka>
{
    Task<List<Marka>> SearchByMarkaName(string markaName);
}