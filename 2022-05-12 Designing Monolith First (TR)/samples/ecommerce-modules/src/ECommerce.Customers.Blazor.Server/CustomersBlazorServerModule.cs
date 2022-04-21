using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace ECommerce.Customers.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(CustomersBlazorModule)
    )]
public class CustomersBlazorServerModule : AbpModule
{

}
