using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCoreDays.Views.Components.TodoCreateArea
{
    public class FooterViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
