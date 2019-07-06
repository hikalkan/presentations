using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Acme.DddDemo.Pages
{
    public class Index_Tests : DddDemoWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
