using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace ECommerce.Ordering.MongoDB;

[ConnectionStringName(OrderingDbProperties.ConnectionStringName)]
public class OrderingMongoDbContext : AbpMongoDbContext, IOrderingMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureOrdering();
    }
}
