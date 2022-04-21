using ECommerce.Ordering.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace ECommerce.Ordering.Pages;

public abstract class OrderingPageModel : AbpPageModel
{
    protected OrderingPageModel()
    {
        LocalizationResourceType = typeof(OrderingResource);
    }
}
