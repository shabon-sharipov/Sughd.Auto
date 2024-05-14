using Microsoft.EntityFrameworkCore;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Domain.Models;
using Sughd.Auto.Infrastructure.DataBase;

namespace Sughd.Auto.Infrastructure.Repositories;

public class TestRepository : Repository<Test>, ITestRepository
{
    public TestRepository(EFContext context) : base(context)
    {
    }

    public async Task<List<Test>> SearchByUserName(string text)
    {
        var tests = _dbSet.Where(u => u.Header.ToLower().Trim().StartsWith(text.ToLower().Trim()));
        return (await tests.ToListAsync())!;
    }
}