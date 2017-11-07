using System.Threading.Tasks;
using AngleSharp.Parser.Html;
using Shouldly;
using Xunit;

namespace DotnetCoreDays.Tests.Pages.Todos
{
    public class Index_Tests : TestBase
    {
        [Fact]
        public async Task OnGetAsync()
        {
            //Act

            var response = await Client.GetAsync("/Todos");

            //Assert

            response.IsSuccessStatusCode.ShouldBeTrue();

            var result = await response.Content.ReadAsStringAsync();
            var htmlParser = new HtmlParser();
            var html = await htmlParser.ParseAsync(result);

            var listItems = html.QuerySelectorAll("#TodoList li");
            listItems.Length.ShouldBe(2);
        }
    }
}
