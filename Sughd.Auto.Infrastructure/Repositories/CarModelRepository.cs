using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Domain.Models;
using Sughd.Auto.Infrastructure.DataBase;

namespace Sughd.Auto.Infrastructure.Repositories;

public class CarModelRepository : Repository<Model>, ICarModelRepository
{
    public CarModelRepository(EFContext context) : base(context)
    {
    }
}