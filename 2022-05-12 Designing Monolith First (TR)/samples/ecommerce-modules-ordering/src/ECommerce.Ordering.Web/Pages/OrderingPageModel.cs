using ECommerce.Ordering.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace ECommerce.Ordering.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class OrderingPageModel : AbpPageModel
{
    protected OrderingPageModel()
    {
        LocalizationResourceType = typeof(OrderingResource);
        ObjectMapperContext = typeof(OrderingWebModule);
    }
}
