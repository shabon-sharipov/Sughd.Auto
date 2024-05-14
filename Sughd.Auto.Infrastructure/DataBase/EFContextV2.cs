using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Sughd.Auto.Domain.Abstract;

namespace Sughd.Auto.Infrastructure.DataBase;

public class EFContextV2 : DbContext
{
    public EFContextV2(DbContextOptions<EFContextV2> dbContextOptions) : base(dbContextOptions)
    {
        Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=SQL6032.site4now.net;Initial Catalog=db_aa819e_sughdautov2;User Id=db_aa819e_sughdautov2_admin;Password=987094321_SH");
       base.OnConfiguring(optionsBuilder);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Ignore<EntityBase>();
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}