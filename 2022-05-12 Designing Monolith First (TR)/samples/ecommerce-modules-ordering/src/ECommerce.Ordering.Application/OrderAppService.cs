using System;
using System.Threading.Tasks;
using ECommerce.Customers;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus.Distributed;

namespace ECommerce.Ordering;

public class OrderAppService : ApplicationService, IOrderAppService
{
    private readonly ICustomerAppService _customerAppService;
    private readonly IDistributedCache<CustomerDto, Guid> _cache;
    private readonly IRepository<Order, Guid> _orderRepository;
    private readonly IDistributedEventBus _distributedEventBus;

    public OrderAppService(
        ICustomerAppService customerAppService,
        IDistributedCache<CustomerDto, Guid> cache, 
        IRepository<Order, Guid> orderRepository,
        IDistributedEventBus distributedEventBus)
    {
        _customerAppService = customerAppService;
        _cache = cache;
        _orderRepository = orderRepository;
        _distributedEventBus = distributedEventBus;
    }
    
    public async Task CreateAsync(OrderCreationDto input)
    {
        var customer = await _cache.GetOrAddAsync(
            input.CustomerId,
            () => _customerAppService.GetAsync(input.CustomerId)
        );
        // TODO: ...
    }

    public async Task CancelAsync(Guid id)
    {
        var order = await _orderRepository.GetAsync(id);
        order.Cancel(); // order.IsCanceled = true;
        await _orderRepository.UpdateAsync(order);
    }
}