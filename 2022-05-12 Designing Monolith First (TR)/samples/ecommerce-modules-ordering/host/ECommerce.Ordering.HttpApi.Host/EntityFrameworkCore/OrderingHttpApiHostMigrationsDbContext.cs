using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ECommerce.Ordering.EntityFrameworkCore;

public class OrderingHttpApiHostMigrationsDbContext : AbpDbContext<OrderingHttpApiHostMigrationsDbContext>
{
    public OrderingHttpApiHostMigrationsDbContext(DbContextOptions<OrderingHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureOrdering();
    }
}
