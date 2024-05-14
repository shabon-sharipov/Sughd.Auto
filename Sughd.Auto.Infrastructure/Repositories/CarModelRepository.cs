using Microsoft.EntityFrameworkCore;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Application.ResponseModels;
using Sughd.Auto.Domain.Models;
using Sughd.Auto.Infrastructure.DataBase;

namespace Sughd.Auto.Infrastructure.Repositories;

public class CarModelRepository : RepositoryV2<Model>, ICarModelRepository
{
    public CarModelRepository(EFContextV2 context) : base(context)
    {
    }
    
    public async Task<List<Model>> GetByMarkaId(long id)
    {
        var models = _dbSet.Where(m => m.MarkaId == id);

        return await models.ToListAsync();
    }
}