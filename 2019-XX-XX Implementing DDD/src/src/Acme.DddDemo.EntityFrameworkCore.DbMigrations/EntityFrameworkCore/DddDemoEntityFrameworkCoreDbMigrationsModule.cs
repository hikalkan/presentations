using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Acme.DddDemo.EntityFrameworkCore
{
    [DependsOn(
        typeof(DddDemoEntityFrameworkCoreModule)
        )]
    public class DddDemoEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<DddDemoMigrationsDbContext>();
        }
    }
}
