using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ECommerce.Customers.EntityFrameworkCore;

[ConnectionStringName(CustomersDbProperties.ConnectionStringName)]
public interface ICustomersDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
