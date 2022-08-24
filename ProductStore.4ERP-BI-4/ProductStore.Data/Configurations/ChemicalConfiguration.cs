using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStore.Data.Configurations
{
    public class ChemicalConfiguration : IEntityTypeConfiguration<Chemical>
    {
        public void Configure(EntityTypeBuilder<Chemical> builder)
        {
            builder.OwnsOne(ch => ch.Address)
                .Property(ad => ad.City)
                .HasColumnName("MyCity").IsRequired();
            builder.OwnsOne(ch => ch.Address)
               .Property(ad => ad.StreetAddress)
               .HasColumnName("MyStreet").HasMaxLength(50);

            /*builder.OwnsOne(c => c.Address, myadd =>
            {
                myadd.Property(a =>
                a.StreetAddress).HasColumnName("MyStreet").HasMaxLength(50);
                myadd.Property(a => a.City).HasColumnName("MyCity").IsRequired();
            });*/
        }
    }
}
