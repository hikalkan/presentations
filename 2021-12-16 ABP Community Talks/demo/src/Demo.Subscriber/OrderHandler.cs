using Demo.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace Demo.Subscriber
{
    public class OrderHandler : IDistributedEventHandler<OrderPlacedEto>, ITransientDependency
    {
        public async Task HandleEventAsync(OrderPlacedEto eventData)
        {
            Console.WriteLine("*** ORDER PLACED ***");
            Console.WriteLine($"Product code : {eventData.ProductCode}");
            Console.WriteLine($"Product name : {eventData.ProductName}");
            Console.WriteLine($"Amount       : {eventData.Amount}");
            Console.WriteLine($"Total price  : {eventData.TotalPrice}");
        }
    }
}
