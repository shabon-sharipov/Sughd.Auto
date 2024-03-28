using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Services;

public class CarModelService : ICarModelService
{
    private readonly ICarModelRepository _modelRepository;
    public CarModelService(ICarModelRepository modelRepository)
    {
    }

    public Task<CarModelResponseModel> Create(CarModelRequestModel entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CarModelResponseModel> GetById(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CarModelResponseModel> Update(long id, CarModelRequestModel entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<CarModelResponseModel>> Get(int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CarModelResponseModel> Delete(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}