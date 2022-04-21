using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ECommerce.Customers.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class CustomersBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Customers";
}
