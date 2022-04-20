using ECommerce.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ECommerce.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ECommerceController : AbpControllerBase
{
    protected ECommerceController()
    {
        LocalizationResource = typeof(ECommerceResource);
    }
}
