using Volo.Abp.Modularity;

namespace DemoApp
{
    [DependsOn(
        typeof(DemoAppApplicationModule),
        typeof(DemoAppDomainTestModule)
        )]
    public class DemoAppApplicationTestModule : AbpModule
    {

    }
}