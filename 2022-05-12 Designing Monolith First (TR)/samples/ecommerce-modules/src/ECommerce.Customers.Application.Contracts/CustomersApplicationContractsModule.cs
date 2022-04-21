using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace ECommerce.Customers;

[DependsOn(
    typeof(CustomersDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class CustomersApplicationContractsModule : AbpModule
{

}
