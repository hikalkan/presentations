using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace ECommerce.Web;

[Dependency(ReplaceServices = true)]
public class ECommerceBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ECommerce";
}
