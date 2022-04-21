using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace ECommerce.Ordering.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(OrderingBlazorModule)
    )]
public class OrderingBlazorServerModule : AbpModule
{

}
