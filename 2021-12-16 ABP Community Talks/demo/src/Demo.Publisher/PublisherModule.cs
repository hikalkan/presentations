using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Demo.Shared;
using Volo.Abp.EventBus.RabbitMq;
using Medallion.Threading;
using StackExchange.Redis;
using Medallion.Threading.Redis;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.EntityFrameworkCore.DistributedEvents;

namespace Demo.Publisher
{

    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule),
        typeof(SharedModule),
        typeof(AbpEventBusRabbitMqModule)
    )]
    public class PublisherModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var hostEnvironment = context.Services.GetSingletonInstance<IHostEnvironment>();

            context.Services.AddHostedService<PublisherHostedService>();

            context.Services.AddAbpDbContext<OrderDbContext>(options =>
            {
                options.AddDefaultRepositories();
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });

            /* USE REDIS AS THE DISTRIBUTED LOCK PROVIDER */
            context.Services.AddSingleton<IDistributedLockProvider>(sp =>
            {
                var connection = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
                return new RedisDistributedSynchronizationProvider(connection.GetDatabase());
            });

            /* CONFIGURE THE DBCONTEXT TO SUPPORT OUTBOX AND INBOX */
            Configure<AbpDistributedEventBusOptions>(options =>
            {
                options.Outboxes.Configure(config =>
                {
                    config.UseDbContext<OrderDbContext>();
                });

                options.Inboxes.Configure(config =>
                {
                    config.UseDbContext<OrderDbContext>();
                });
            });
        }
    }
}
