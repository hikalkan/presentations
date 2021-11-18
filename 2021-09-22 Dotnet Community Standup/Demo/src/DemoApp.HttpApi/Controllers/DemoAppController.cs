using DemoApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class DemoAppController : AbpController
    {
        protected DemoAppController()
        {
            LocalizationResource = typeof(DemoAppResource);
        }
    }
}