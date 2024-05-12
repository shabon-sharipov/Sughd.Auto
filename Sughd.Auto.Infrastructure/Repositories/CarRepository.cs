using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Application.RequestModels;
using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.Models;
using Sughd.Auto.Infrastructure.DataBase;

namespace Sughd.Auto.Infrastructure.Repositories;

public class CarRepository : Repository<Car>, ICarRepository
{
    public CarRepository(EFContext context) : base(context)
    {
    }

    public async Task<List<Car>> Search(SearchCarRequestModel searchCarRequestModel)
    {
        var cars = _dbSet.Where(c => c.IsActive == true
                                     && c.IsSold == false
                                     && (searchCarRequestModel.ModelId == null ||
                                         c.ModelId == searchCarRequestModel.ModelId)
                                     && ((searchCarRequestModel.DateOfPublisherFrom == null ||
                                          c.DateOfPublisher >= searchCarRequestModel.DateOfPublisherFrom) &&
                                         (searchCarRequestModel.DateOfPublisherTo == null ||
                                          c.DateOfPublisher >= searchCarRequestModel.DateOfPublisherTo))
                                     && (searchCarRequestModel.MarkaId == null ||
                                         c.MarkaId == searchCarRequestModel.MarkaId));
        return await cars.ToListAsync();
    }

    public async Task<IQueryable<Car>> GetCarsIfIsActive(int pageSize, int pageNumber)
    {
        return _dbSet.Where(c => c.IsActive)
            .Skip(pageSize * pageNumber)
            .Take(pageSize);
    }

    public async Task<CarStatisticsResponseModel> GetStatistics()
    {
        var startDatTime = DateTime.UtcNow.AddMinutes(300).AddDays(-6);
        var isActiveTotal = await _dbSet.CountAsync(c => c.IsActive && !c.IsSold);
        var isNotActiveTotal = await _dbSet.CountAsync(c => !c.IsActive && !c.IsSold);
        var isSoldTotal = await _dbSet.CountAsync(c => c.IsSold);

        var weeklyData = await _dbSet
            .Where(c => c.UpdatedAt >= startDatTime)
            .GroupBy(c => new { c.IsActive, c.IsSold, c.UpdatedAt.Date })
            .Select(group => new
            {
                IsSold = group.Key.IsSold,
                IsActive = group.Key.IsActive,
                Date = group.Key.Date,
                Count = group.Count()
            })
            .ToListAsync();

        var activeWeekly = weeklyData
            .Where(d => d.IsActive && !d.IsSold)
            .Select(d => new StatisticsByDay()
            {
                Count = d.Count,
                DaywhisMounth= $"{d.Date.Day}.{d.Date.Month}"
            }).ToList();

        var inactiveWeekly = weeklyData
            .Where(d => !d.IsActive && !d.IsSold)
            .Select(d => new StatisticsByDay()
            {
                Count = d.Count,
                DaywhisMounth = $"{d.Date.Day}.{d.Date.Month}"
            }).ToList();

        var soldWeekly = weeklyData
            .Where(d => d.IsSold)
            .Select(d => new StatisticsByDay()
            {
                Count = d.Count,
                DaywhisMounth = $"{d.Date.Day}.{d.Date.Month}"
            }).ToList();

        return new CarStatisticsResponseModel()
        {
            ActiveCar = activeWeekly,
            InActive = inactiveWeekly,
            SoldCar = soldWeekly,
            TotalCarCount = new double[] { isActiveTotal, isNotActiveTotal, isSoldTotal }
        };
    }
}