using Localization.Resources.AbpUi;
using ECommerce.Customers.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Customers;

[DependsOn(
    typeof(CustomersApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class CustomersHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(CustomersHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<CustomersResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
