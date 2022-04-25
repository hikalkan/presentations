using Volo.Abp.Domain;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.Modularity;

namespace ECommerce.Customers;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(CustomersDomainSharedModule)
)]
public class CustomersDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDistributedEntityEventOptions>(options =>
        {
            options.AutoEventSelectors.Add<Customer>();
            options.EtoMappings.Add<Customer, CustomerEto>();
        });
    }
}
