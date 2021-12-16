using Demo.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace Demo.Publisher
{
    public class ReceivedOrderHandler : IDistributedEventHandler<ReceivedOrderEto>, ITransientDependency
    {
        public async Task HandleEventAsync(ReceivedOrderEto eventData)
        {
            Console.WriteLine();
            Console.WriteLine("*** RECEIVED ORDER ***");
            Console.WriteLine($"Product name : {eventData.ProductName}");
            Console.WriteLine();
        }
    }
}
