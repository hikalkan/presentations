using Acme.DddDemo.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.DddDemo.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class DddDemoPageModel : AbpPageModel
    {
        protected DddDemoPageModel()
        {
            LocalizationResourceType = typeof(DddDemoResource);
        }
    }
}