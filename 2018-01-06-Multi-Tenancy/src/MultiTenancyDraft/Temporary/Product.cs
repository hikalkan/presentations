using System;
using MultiTenancyDraft.Infrastructure;

namespace MultiTenancyDraft.Temporary
{
    public class Product : IMultiTenant
    {
        public Guid Id { get; set; }

        public Guid? TenantId { get; set; }

        public string Name { get; set; }
    }
}