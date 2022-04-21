using Volo.Abp.Modularity;

namespace ECommerce.Customers;

[DependsOn(
    typeof(CustomersApplicationModule),
    typeof(CustomersDomainTestModule)
    )]
public class CustomersApplicationTestModule : AbpModule
{

}
