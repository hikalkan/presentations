using ECommerce.Ordering.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ECommerce.Ordering;

public abstract class OrderingController : AbpControllerBase
{
    protected OrderingController()
    {
        LocalizationResource = typeof(OrderingResource);
    }
}
