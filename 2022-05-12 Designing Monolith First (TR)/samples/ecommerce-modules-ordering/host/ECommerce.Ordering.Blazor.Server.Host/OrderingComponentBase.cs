using ECommerce.Ordering.Localization;
using Volo.Abp.AspNetCore.Components;

namespace ECommerce.Ordering.Blazor.Server.Host;

public abstract class OrderingComponentBase : AbpComponentBase
{
    protected OrderingComponentBase()
    {
        LocalizationResource = typeof(OrderingResource);
    }
}
