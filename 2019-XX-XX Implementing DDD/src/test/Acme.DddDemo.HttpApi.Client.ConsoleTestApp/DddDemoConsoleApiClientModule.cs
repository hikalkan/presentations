using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Acme.DddDemo.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(DddDemoHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class DddDemoConsoleApiClientModule : AbpModule
    {
        
    }
}
