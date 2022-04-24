using System;
using System.Threading.Tasks;
using ECommerce.Customers;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;

namespace ECommerce.Ordering;

public class OrderAppService : ApplicationService, IOrderAppService
{
    private readonly ICustomerAppService _customerAppService;
    private readonly IDistributedCache<CustomerDto, Guid> _cache;

    public OrderAppService(
        ICustomerAppService customerAppService,
        IDistributedCache<CustomerDto, Guid> cache)
    {
        _customerAppService = customerAppService;
        _cache = cache;
    }
    
    public async Task CreateAsync(OrderCreationDto input)
    {
        var customer = await _cache.GetOrAddAsync(
            input.CustomerId,
            () => _customerAppService.GetAsync(input.CustomerId)
        );
        // TODO: ...
    }
}