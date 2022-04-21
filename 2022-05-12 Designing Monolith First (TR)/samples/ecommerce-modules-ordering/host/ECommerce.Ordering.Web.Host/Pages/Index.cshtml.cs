using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace ECommerce.Ordering.Pages;

public class IndexModel : OrderingPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
