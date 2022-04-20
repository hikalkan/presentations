using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ECommerce;

[Dependency(ReplaceServices = true)]
public class ECommerceBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ECommerce";
}
