using System;

namespace MultiTenancyDraft.Infrastructure
{
    public class TenantStore : ITenantStore
    {
        public string FindConnectionString(Guid tenantId)
        {
            using (TenantInfo.Change(null))
            {
                return null; //TODO: Get from a data source...
            }
        }
    }
}