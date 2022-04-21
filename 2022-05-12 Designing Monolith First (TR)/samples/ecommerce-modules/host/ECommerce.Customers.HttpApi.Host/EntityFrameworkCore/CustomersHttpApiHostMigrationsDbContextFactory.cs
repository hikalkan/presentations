using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Customers.EntityFrameworkCore;

public class CustomersHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<CustomersHttpApiHostMigrationsDbContext>
{
    public CustomersHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<CustomersHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Customers"));

        return new CustomersHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
