using Volo.Abp.Modularity;

namespace ECommerce;

[DependsOn(
    typeof(ECommerceApplicationModule),
    typeof(ECommerceDomainTestModule)
    )]
public class ECommerceApplicationTestModule : AbpModule
{

}
