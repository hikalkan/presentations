using System;
using System.Collections.Generic;
using System.Text;
using DemoApp.Localization;
using Volo.Abp.Application.Services;

namespace DemoApp
{
    /* Inherit your application services from this class.
     */
    public abstract class DemoAppAppService : ApplicationService
    {
        protected DemoAppAppService()
        {
            LocalizationResource = typeof(DemoAppResource);
        }
    }
}
