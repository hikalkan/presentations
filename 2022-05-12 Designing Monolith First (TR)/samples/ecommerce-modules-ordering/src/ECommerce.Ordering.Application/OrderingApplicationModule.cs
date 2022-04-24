using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using ECommerce.Customers;
using Volo.Abp.Caching;

namespace ECommerce.Ordering;

[DependsOn(
    typeof(OrderingDomainModule),
    typeof(OrderingApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule),
    typeof(CustomersApplicationContractsModule),
    typeof(AbpCachingModule)
    )]
public class OrderingApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<OrderingApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<OrderingApplicationModule>(validate: true);
        });
    }
}
