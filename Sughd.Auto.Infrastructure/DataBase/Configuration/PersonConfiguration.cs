using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sughd.Auto.Domain.Abstract;

namespace Sughd.Auto.Infrastructure.DataBase.Configuration;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("person");
        builder.HasKey(p => p.Id);
        builder.Property(c => c.Id)
            .HasColumnName("id").ValueGeneratedOnAdd();
    }
}