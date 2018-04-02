using System;
using MultiTenancyDraft.Infrastructure;

namespace MultiTenancyDraft.Temporary
{
    public class User : IMultiTenant
    {
        public string UserName { get; private set; }
        public Guid? TenantId { get; private set; }

        public User(string userName, Guid? tenantId = null)
        {
            UserName = userName;
            TenantId = tenantId;
        }
    }
}