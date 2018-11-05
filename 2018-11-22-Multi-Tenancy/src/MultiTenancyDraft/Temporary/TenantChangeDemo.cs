using MultiTenancyDraft.Application;
using MultiTenancyDraft.Infrastructure;

namespace MultiTenancyDraft.Temporary
{
    public class TenantChangeDemo
    {
        public Tenant CreateNewTenant(string name)
        {
            var tenant = new Tenant(name);

            using (TenantInfo.Change(new TenantInfo(tenant.Id, tenant.Name)))
            {
                CreateAdminUser();
            }

            return tenant;
        }

        public void CreateAdminUser()
        {
            var admin = new User("admin", TenantInfo.Current?.Id);
            //SaveUser(admin)...
        }
    }
}
