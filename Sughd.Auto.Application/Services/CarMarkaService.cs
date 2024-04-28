using AutoMapper;
using Sughd.Auto.Application.Exceptions;
using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Services;

public class CarMarkaService : ICarMarkaService
{
    private readonly ICarMarkaRepository _markaRepository;
    private readonly IMapper _mapper;
    
    public CarMarkaService(ICarMarkaRepository markaRepository, IMapper mapper)
    {
        _markaRepository = markaRepository;
        _mapper = mapper;
    }

    public async Task<CarMarkaResponsModel> Create(CarMarkaRequestModel entity, CancellationToken cancellationToken)
    {
        var marka = _mapper.Map<Marka>(entity);
        await _markaRepository.AddAsync(marka, cancellationToken);
        await _markaRepository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CarMarkaResponsModel>(marka);
    }

    public async Task<CarMarkaResponsModel> GetById(long id, CancellationToken cancellationToken)
    {
        var marka = await _markaRepository.FindAsync(id, cancellationToken);
       if (marka == null)
        {
            throw new EntityNotFoundException($"Not found marka, by Id: {id}");
        }
        
        return _mapper.Map<CarMarkaResponsModel>(marka);
    }

    public async Task<CarMarkaResponsModel> Update(long id, CarMarkaRequestModel entity, CancellationToken cancellationToken)
    {
        var marka = await _markaRepository.FindAsync(id, cancellationToken);
        if (marka == null)
        {
            throw new EntityNotFoundException($"Not found marka, by Id: {id}");
        }
        
        var result = _mapper.Map(entity, marka);
        await _markaRepository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CarMarkaResponsModel>(result);
    }

    public async Task<List<CarMarkaResponsModel>> Get(int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        var result = await _markaRepository.GetAllAsync(pageSize, pageNumber, cancellationToken);
        var marka = _mapper.Map<List<CarMarkaResponsModel>>(result);
        return marka;
    }

    public async Task<CarMarkaResponsModel> Delete(long id, CancellationToken cancellationToken)
    {
        var marka = await _markaRepository.FindAsync(id, cancellationToken);
        if (marka == null)
        {
            throw new EntityNotFoundException($"Not found marka, by Id: {id}");
        }
        
        _markaRepository.Delete(marka);
        await _markaRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<CarMarkaResponsModel>(marka);
    }
}