using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Services;

public class FavoriteUserCarService : IFavoriteUserCarService
{
    private readonly IFavoriteUserCarRepository _favoriteUserCarRepository;

    public FavoriteUserCarService(IFavoriteUserCarRepository favoriteUserCarRepository)
    {
        _favoriteUserCarRepository = favoriteUserCarRepository;
    }

    public async Task<List<FavoriteUserCar>> GetByUserId(long userId)
    {
        return await _favoriteUserCarRepository.GetByUserId(userId);
    }

    public async Task Add(long userId, long carId)
    {
        if ((userId != null || userId != 0) && (carId != null || carId != 0))
        {
            await _favoriteUserCarRepository.AddAsync(new FavoriteUserCar() { CarId = carId, UserId = userId });
            await _favoriteUserCarRepository.SaveChangesAsync();
            return;
        }
    
        throw new Exception("UserId or CarId incorrect");
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

        throw new Exception("Not found favorite care");
    }
}