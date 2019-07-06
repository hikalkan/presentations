using Acme.DddDemo.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.DddDemo.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class DddDemoController : AbpController
    {
        protected DddDemoController()
        {
            LocalizationResource = typeof(DddDemoResource);
        }
    }
}