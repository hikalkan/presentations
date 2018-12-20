using System;
using MultiTenancyDraft.Infrastructure;

namespace MultiTenancyDraft.Temporary
{
    public class TenantChangeDemo2
    {
        public void DoIt()
        {
            using (TenantInfo.Change(new TenantInfo(Guid.Parse("a745a68e-d316-4828-9373-a57afa295d85"))))
            {
                //TenantInfo.Current.Id is "a745a68e-d316-4828-9373-a57afa295d85"
                using (TenantInfo.Change(null))
                {
                    //TenantInfo.Current is null!
                }
                //TenantInfo.Current.Id is "a745a68e-d316-4828-9373-a57afa295d85"
            }
        }
    }
}