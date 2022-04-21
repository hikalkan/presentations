using Volo.Abp.Modularity;

namespace ECommerce.Ordering;

[DependsOn(
    typeof(OrderingApplicationModule),
    typeof(OrderingDomainTestModule)
    )]
public class OrderingApplicationTestModule : AbpModule
{

}
