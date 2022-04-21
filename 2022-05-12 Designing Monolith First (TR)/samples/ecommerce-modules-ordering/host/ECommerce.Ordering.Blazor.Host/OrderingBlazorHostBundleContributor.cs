using Volo.Abp.Bundling;

namespace ECommerce.Ordering.Blazor.Host;

public class OrderingBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
