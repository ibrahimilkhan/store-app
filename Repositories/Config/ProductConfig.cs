using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Price).IsRequired();

        builder.HasData(
            new Product() { Id = 1, CategoryId = 1, Name = "Razer BlackWidow V3 Mini", Price = 3990 },
            new Product() { Id = 2, CategoryId = 1, Name = "Logitech G305", Price = 1399 },
            new Product() { Id = 3, CategoryId = 1, Name = "BenQ Zowie XL2566K", Price = 6900 },
            new Product() { Id = 4, CategoryId = 2, Name = "i7-13700k", Price = 15699 },
            new Product() { Id = 5, CategoryId = 4, Name = "RTX 4060", Price = 13615 },
            new Product() { Id = 6, CategoryId = 5, Name = "Thinkpad X1 Carbon G11", Price = 68790 }
        );
    }
}
