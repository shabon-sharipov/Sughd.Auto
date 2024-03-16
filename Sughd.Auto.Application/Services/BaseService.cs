using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Domain.Abstract;

namespace Sughd.Auto.Application.Services;

public abstract class BaseService<TEntity, TRequest, TResponse> : IBaseService<TEntity, TRequest, TResponse>
{
    //TODO: need Inject repositories
    // private readonly IRepository<TEntity> _repository;
    //
    // // private readonly IMapper _mapper;
    // protected BaseService(IRepository<TEntity> repository)
    // {
    //     _repository = repository;
    //     //_mapper = mapper;
    // }

    public virtual async Task<TResponse> Create(TRequest entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public virtual Task<TResponse> GetById(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public virtual Task<TResponse> Update(long id, TRequest entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public virtual Task<List<TResponse>> Get(int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public virtual Task<TResponse> Delete(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}