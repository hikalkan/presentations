using System;
using Volo.Abp.Domain.Entities;

namespace ECommerce.Ordering;

public class Order : AggregateRoot<Guid>
{
    public bool IsCanceled { get; private set; }
    
    public void Cancel()
    {
        if (IsCanceled)
        {
            return;
        }
        
        IsCanceled = true;
        
        AddDistributedEvent(
            new OrderCanceledEto { Id = Id }
        );
    }
}