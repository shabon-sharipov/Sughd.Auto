using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sughd.Auto.Domain.AuthModel;

namespace Sughd.Auto.Infrastructure.DataBase.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.HasMany(r => r.Users)
            .WithMany(u => u.Roles);
    }
}