using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Infrastructure.DataBase.Configuration;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.HasOne(c => c.CarBody)
            .WithMany()
            .HasForeignKey(c => c.CarBodyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Customer)
            .WithMany()
            .HasForeignKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Marka)
            .WithMany()
            .HasForeignKey(c => c.MarkaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Model)
            .WithMany()
            .HasForeignKey(c => c.ModelId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(c => c.Color)
            .WithMany()
            .HasForeignKey(c => c.ColorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}