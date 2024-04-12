using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Application.RequestModels;
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
                                     && (searchCarRequestModel.FuelType == null ||
                                         c.FuelType == searchCarRequestModel.FuelType)
                                     && (searchCarRequestModel.CarBody == null ||
                                         c.CarBody == searchCarRequestModel.CarBody)
                                     && (searchCarRequestModel.ModelId == null ||
                                         c.ModelId == searchCarRequestModel.ModelId)
                                     && (searchCarRequestModel.Transmission == null ||
                                         c.Transmission == searchCarRequestModel.Transmission)
                                     && (searchCarRequestModel.IsRastamogeno == null ||
                                         c.IsRastamogeno == searchCarRequestModel.IsRastamogeno)
                                     && (searchCarRequestModel.DateOfPablisher == null ||
                                         c.DateOfPablisher == searchCarRequestModel.DateOfPablisher)
                                     && (searchCarRequestModel.MarkaId == null ||
                                         c.MarkaId == searchCarRequestModel.MarkaId)
                                     && (searchCarRequestModel.Color == null || c.Color == searchCarRequestModel.Color)
                                     && (searchCarRequestModel.PriceFrom == null ||
                                         c.Price >= searchCarRequestModel.PriceFrom));

        return await cars.ToListAsync();
    }
}

public static class PredicateBuilder
{
    public static Expression<Func<T, bool>> True<T>()
    {
        return f => true;
    }

    public static Expression<Func<T, bool>> False<T>()
    {
        return f => false;
    }

    public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
        Expression<Func<T, bool>> expr2)
    {
        var invokedExpr = Expression.Invoke(expr2, expr1.Parameters);
        return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
    }
}