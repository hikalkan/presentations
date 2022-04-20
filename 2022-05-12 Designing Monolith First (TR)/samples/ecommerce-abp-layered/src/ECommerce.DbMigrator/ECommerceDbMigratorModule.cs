using ECommerce.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ECommerce.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ECommerceEntityFrameworkCoreModule),
    typeof(ECommerceApplicationContractsModule)
    )]
public class ECommerceDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
