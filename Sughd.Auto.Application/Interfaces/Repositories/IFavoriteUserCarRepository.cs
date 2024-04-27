using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Application.Interfaces.Repositories;

public interface IFavoriteUserCarRepository : IRepository<FavoriteUserCar>
{
    Task<List<FavoriteUserCar>> GetByUserId(long userId);
    Task<FavoriteUserCar ?> GetByUserIdAndCarId(long userId, long carId);
}