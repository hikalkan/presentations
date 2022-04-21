using ECommerce.Ordering.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ECommerce.Ordering;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(OrderingEntityFrameworkCoreTestModule)
    )]
public class OrderingDomainTestModule : AbpModule
{

}
