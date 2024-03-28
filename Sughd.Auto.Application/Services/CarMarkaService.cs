using AutoMapper;
using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Services;

public class CarMarkaService : ICarMarkaService
{
    public CarMarkaService()
    {
    }

    public Task<CarMarkaResponsModel> Create(CarMarkaRequestModel entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CarMarkaResponsModel> GetById(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CarMarkaResponsModel> Update(long id, CarMarkaRequestModel entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<CarMarkaResponsModel>> Get(int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CarMarkaResponsModel> Delete(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}