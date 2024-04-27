using Microsoft.EntityFrameworkCore;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Domain.Models;
using Sughd.Auto.Infrastructure.DataBase;

namespace Sughd.Auto.Infrastructure.Repositories;

public class FavoriteUserCarRepository : Repository<FavoriteUserCar>, IFavoriteUserCarRepository
{
    public FavoriteUserCarRepository(EFContext context) : base(context)
    {
    }

    public async Task<List<FavoriteUserCar>> GetByUserId(long userId)
    {
        var result = _dbSet.Where(u => u.UserId == userId);

        return await result.ToListAsync();
    }

    public async Task<FavoriteUserCar ?> GetByUserIdAndCarId(long userId, long carId)
    {
        var result = _dbSet.FirstOrDefault(u => u.UserId == userId && u.CarId == carId);

        return await Task.FromResult(result);
    }
}