using System;
using Volo.Abp.Domain.Entities;

namespace ECommerce.Customers
{
    public class Customer : AggregateRoot<Guid>
    {
        public string Name { get; set; }
    }
}
