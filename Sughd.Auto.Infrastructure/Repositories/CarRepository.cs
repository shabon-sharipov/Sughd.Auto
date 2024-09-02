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
                                     && (searchCarRequestModel.MarkaId == null ||
                                         c.MarkaId == searchCarRequestModel.MarkaId)
                                     && ((searchCarRequestModel.DateOfPublisherFrom == null ||
                                          c.DateOfPublisher >= searchCarRequestModel.DateOfPublisherFrom) &&
                                         (searchCarRequestModel.DateOfPublisherTo == null ||
                                          c.DateOfPublisher <= searchCarRequestModel.DateOfPublisherTo)));
        return await cars.ToListAsync();
    }

    public async Task<List<Car>> GetAllAsync(int pageSize, int PageNumber, CancellationToken cancellationToken)
    {
        var cars = _dbSet.Where(c => !c.IsSold).Skip(pageSize * PageNumber)
            .Take(pageSize);

        return await cars.ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IQueryable<Car>> GetCarsIfIsActive(int pageSize, int pageNumber)
    {
        return _dbSet.Where(c => c.IsActive)
            .Skip(pageSize * pageNumber)
            .Take(pageSize);
    }

    public async Task<CarStatisticsResponseModel> GetStatistics()
    {
        var startDatTime = DateTime.UtcNow.AddDays(-6).Date;
        var isActiveTotal = await _dbSet.CountAsync(c => c.IsActive && !c.IsSold);
        var isNotActiveTotal = await _dbSet.CountAsync(c => !c.IsActive && !c.IsSold);
        var isSoldTotal = await _dbSet.CountAsync(c => c.IsSold);

        var weeklyData = await _dbSet
            .Where(c => c.CreatedAt >= startDatTime)
            .GroupBy(c => new {c.CreatedAt.Date })
            .Select(group => new StatisticsByDay()
            {
                DaywhisMounth = group.Key.Date,
                Count = group.Count()
            })
            .OrderBy(c=>c.DaywhisMounth)
            .ToListAsync();

        return new CarStatisticsResponseModel()
        {
            ActiveCar = weeklyData,
            TotalCarCount = new double[] { isActiveTotal, isNotActiveTotal, isSoldTotal }
        };
    }

    public Task UpdatePaymentAt(long carId)
    {
        throw new NotImplementedException();
    }

    public async Task<CalculateCheckResponseModel> CalculateCheck(CalculateCheckRequestModel calculateCheckResponseModel)
    {
        var car = await _dbSet.FirstAsync(c=>c.CalculateCheck == calculateCheckResponseModel.CarId);
        var carCreationDate = car.PaymentAt;
        var currentDate = DateTime.UtcNow.Date;
        
        var weekdays = Enumerable.Range(0, (currentDate - carCreationDate).Days + 1)
            .Count(offset => (carCreationDate + TimeSpan.FromDays(offset)).DayOfWeek >= DayOfWeek.Monday &&
                             (carCreationDate + TimeSpan.FromDays(offset)).DayOfWeek <= DayOfWeek.Friday);

        var weekends = Enumerable.Range(0, (currentDate - carCreationDate).Days + 1)
            .Count(offset => (carCreationDate + TimeSpan.FromDays(offset)).DayOfWeek == DayOfWeek.Saturday ||
                             (carCreationDate + TimeSpan.FromDays(offset)).DayOfWeek == DayOfWeek.Sunday);

        return new CalculateCheckResponseModel()
        {
            UserPhoneNumber = car.UserPhoneNumber,
            WeeklyDayCount = weekdays,
            WeeklyDayPrice = weekdays * calculateCheckResponseModel.WeeklyDayPrice,
            WeeklyEndCount = weekends,
            WeeklyEndPrice = weekends * calculateCheckResponseModel.WeeklyEndPrice,
            DateTime = currentDate.ToString(),
        };
    }
}