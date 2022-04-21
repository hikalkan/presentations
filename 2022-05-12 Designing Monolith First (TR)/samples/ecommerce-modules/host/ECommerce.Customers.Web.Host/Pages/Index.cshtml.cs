using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace ECommerce.Customers.Pages;

public class IndexModel : CustomersPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
