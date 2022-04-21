using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace ECommerce.Ordering.Blazor.WebAssembly;

[DependsOn(
    typeof(OrderingBlazorModule),
    typeof(OrderingHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class OrderingBlazorWebAssemblyModule : AbpModule
{

}
