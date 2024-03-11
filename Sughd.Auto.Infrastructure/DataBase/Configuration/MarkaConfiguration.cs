﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sughd.Auto.Domain.Models;

namespace Sughd.Auto.Infrastructure.DataBase.Configuration;

public class MarkaConfiguration : IEntityTypeConfiguration<Marka>
{
    public void Configure(EntityTypeBuilder<Marka> builder)
    {
        builder.HasKey(m => m.Id);
        
        builder.Property(m => m.Name)
         .IsRequired();
        
        builder.HasMany(m => m.Model)
       .WithOne()
       .OnDelete(DeleteBehavior.Restrict);
    }
}