using AutoMapper;
using Sughd.Auto.Application.Exceptions;
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
        if (model == null)
        {
            throw new EntityNotFoundException($"Not found model, by Id: {id}");
        }

        return _mapper.Map<CarModelResponseModel>(model);
    }

    public async Task<CarModelResponseModel> Update(long id, CarModelRequestModel entity, CancellationToken cancellationToken)
    {
        var model = await _modelRepository.FindAsync(id, cancellationToken);
        if (model == null)
        {
            throw new EntityNotFoundException($"Not found model, by Id: {id}");
        }
        
        var result = _mapper.Map(entity, model);
        await _modelRepository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CarModelResponseModel>(result);
    }

    public async Task<List<CarModelResponseModel>> Get(int pageSize, int pageNumber,
        CancellationToken cancellationToken)
    {
        var result = await _modelRepository.GetAllAsync(pageSize, pageNumber, cancellationToken);

        var models = new List<CarModelResponseModel>();

        foreach (var model in result.ToList())
        {
            models.Add(new CarModelResponseModel
            {
                Id = model.Id,
                Name = model.Name,
                MarkaId = model.MarkaId,
                MarkaName = model.Marka.Name
            });
        }
        
        return models;
    }

    public async Task<CarModelResponseModel> Delete(long id, CancellationToken cancellationToken)
    {
        var model = await _modelRepository.FindAsync(id, cancellationToken);
        if (model == null)
        {
            throw new EntityNotFoundException($"Not found model, by Id: {id}");
        }
        
        _modelRepository.Delete(model);
        await _modelRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<CarModelResponseModel>(model);
    }

    public async Task<List<CarModelResponseModel>> GetByMarkaId(long id)
    {
        var models = await _modelRepository.GetByMarkaId(id);
        if (models == null)
        {
            throw new EntityNotFoundException($"Not fount models when getting by MarkaId: {id}");
        }
        
        return _mapper.Map<List<CarModelResponseModel>>(models);
    }
}