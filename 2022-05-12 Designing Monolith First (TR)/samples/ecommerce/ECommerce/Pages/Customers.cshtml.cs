using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages
{
    public class CustomersModel : PageModel
    {
        private readonly CustomerService _customerService;

        public CustomersModel(CustomerService customerService)
        {
            _customerService = customerService;
        }

        public void OnGet()
        {
            var customers = _customerService.GetListAsync();
        }
    }
}


