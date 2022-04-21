using ECommerce.Ordering.Localization;
using Volo.Abp.Application.Services;

namespace ECommerce.Ordering;

public abstract class OrderingAppService : ApplicationService
{
    protected OrderingAppService()
    {
        LocalizationResource = typeof(OrderingResource);
        ObjectMapperContext = typeof(OrderingApplicationModule);
    }
}
