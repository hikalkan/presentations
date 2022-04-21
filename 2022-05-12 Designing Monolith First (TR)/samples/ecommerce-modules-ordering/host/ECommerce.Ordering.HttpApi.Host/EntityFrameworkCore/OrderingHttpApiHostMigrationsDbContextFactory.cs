using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Ordering.EntityFrameworkCore;

public class OrderingHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<OrderingHttpApiHostMigrationsDbContext>
{
    public OrderingHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<OrderingHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Ordering"));

        return new OrderingHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
