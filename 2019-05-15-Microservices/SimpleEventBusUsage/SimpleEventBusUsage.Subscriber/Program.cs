using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.EventBus.Distributed;

namespace SimpleEventBusUsage.Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var application = AbpApplicationFactory.Create<AppModule>(options =>
            {
                options.UseAutofac();
            }))
            {
                application.Initialize();

                application.ServiceProvider.GetRequiredService<IDistributedEventBus>(); //TODO: Workaround, remove after ABP v0.15

                Console.WriteLine("************* STARTED the SUBSCRIBER *************");
                Console.WriteLine("Press ENTER to stop application...");
                Console.ReadLine();

                application.Shutdown();
            }
        }
    }
}
