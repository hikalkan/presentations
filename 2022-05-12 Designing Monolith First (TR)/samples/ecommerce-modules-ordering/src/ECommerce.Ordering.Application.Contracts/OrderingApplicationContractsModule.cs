using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace ECommerce.Ordering;

[DependsOn(
    typeof(OrderingDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class OrderingApplicationContractsModule : AbpModule
{

}
