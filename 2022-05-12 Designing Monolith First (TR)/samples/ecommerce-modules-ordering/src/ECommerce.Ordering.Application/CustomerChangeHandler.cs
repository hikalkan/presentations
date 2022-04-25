using System.Threading.Tasks;
using ECommerce.Customers;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus.Distributed;

namespace ECommerce.Ordering;

public class CustomerChangeHandler :
    IDistributedEventHandler<EntityUpdatedEto<CustomerEto>>,
    IDistributedEventHandler<EntityDeletedEto<CustomerEto>>,
    ITransientDependency
{
    public async Task HandleEventAsync(EntityUpdatedEto<CustomerEto> eventData)
    {
        // TODO: Implement customer update logic
    }

    public async Task HandleEventAsync(EntityDeletedEto<CustomerEto> eventData)
    {
        // TODO: Implement customer deletion logic
    }
}