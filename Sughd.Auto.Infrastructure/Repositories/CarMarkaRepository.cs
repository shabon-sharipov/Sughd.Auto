using Microsoft.EntityFrameworkCore;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Domain.Models;
using Sughd.Auto.Infrastructure.DataBase;

namespace Sughd.Auto.Infrastructure.Repositories;

public class CarMarkaRepository : Repository<Marka>, ICarMarkaRepository
{
    private readonly DbSet<Marka> _dbSet;
    private readonly EFContext _context;
    public CarMarkaRepository(EFContext context) : base(context)
    {
        _dbSet = context.Set<Marka>();
        _context = context;
    }

    public async Task<Marka> FindAsync(long id, CancellationToken cancellationToken = default)
    {
        var test = await _dbSet.FirstAsync(m=>m.Id == id, cancellationToken);

        return test;
    }
}