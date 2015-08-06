using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace Demos.TagHelpers
{
    [TargetElement("div", Attributes = RoleAttributeName)]
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
