using Acme.DddDemo.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Acme.DddDemo
{
    [DependsOn(
        typeof(DddDemoEntityFrameworkCoreTestModule)
        )]
    public class DddDemoDomainTestModule : AbpModule
    {

    }
}