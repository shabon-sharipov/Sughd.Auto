using Microsoft.EntityFrameworkCore;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Domain.Models;
using Sughd.Auto.Infrastructure.DataBase;

namespace Sughd.Auto.Infrastructure.Repositories;

public class CarMarkaRepository : Repository<Marka>, ICarMarkaRepository
{
    public CarMarkaRepository(EFContext context) : base(context)
    {
    }
}