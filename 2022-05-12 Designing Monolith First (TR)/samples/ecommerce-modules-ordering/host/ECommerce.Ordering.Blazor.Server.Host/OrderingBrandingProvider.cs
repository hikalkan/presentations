using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ECommerce.Ordering.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class OrderingBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Ordering";
}
