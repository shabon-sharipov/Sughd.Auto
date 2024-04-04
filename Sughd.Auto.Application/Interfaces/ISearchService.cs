using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Interfaces;

public interface ISearchService
{
    Task<List<Car>> Search(Dictionary<string, object> filter);
}