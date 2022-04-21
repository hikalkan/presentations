using ECommerce.Customers.Localization;
using Volo.Abp.AspNetCore.Components;

namespace ECommerce.Customers.Blazor.Server.Host;

public abstract class CustomersComponentBase : AbpComponentBase
{
    protected CustomersComponentBase()
    {
        LocalizationResource = typeof(CustomersResource);
    }
}
