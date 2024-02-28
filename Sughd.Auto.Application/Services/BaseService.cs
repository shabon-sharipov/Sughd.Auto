using Sughd.Auto.Application.Interfaces;

namespace Sughd.Auto.Application.Services;

public abstract class BaseService<TRequest, TResponse> : IBaseService<TRequest, TResponse>
{
    public virtual async Task<TResponse> Create(TRequest entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public virtual Task<TResponse> GetById(ulong id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public virtual Task<TResponse> Update(ulong id, TRequest entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public virtual Task<List<TResponse>> Get(int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public virtual Task<TResponse> Delete(ulong id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}