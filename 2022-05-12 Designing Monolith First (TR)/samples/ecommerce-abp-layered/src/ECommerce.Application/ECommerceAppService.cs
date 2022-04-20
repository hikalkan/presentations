using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Localization;
using Volo.Abp.Application.Services;

namespace ECommerce;

/* Inherit your application services from this class.
 */
public abstract class ECommerceAppService : ApplicationService
{
    protected ECommerceAppService()
    {
        LocalizationResource = typeof(ECommerceResource);
    }
}
