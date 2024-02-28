namespace Sughd.Auto.Application.Interfaces;

public interface IBaseService<TRequest, TResponse>
{
    Task<TResponse> Create(TRequest entity, CancellationToken cancellationToken);

    Task<TResponse> GetById(ulong id, CancellationToken cancellationToken);

    Task<TResponse> Update(ulong id, TRequest entity, CancellationToken cancellationToken);

    Task<List<TResponse>> Get(int pageSize, int pageNumber, CancellationToken cancellationToken);

    Task<TResponse> Delete(ulong id, CancellationToken cancellationToken);
}