using ECommerce.Customers.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ECommerce.Customers;

public abstract class CustomersController : AbpControllerBase
{
    protected CustomersController()
    {
        LocalizationResource = typeof(CustomersResource);
    }
}
