using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Interfaces;

public interface ICarService : IBaseService<CarRequestModel, CarResponseModel>
{
    Task UpdateImage(long id, List<string> images);
    Task UpdateStatus(long id, bool isActive);
    Task UpdatePaymentAt(long carId);
    Task<CarStatisticsResponseModel> GetStatistics();
    Task<CalculateCheckResponseModel> CalculateCheck(CalculateCheckRequestModel calculateCheckResponseModel);

    Task<List<CarResponseModel>> GetAllForShowToUser(int pageSize, int pageNumber, CancellationToken cancellationToken);
}