using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace ECommerce.Ordering;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(OrderingHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class OrderingConsoleApiClientModule : AbpModule
{

}
