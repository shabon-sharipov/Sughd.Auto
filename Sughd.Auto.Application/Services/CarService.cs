using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;

    public CarService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public Task<CarResponseModel> Create(CarRequestModel entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CarResponseModel> GetById(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CarResponseModel> Update(long id, CarRequestModel entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<CarResponseModel>> Get(int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CarResponseModel> Delete(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}