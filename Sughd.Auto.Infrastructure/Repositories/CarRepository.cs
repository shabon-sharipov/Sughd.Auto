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
                                     && ((searchCarRequestModel.PriceFrom == null ||
                                         c.Price >= searchCarRequestModel.PriceFrom) && 
                                         (searchCarRequestModel.PriceTo == null ||
                                         c.Price <= searchCarRequestModel.PriceTo) ));

        return await cars.ToListAsync();
    }

    public async Task<IQueryable<Car>> GetCarsIfIsActive(int pageSize, int pageNumber)
    {
        return _dbSet.Where(c => c.IsActive)
            .Skip(pageSize * pageNumber)
            .Take(pageSize);
    }
}