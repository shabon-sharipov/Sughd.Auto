using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Infrastructure.DataBase.Configuration;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("cars");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.HasOne(c => c.Marka)
            .WithMany()
            .HasForeignKey(c => c.MarkaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Model)
            .WithMany()
            .HasForeignKey(c => c.ModelId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(c => c.User)
            .WithMany()
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(c => c.VINCode);
        builder.Property(c => c.DateOfPablisher);
        builder.Property(c => c.Price);
        builder.Property(c => c.EngineCapacity);
        builder.Property(c => c.IsRastamogeno);
        builder.Property(c => c.IsActive);
        builder.Property(c => c.CarNumber);
        builder.Property(c => c.FuelType);
        builder.Property(c => c.Transmission);
        builder.Property(c => c.CarBody);
        builder.Property(c => c.Color);
    }
}