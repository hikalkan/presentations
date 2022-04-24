using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace ECommerce.Customers.MongoDB;

[ConnectionStringName(CustomersDbProperties.ConnectionStringName)]
public interface ICustomersMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
