using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ECommerce.Customers;

[DependsOn(
    typeof(CustomersApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class CustomersHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(CustomersApplicationContractsModule).Assembly,
            CustomersRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CustomersHttpApiClientModule>();
        });

    }
}
