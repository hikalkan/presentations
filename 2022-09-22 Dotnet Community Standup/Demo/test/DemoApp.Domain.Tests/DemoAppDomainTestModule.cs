using DemoApp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace DemoApp
{
    [DependsOn(
        typeof(DemoAppEntityFrameworkCoreTestModule)
        )]
    public class DemoAppDomainTestModule : AbpModule
    {

    }
}