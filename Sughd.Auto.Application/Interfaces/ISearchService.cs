using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Interfaces;

public interface ISearchService
{
    Task<List<Car>> Search(SearchCarRequestModel searchCarRequestModel);
    Task<List<string>> SearchByUserName(string userName);
}