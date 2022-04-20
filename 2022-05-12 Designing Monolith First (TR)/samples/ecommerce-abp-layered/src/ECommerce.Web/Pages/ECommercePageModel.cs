using ECommerce.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace ECommerce.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class ECommercePageModel : AbpPageModel
{
    protected ECommercePageModel()
    {
        LocalizationResourceType = typeof(ECommerceResource);
    }
}
