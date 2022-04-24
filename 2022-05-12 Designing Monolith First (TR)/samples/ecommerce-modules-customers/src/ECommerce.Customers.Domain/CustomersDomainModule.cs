using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace ECommerce.Customers;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(CustomersDomainSharedModule)
)]
public class CustomersDomainModule : AbpModule
{

}
