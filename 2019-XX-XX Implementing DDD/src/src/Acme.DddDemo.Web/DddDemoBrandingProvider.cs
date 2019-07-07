using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace Acme.DddDemo.Web
{
    [Dependency(ReplaceServices = true)]
    public class DddDemoBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "DddDemo";
    }
}
