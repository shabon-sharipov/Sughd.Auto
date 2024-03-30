using AutoMapper;
using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Services;

public class CarModelService : ICarModelService
{
    private readonly ICarModelRepository _modelRepository;
    private readonly IMapper _mapper;
    public CarModelService(ICarModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public async Task<CarModelResponseModel> Create(CarModelRequestModel entity, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<Model>(entity);
        await _modelRepository.AddAsync(model, cancellationToken);
        await _modelRepository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CarModelResponseModel>(model);
    }

    public async Task<CarModelResponseModel> GetById(long id, CancellationToken cancellationToken)
    {
        
        var model = await _modelRepository.FindAsync(id, cancellationToken);

        return _mapper.Map<CarModelResponseModel>(model);
    }

    public async Task<CarModelResponseModel> Update(long id, CarModelRequestModel entity, CancellationToken cancellationToken)
    {
        var model = await _modelRepository.FindAsync(id, cancellationToken);

        var result = _mapper.Map(entity, model);
        await _modelRepository.AddAsync(result, cancellationToken);
        await _modelRepository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CarModelResponseModel>(result);
    }

    public async Task<List<CarModelResponseModel>> Get(int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        var result = await _modelRepository.GetAllAsync(pageSize, pageNumber, cancellationToken);
        var models = _mapper.Map<List<CarModelResponseModel>>(result);
        return models;
    }

    public async Task<CarModelResponseModel> Delete(long id, CancellationToken cancellationToken)
    {
        var model = await _modelRepository.FindAsync(id, cancellationToken);
        _modelRepository.Delete(model);
        await _modelRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<CarModelResponseModel>(model);
    }
}