using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Domain.Models;
using Sughd.Auto.Infrastructure.DataBase;

namespace Sughd.Auto.Infrastructure.Repositories;

public class CarRepository : Repository<Car>, ICarRepository
{
    public CarRepository(EFContext context) : base(context)
    {
    }

    public async Task<List<Car>> Search(Dictionary<string, object> filter)
    {
        IQueryable<Car> query = _dbSet;

        // Build dynamic expression tree
        Expression<Func<Car, bool>> predicate = PredicateBuilder.True<Car>();
        foreach (var kvp in filter)
        {
            string propertyName = kvp.Key;
            object propertyValue = kvp.Value;

            // Check if the property exists in the Car entity
            if (typeof(Car).GetProperty(propertyName) != null)
            {
                // Create expression for property comparison
                var property = Expression.Property(Expression.Parameter(typeof(Car), "x"), propertyName);
                var value = Expression.Constant(propertyValue);
                var equals = Expression.Equal(property, value);
                var lambda = Expression.Lambda<Func<Car, bool>>(equals, Expression.Parameter(typeof(Car), "x"));

                // Combine expressions using AND
                predicate = predicate.And(lambda);
            }
        }

        // Apply filter using the combined predicate
        query = query.Where(predicate);

        return await query.ToListAsync();
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