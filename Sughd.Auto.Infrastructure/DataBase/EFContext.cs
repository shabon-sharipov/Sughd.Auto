using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Sughd.Auto.Domain.Abstract;

namespace Sughd.Auto.Infrastructure.DataBase;

public class EFContext : DbContext
{
    public EFContext(DbContextOptions<EFContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=SughdAuto;Username=postgres;Password=4321");
        base.OnConfiguring(optionsBuilder);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Ignore<EntityBase>();
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}