using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sughd.Auto.Domain.Abstract;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Infrastructure.DataBase;

public class EFContext : DbContext
{
    public EFContext(DbContextOptions<EFContext> dbContextOptions) : base(dbContextOptions)
    {
        Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=SQL6032.site4now.net;Initial Catalog=db_aa819e_sughdauto;User Id=db_aa819e_sughdauto_admin;Password=987094321_SH");
        base.OnConfiguring(optionsBuilder);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Ignore<EntityBase>();
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}