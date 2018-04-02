using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DotnetCoreDays.TagHelpers
{
    /// <summary>
    /// Converts
    ///           <email>info@sample.com</email>
    /// To
    ///           <a href="mailto:info@sample.com">info@sample.com</a>
    /// </summary>
    public class EmailTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";

            var emailAddress = (await output.GetChildContentAsync()).GetContent();

            output.Attributes.SetAttribute("href", $"mailto:{emailAddress}");
            
            output.Content.SetContent(emailAddress);
        }
    }
}
