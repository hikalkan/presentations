using System;
using Volo.Abp.Application.Dtos;

namespace ECommerce.Customers
{
    public class CustomerDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
