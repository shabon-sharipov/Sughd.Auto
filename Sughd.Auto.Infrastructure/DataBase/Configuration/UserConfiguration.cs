using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sughd.Auto.Application.Constants;
using Sughd.Auto.Domain.AuthModel;

namespace Sughd.Auto.Infrastructure.DataBase.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.HasMany(u => u.Roles)
            .WithMany(r => r.Users);
        
        builder.Property(c => c.UserName);
        builder.Property(c => c.Email);
        builder.Property(c => c.Password);
        builder.Property(c => c.PhoneNumber);
        builder.Property(c => c.RefreshToken);
    }
}