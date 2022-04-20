using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace ECommerce.Pages;

public class Index_Tests : ECommerceWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
