using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ECommerce.Customers.EntityFrameworkCore;

[ConnectionStringName(CustomersDbProperties.ConnectionStringName)]
public class CustomersDbContext : AbpDbContext<CustomersDbContext>, ICustomersDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public CustomersDbContext(DbContextOptions<CustomersDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureCustomers();
    }
}
