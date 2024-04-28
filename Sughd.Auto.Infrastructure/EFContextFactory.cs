using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Sughd.Auto.Infrastructure.DataBase;

namespace Sughd.Auto.Infrastructure;

public class EFContextFactory : IDesignTimeDbContextFactory<EFContext>
{
    public EFContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EFContext>();
        optionsBuilder.UseSqlServer("Data Source=SQL6032.site4now.net;Initial Catalog=db_aa819e_sughdauto;User Id=db_aa819e_sughdauto_admin;Password=987094321_SH");

        return new EFContext(optionsBuilder.Options);
    }
}