using System;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace StoreApp.Infrastructure.Extensions;

public static class ApplicationExtension
{
    public static void ConfigureAndCheckMigrations(this IApplicationBuilder app)
    {
        RepositoryContext context = app
        .ApplicationServices
        .CreateScope()
        .ServiceProvider
        .GetRequiredService<RepositoryContext>();

        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }
    }

    public static void ConfigureLocalization(this IApplicationBuilder app)
    {
        app.UseRequestLocalization(options=>
        {
            options
            .AddSupportedCultures("tr-TR")
            .AddSupportedUICultures("tr-TR")
            .SetDefaultCulture("tr-TR");
        });
    }
}