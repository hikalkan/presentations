using Volo.Abp.Bundling;

namespace ECommerce.Customers.Blazor.Host;

public class CustomersBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
