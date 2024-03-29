﻿using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.Models;
using AutoMapper;

namespace Sughd.Auto.Application.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public CarService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<CarResponseModel> Create(CarRequestModel entity, CancellationToken cancellationToken)
    {
        var car = _mapper.Map<Car>(entity);
        await _carRepository.AddAsync(car, cancellationToken);
        await _carRepository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CarResponseModel>(car);
    }

    public async Task<CarResponseModel> GetById(long id, CancellationToken cancellationToken)
    {
        var car = await _carRepository.FindAsync(id, cancellationToken);

        return _mapper.Map<CarResponseModel>(car);
    }

    public async Task<CarResponseModel> Update(long id, CarRequestModel entity, CancellationToken cancellationToken)
    {
        var car = await _carRepository.FindAsync(id, cancellationToken);

        var result = _mapper.Map(entity, car);
        await _carRepository.AddAsync(result, cancellationToken);
        await _carRepository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CarResponseModel>(result);
    }

    public async Task<List<CarResponseModel>> Get(int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        var result = await _carRepository.GetAllAsync(pageSize, pageNumber, cancellationToken);
        var car = _mapper.Map<List<CarResponseModel>>(result);
        return car;
    }

    public async Task<CarResponseModel> Delete(long id, CancellationToken cancellationToken)
    {
        var car = await _carRepository.FindAsync(id, cancellationToken);
        _carRepository.Delete(car);
        await _carRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<CarResponseModel>(car);
    }
}