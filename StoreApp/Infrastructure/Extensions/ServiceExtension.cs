using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Repositories.Repos;
using Services.Contracts;
using Services.Managers;
using StoreApp.Models;

namespace StoreApp.Infrastructure.Extensions;

public static class ServiceExtension
{
    static readonly string connString = Environment.GetEnvironmentVariable("DefaultConnection") ?? string.Empty;

    public static void ConfigureDbContext(this IServiceCollection services)
    {
        services.AddDbContext<RepositoryContext>(options =>
        {
            options.UseSqlite(connString, b => b.MigrationsAssembly("StoreApp"));
        });
    }

    public static void ConfigureSession(this IServiceCollection services)
    {
        services.AddDistributedMemoryCache();

        services.AddSession(options =>
        {
            options.Cookie.Name = "StoreApp.Session";
            options.IdleTimeout = TimeSpan.FromMinutes(20);
        });

        services.AddScoped<Cart>(c => SessionCart.GetCart(c));
    }

    public static void ConfigureRepoReg(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddScoped<IRepositoryManager, RepositoryManager>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
    }

    public static void ConfigureServiceReg(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>();
        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<IOrderService, OrderManager>();
    }
}