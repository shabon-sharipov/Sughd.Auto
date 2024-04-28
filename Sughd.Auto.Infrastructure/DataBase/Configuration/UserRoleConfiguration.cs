using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sughd.Auto.Application.Constants;
using Sughd.Auto.Domain.AuthModel;

namespace Sughd.Auto.Infrastructure.DataBase.Configuration;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.HasOne(r => r.Role).WithMany().HasForeignKey(r => r.RoleId);
        builder.HasOne(r => r.User).WithMany().HasForeignKey(r => r.UserId);
    }
}