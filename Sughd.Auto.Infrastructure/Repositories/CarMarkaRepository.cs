﻿using Microsoft.EntityFrameworkCore;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Domain.Models;
using Sughd.Auto.Infrastructure.DataBase;

namespace Sughd.Auto.Infrastructure.Repositories;

public class CarMarkaRepository : RepositoryV2<Marka>, ICarMarkaRepository
{
    private readonly DbSet<Marka> _dbSet;
    private readonly EFContextV2 _context;
    public CarMarkaRepository(EFContextV2 context) : base(context)
    {
        _dbSet = context.Set<Marka>();
        _context = context;
    }

    public async Task<Marka> FindAsync(long id, CancellationToken cancellationToken = default)
    {
        var test = await _dbSet.FirstAsync(m=>m.Id == id, cancellationToken);

        return test;
    }

    public async Task<List<Marka>> SearchByMarkaName(string markaName)
    {
        var userNames = _dbSet.Where(m => m.Name.StartsWith(markaName));

        return (await userNames.ToListAsync())!;
    }
}