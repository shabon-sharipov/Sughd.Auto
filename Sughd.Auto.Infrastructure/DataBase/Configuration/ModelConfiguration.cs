using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Model = Sughd.Auto.Domain.Models.Model;

namespace Sughd.Auto.Infrastructure.DataBase.Configuration;

public class ModelConfiguration : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.HasOne(m => m.Marka)
            .WithMany()
            .HasForeignKey(m => m.MarkaId);
    }
}