using AutoMapper;
using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Services;

public class WorkerService : IWorkerService
{
    private readonly IWorkerRepository _workerRepository;
    private readonly IMapper _mapper;

    public WorkerService(IWorkerRepository workerRepository, IMapper mapper)
    {
        _workerRepository = workerRepository;
        _mapper = mapper;
    }

    public async Task<WorkerResponseModel> Create(WorkerRequestModel entity, CancellationToken cancellationToken)
    {
        var worker = _mapper.Map<Worker>(entity);
        await _workerRepository.AddAsync(worker, cancellationToken);
        await _workerRepository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<WorkerResponseModel>(worker);
    }

    public async Task<WorkerResponseModel> GetById(long id, CancellationToken cancellationToken)
    {
        var worker = await _workerRepository.FindAsync(id, cancellationToken);

        return _mapper.Map<WorkerResponseModel>(worker);
    }

    public async Task<WorkerResponseModel> Update(long id, WorkerRequestModel entity,
        CancellationToken cancellationToken)
    {
        var worker = await _workerRepository.FindAsync(id, cancellationToken);
        var result = _mapper.Map(entity, worker);

        await _workerRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<WorkerResponseModel>(result);
    }

    public async Task<List<WorkerResponseModel>> Get(int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        var worker = await _workerRepository.GetAllAsync(pageSize, pageNumber, cancellationToken);
        var workers = _mapper.Map<List<WorkerResponseModel>>(worker);
        return workers;
    }

    public async Task<WorkerResponseModel> Delete(long id, CancellationToken cancellationToken)
    {
        var worker = await _workerRepository.FindAsync(id, cancellationToken);

        _workerRepository.Delete(worker);
        await _workerRepository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<WorkerResponseModel>(worker);
    }
}