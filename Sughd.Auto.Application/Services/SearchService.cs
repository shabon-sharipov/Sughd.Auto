using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Services;

public class SearchService(ICarRepository carRepository) : ISearchService
{
    public async Task<List<Car>> Search(SearchCarRequestModel searchCarRequestModel)
    {
      return await carRepository.Search(searchCarRequestModel);
    }
}