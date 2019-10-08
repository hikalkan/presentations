using System;
using System.Threading.Tasks;
using SimpleEventBusUsage.Shared;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace SimpleEventBusUsage.Subscriber
{
    public class MyEventHandler : IDistributedEventHandler<StockCountChangedEvent>, ITransientDependency
    {
        public Task HandleEventAsync(StockCountChangedEvent eventData)
        {
            Console.WriteLine();
            Console.WriteLine("Stock count changed for the product: " + eventData.ProductId);
            Console.WriteLine("NEW COUNT: " + eventData.NewCount);

            return Task.CompletedTask;
        }
    }
}
