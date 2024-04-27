using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Interfaces;

public interface IFavoriteUserCarService
{
    Task<List<FavoriteUserCar>> GetByUserId(long userId);
    
    Task Add(long userId, long carId);
    Task Delete(long userId, long carId);
}