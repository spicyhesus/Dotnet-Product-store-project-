using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStore.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //relation many-to-many entre products et providers
            builder.HasMany(prod => prod.Providers)
                .WithMany(prov => prov.Products)
                .UsingEntity(j=>j.ToTable("Providings")); //renommer la table d'association
            //la relation one - to - many entre la class Product et Category
            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
