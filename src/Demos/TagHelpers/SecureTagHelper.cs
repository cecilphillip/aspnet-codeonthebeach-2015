using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Mvc.ViewFeatures;
using Microsoft.AspNet.Razor.TagHelpers;

namespace Demos.TagHelpers
{
    [HtmlTargetElement("div", Attributes = RoleAttributeName)]
    public class SecureTagHelper: TagHelper
    {       
        private const string RoleAttributeName = "demo-secure";        

        [HtmlAttributeName(RoleAttributeName)]
        public string Role { get; set; }

        [ViewContext]
        public ViewContext ViewContext { get; set; }
        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext.HttpContext.User.Identity.IsAuthenticated && ViewContext.HttpContext.User.IsInRole(Role))
            {
                base.Process(context, output);
                return;
            }
            
            output.SuppressOutput();
            output.Content.Append("<h3>You must login first</h3>");
        }
    }


}
