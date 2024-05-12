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
        
        builder.Property(c => c.DateOfPublisher);
        builder.Property(c => c.IsActive);
        builder.Property(c => c.UserPhoneNumber);
    }
}