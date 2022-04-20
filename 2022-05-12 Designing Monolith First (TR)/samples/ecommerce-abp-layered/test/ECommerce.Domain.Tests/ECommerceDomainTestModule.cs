using ECommerce.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ECommerce;

[DependsOn(
    typeof(ECommerceEntityFrameworkCoreTestModule)
    )]
public class ECommerceDomainTestModule : AbpModule
{

}
