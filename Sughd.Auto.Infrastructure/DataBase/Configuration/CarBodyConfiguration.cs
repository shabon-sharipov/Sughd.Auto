using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Infrastructure.DataBase.Configuration;

public class CarBodyConfiguration : IEntityTypeConfiguration<CarBody>
{
    public void Configure(EntityTypeBuilder<CarBody> builder)
    {
       builder.HasKey(x => x.Id);
    }
}