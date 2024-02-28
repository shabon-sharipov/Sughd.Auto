using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Application.ResponseModels;

namespace Sughd.Auto.Application.Services;

public class CarService : BaseService<CarRequestModel, CarResponseModel>, ICarService
{
}