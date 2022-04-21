using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace ECommerce.Customers;

[Dependency(ReplaceServices = true)]
public class CustomersBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Customers";
}
