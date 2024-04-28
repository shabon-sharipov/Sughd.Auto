using Sughd.Auto.Application.Exceptions;
using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Services;

public class FavoriteUserCarService : IFavoriteUserCarService
{
    private readonly IFavoriteUserCarRepository _favoriteUserCarRepository;
    private readonly IUserRepository _userRepository;
    private readonly ICarRepository _carRepository;

    public FavoriteUserCarService(IFavoriteUserCarRepository favoriteUserCarRepository, ICarRepository carRepository)
    {
        _favoriteUserCarRepository = favoriteUserCarRepository;
        _carRepository = carRepository;
    }

    public async Task<List<FavoriteUserCar>> GetByUserId(long userId)
    {
        var result = await _favoriteUserCarRepository.GetByUserId(userId);

        if (result == null)
        {
            throw new EntityNotFoundException($"Not found any favorite car, by UserId: {userId}");
        }

        return result;
    }

    public async Task Add(long userId, long carId)
    {
        try
        {
            if ((userId != null || userId != 0) && (carId != null || carId != 0))
            {
                await _favoriteUserCarRepository.AddAsync(new FavoriteUserCar() { CarId = carId, UserId = userId });
                await _favoriteUserCarRepository.SaveChangesAsync();
                return;
            }
        }
        catch (Exception e)
        {
            throw new EntityNotFoundException($"UserId: {userId} or CarId: {carId} incorrect");
        }
    }

    public async Task Delete(long userId, long carId)
    {
        var result = await _favoriteUserCarRepository.GetByUserIdAndCarId(userId, carId);

        if (result != null)
        {
            _favoriteUserCarRepository.Delete(result);
            await _favoriteUserCarRepository.SaveChangesAsync();
            return;
        }

        throw new EntityNotFoundException($"Not found favorite car, by UserID: {userId}, CarId: {carId}");
    }
}