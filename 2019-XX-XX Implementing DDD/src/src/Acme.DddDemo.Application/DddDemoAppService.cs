using System;
using System.Collections.Generic;
using System.Text;
using Acme.DddDemo.Localization;
using Volo.Abp.Application.Services;

namespace Acme.DddDemo
{
    /* Inherit your application services from this class.
     */
    public abstract class DddDemoAppService : ApplicationService
    {
        protected DddDemoAppService()
        {
            LocalizationResource = typeof(DddDemoResource);
        }
    }
}
