using Microsoft.EntityFrameworkCore;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Domain.Models;
using Sughd.Auto.Infrastructure.DataBase;

namespace Sughd.Auto.Infrastructure.Repositories;

public class CarMarkaRepository : Repository<Marka>, ICarMarkaRepository
{
    //private readonly DbSet<Marka> _markas;
    //private readonly EFContext _context;

    public CarMarkaRepository(EFContext context) : base(context)
    {
        // _markas = context.Set<Marka>();
        // _context = context;
    }
}