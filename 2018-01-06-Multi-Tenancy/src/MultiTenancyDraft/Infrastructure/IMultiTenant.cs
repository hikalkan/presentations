using System;

namespace MultiTenancyDraft.Infrastructure
{
    public interface IMultiTenant
    {
        Guid? TenantId { get; }
    }
}