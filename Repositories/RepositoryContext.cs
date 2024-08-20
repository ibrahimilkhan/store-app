using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasData(
            new Product() { Id = 1, Name = "Computer", Price = 27000 },
            new Product() { Id = 2, Name = "Keyboard", Price = 2700 },
            new Product() { Id = 3, Name = "Mouse", Price = 990 },
            new Product() { Id = 4, Name = "Monitor", Price = 6900 }
        );

        modelBuilder.Entity<Category>().HasData(
            new Category() { Id = 1, Name = "Peripheral Devices" },
            new Category() { Id = 2, Name = "Processors" },
            new Category() { Id = 3, Name = "Accessories" },
            new Category() { Id = 4, Name = "Graphic Cards" });
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}