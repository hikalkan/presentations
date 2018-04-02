using System;
using MultiTenancyDraft.Infrastructure;

namespace MultiTenancyDraft.Application
{
    public class Product : IMultiTenant
    {
        public Guid Id { get; set; }

        public Guid? TenantId { get; private set; }

        public string Name { get; set; }

        protected Product()
        {
            
        }

        public Product(string name, Guid? tenantId = null)
        {
            Id = Guid.NewGuid();
            Name = name;
            TenantId = tenantId;
        }
    }
}