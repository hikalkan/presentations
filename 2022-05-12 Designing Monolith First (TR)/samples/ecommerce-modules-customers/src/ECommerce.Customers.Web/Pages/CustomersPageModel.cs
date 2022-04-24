using ECommerce.Customers.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace ECommerce.Customers.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class CustomersPageModel : AbpPageModel
{
    protected CustomersPageModel()
    {
        LocalizationResourceType = typeof(CustomersResource);
        ObjectMapperContext = typeof(CustomersWebModule);
    }
}
