using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ECommerce.Customers.EntityFrameworkCore;

public class CustomersHttpApiHostMigrationsDbContext : AbpDbContext<CustomersHttpApiHostMigrationsDbContext>
{
    public CustomersHttpApiHostMigrationsDbContext(DbContextOptions<CustomersHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureCustomers();
    }
}
