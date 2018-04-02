using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MultiTenancyDraft.Application;

namespace MultiTenancyDraft.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext _myDbContext;

        public HomeController(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public ActionResult Index()
        {
            return View(_myDbContext.Products.ToList());
        }
    }
}
