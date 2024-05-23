using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Interfaces.Repositories;

public interface ICarRepository : IRepository<Car>
{
    Task<List<Car>> Search(SearchCarRequestModel searchCarRequestModel);
    Task<List<Car>> GetAllAsync(int pageSize, int PageNumber, CancellationToken cancellationToken);
    Task<IQueryable<Car>> GetCarsIfIsActive(int pageSize, int pageNumber);
    Task<CarStatisticsResponseModel> GetStatistics();
    Task<CalculateCheckResponseModel> CalculateCheck(CalculateCheckRequestModel calculateCheckResponseModel);
}