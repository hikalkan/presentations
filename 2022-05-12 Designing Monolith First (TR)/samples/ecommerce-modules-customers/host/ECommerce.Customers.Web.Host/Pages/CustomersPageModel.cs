using ECommerce.Customers.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace ECommerce.Customers.Pages;

public abstract class CustomersPageModel : AbpPageModel
{
    protected CustomersPageModel()
    {
        LocalizationResourceType = typeof(CustomersResource);
    }
}
