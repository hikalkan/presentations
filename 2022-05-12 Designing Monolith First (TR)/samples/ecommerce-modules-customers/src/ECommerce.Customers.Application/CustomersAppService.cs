using ECommerce.Customers.Localization;
using Volo.Abp.Application.Services;

namespace ECommerce.Customers;

public abstract class CustomersAppService : ApplicationService
{
    protected CustomersAppService()
    {
        LocalizationResource = typeof(CustomersResource);
        ObjectMapperContext = typeof(CustomersApplicationModule);
    }
}
