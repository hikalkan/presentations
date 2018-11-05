using System;

namespace MultiTenancyDraft.Infrastructure
{
    public interface ITenantStore
    {
        string FindConnectionString(Guid tenantId);
    }
}