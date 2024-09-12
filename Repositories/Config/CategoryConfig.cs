using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired();

        builder.HasData(
            new Category() { Id = 1, Name = "Peripheral Device" },
            new Category() { Id = 2, Name = "Processor" },
            new Category() { Id = 3, Name = "Accessory" },
            new Category() { Id = 4, Name = "Graphic Card" },
            new Category() { Id = 5, Name = "Laptop" });
    }
}
