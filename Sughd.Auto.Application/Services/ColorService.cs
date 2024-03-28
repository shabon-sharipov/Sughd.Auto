using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Services;

public class ColorService : IColorService
{
    public ColorService()
    {
    }

    public Task<ColorResponseModel> Create(ColorRequestModel entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ColorResponseModel> GetById(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ColorResponseModel> Update(long id, ColorRequestModel entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<ColorResponseModel>> Get(int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ColorResponseModel> Delete(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}