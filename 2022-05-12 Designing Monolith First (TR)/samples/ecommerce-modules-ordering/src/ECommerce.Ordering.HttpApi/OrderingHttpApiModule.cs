using Localization.Resources.AbpUi;
using ECommerce.Ordering.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Ordering;

[DependsOn(
    typeof(OrderingApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class OrderingHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(OrderingHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<OrderingResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
