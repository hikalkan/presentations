using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace ECommerce.Customers;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CustomersHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class CustomersConsoleApiClientModule : AbpModule
{

}
