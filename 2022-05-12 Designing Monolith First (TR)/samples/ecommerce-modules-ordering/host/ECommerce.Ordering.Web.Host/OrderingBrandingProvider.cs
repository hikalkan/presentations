using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace ECommerce.Ordering;

[Dependency(ReplaceServices = true)]
public class OrderingBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Ordering";
}
