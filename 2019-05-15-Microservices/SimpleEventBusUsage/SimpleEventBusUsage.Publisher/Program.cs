using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;

namespace SimpleEventBusUsage.Publisher
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

                var demo = application.ServiceProvider.GetService<PublisherDemo>();

                demo.RunAsync().Wait();

                application.Shutdown();
            }
        }
    }
}
