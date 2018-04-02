using Microsoft.AspNetCore.Mvc;

namespace MultiTenancyDraft.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Content("OK");
        }
    }
}
