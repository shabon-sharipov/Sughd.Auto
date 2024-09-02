using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Sughd.Auto.Infrastructure.DataBase;

namespace Sughd.Auto.Infrastructure;

public class EFContextFactory : IDesignTimeDbContextFactory<EFContext>
{
    public EFContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EFContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Sughd.Auto1;Username=postgres;Password=4321");
   
        return new EFContext(optionsBuilder.Options);
    }
}
