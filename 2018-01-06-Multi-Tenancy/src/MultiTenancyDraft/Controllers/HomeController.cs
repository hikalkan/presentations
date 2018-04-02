using Microsoft.AspNetCore.Mvc;
using MultiTenancyDraft.Infrastructure;

namespace MultiTenancyDraft.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Content("Current tenant: " + TenantInfo.Current);
        }
    }
}
