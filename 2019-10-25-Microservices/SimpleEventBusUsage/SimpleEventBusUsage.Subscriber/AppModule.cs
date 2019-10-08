using Volo.Abp.Autofac;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Modularity;

namespace SimpleEventBusUsage.Subscriber
{
    [DependsOn(
        typeof(AbpEventBusRabbitMqModule),
        typeof(AbpAutofacModule)
    )]
    public class AppModule : AbpModule
    {

    }
}