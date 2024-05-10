using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Interfaces;

public interface ICarService : IBaseService<CarRequestModel, CarResponseModel>
{
    Task UpdateImage(long id, List<string> images);
}