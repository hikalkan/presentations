using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace ECommerce.Customers.MongoDB;

[ConnectionStringName(CustomersDbProperties.ConnectionStringName)]
public class CustomersMongoDbContext : AbpMongoDbContext, ICustomersMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureCustomers();
    }
}
