using Volo.Abp.Modularity;

namespace Acme.DddDemo
{
    [DependsOn(
        typeof(DddDemoApplicationModule),
        typeof(DddDemoDomainTestModule)
        )]
    public class DddDemoApplicationTestModule : AbpModule
    {

    }
}