using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace ECommerce.Customers.Blazor.WebAssembly;

[DependsOn(
    typeof(CustomersBlazorModule),
    typeof(CustomersHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class CustomersBlazorWebAssemblyModule : AbpModule
{

}
