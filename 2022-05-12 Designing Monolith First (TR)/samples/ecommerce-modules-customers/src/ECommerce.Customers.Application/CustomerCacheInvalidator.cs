using System;
using System.Threading.Tasks;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;

namespace ECommerce.Customers;

public class CustomerCacheInvalidator :
    ILocalEventHandler<EntityChangedEventData<Customer>>,
    ITransientDependency
{
    private readonly IDistributedCache<CustomerDto, Guid> _cache;
    
    public async Task HandleEventAsync(EntityChangedEventData<Customer> eventData)
    {
        await _cache.RemoveAsync(eventData.Entity.Id);
    }
}