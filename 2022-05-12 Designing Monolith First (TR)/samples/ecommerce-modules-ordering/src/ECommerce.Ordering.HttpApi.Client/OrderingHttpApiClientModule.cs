using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ECommerce.Ordering;

[DependsOn(
    typeof(OrderingApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class OrderingHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(OrderingApplicationContractsModule).Assembly,
            OrderingRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<OrderingHttpApiClientModule>();
        });

    }
}
