using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.Models;
using AutoMapper;
using Sughd.Auto.Application.Exceptions;

namespace Sughd.Auto.Application.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public CarService(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<CarResponseModel> Create(CarRequestModel entity, CancellationToken cancellationToken)
    {
        var car = _mapper.Map<Car>(entity);
        car.IsActive = true;
        await _carRepository.AddAsync(car, cancellationToken);
        await _carRepository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CarResponseModel>(car);
    }

    public async Task<CarResponseModel> GetById(long id, CancellationToken cancellationToken)
    {
        var car = await _carRepository.FindAsync(id, cancellationToken);
        if (car == null)
        {
            throw new EntityNotFoundException($"Not found car, by {id}");
        }
        
        return _mapper.Map<CarResponseModel>(car);
    }

    public async Task<CarResponseModel> Update(long id, CarRequestModel entity, CancellationToken cancellationToken)
    {
        var car = await _carRepository.FindAsync(id, cancellationToken);
        if (car == null)
        {
            throw new EntityNotFoundException($"Not found car, by {id}");
        }
        
        var result = _mapper.Map(entity, car);
        car.UpdatedAt = DateTime.UtcNow.AddMinutes(300);
        await _carRepository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CarResponseModel>(result);
    }

    public async Task<List<CarResponseModel>> Get(int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        var result = await _carRepository.GetAllAsync(pageSize, pageNumber, cancellationToken);
        var car = _mapper.Map<List<CarResponseModel>>(result.ToList().Where(c => c.IsSold == false));
        return car;
    }
    
    public async Task<CarResponseModel> Delete(long id, CancellationToken cancellationToken)
    {
        var car = await _carRepository.FindAsync(id, cancellationToken);
        if (car == null)
        {
            throw new EntityNotFoundException($"Not found car, by {id}");
        }

        car.IsSold = true;
        car.DeletedAt = DateTime.UtcNow.AddMinutes(300);
        await _carRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<CarResponseModel>(car);
    }

    public async Task UpdateImage(long id, List<string> images)
    {
        var car = await _carRepository.FindAsync(id);
        if (car == null)
        {
            throw new EntityNotFoundException($"Not found car, by {id}");
        }

        car.Images = images;
        await _carRepository.SaveChangesAsync();
    }

    public async Task UpdateStatus(long id, bool isActive)
    {
        var car = await _carRepository.FindAsync(id);
        if (car == null)
        {
            throw new EntityNotFoundException($"Not found car, by {id}");
        }

        car.IsActive = isActive;
        await _carRepository.SaveChangesAsync();
    }

    public async Task UpdatePaymentAt(long carId)
    {
        var car = await _carRepository.FindAsync(carId);
        if (car == null)
        {
            throw new EntityNotFoundException($"Not found car, by {carId}");
        }

        car.PaymentAt = DateTime.UtcNow.AddMinutes(300);
        await _carRepository.SaveChangesAsync();
    }

    public Task<CarStatisticsResponseModel> GetStatistics()
    {
        return _carRepository.GetStatistics();
    }

    public async Task<CalculateCheckResponseModel> CalculateCheck(CalculateCheckRequestModel calculateCheckResponseModel)
    {
        return await _carRepository.CalculateCheck(calculateCheckResponseModel);
    }

    public Task<List<CarResponseModel>> GetAllForShowToUser(int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}