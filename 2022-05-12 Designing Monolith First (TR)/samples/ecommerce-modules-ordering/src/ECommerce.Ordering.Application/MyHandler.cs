using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace ECommerce.Ordering;

public class MyHandler :
    IDistributedEventHandler<OrderCanceledEto>,
    ITransientDependency
{
    public async Task HandleEventAsync(OrderCanceledEto eventData)
    {
        // TODO
    }
}