using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace ECommerce.Ordering;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(OrderingDomainSharedModule)
)]
public class OrderingDomainModule : AbpModule
{

}
