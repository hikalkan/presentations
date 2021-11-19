using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Demo.Publisher
{
    public class Order : CreationAuditedAggregateRoot<Guid>
    {
        public string ProductCode { get; set; }
        public int Amount { get; set; }
        public float TotalPrice { get; set; }
    }
}