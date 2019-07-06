using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Acme.DddDemo.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.DddDemo.Web.Pages
{
    /* Inherit your UI Pages from this class. To do that, add this line to your Pages (.cshtml files under the Page folder):
     * @inherits Acme.DddDemo.Web.Pages.DddDemoPage
     */
    public abstract class DddDemoPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<DddDemoResource> L { get; set; }
    }
}
