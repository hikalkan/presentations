using System;
using System.Threading.Tasks;
using SimpleEventBusUsage.Shared;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace SimpleEventBusUsage.Publisher
{
    public class PublisherDemo : ITransientDependency
    {
        public PublisherDemo()
        {
        }

        public async Task RunAsync()
        {
            Console.WriteLine("************* STARTED the PUBLISHER *************");
            Console.WriteLine();

            var productId = Guid.NewGuid();

            while (true)
            {
                Console.Write("Enter the new stock count: ");

                var newCount = Console.ReadLine();

                if (newCount.IsNullOrWhiteSpace())
                {
                    break;
                }

                //TODO: PUBLISH THE EVENT!!!
            }
        }
    }
}
