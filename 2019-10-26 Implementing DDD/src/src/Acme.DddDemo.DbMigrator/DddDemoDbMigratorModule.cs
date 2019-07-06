using Acme.DddDemo.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Acme.DddDemo.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(DddDemoEntityFrameworkCoreDbMigrationsModule),
        typeof(DddDemoApplicationContractsModule)
        )]
    public class DddDemoDbMigratorModule : AbpModule
    {
        
    }
}
