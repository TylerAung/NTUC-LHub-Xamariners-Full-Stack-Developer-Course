#pragma checksum "C:\Users\admin\Desktop\Full Stack Developer Course\C# Fundamentals\CustomerApp - Angular\CustomerApp\Views\Customer\CustomerAdd.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c90b59cef6159fd78e00e674d83179d45b96c80f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_CustomerAdd), @"mvc.1.0.view", @"/Views/Customer/CustomerAdd.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\admin\Desktop\Full Stack Developer Course\C# Fundamentals\CustomerApp - Angular\CustomerApp\Views\_ViewImports.cshtml"
using CustomerApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\admin\Desktop\Full Stack Developer Course\C# Fundamentals\CustomerApp - Angular\CustomerApp\Views\_ViewImports.cshtml"
using CustomerApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c90b59cef6159fd78e00e674d83179d45b96c80f", @"/Views/Customer/CustomerAdd.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1035fcd16cd1925d44002e818f0d84c97d3a947", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_CustomerAdd : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CustomerApp.ViewModels.CustomerViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Customer/AddCust"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r");
            WriteLiteral("\r");
            WriteLiteral("\r\r");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c90b59cef6159fd78e00e674d83179d45b96c80f4156", async() => {
                WriteLiteral("\r    Name :-\r    <input type=\"text\" name=\"CustName\"");
                BeginWriteAttribute("value", " value=\"", 379, "\"", 411, 1);
#nullable restore
#line 12 "C:\Users\admin\Desktop\Full Stack Developer Course\C# Fundamentals\CustomerApp - Angular\CustomerApp\Views\Customer\CustomerAdd.cshtml"
WriteAttributeValue("", 387, Model.customer.CustName, 387, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("/>\r    <br />\r    Address :-\r    <input type=\"text\" name=\"CustAddress\"");
                BeginWriteAttribute("value", " value=\"", 482, "\"", 517, 1);
#nullable restore
#line 15 "C:\Users\admin\Desktop\Full Stack Developer Course\C# Fundamentals\CustomerApp - Angular\CustomerApp\Views\Customer\CustomerAdd.cshtml"
WriteAttributeValue("", 490, Model.customer.CustAddress, 490, 27, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("/>\r    <br />\r    <input type=\"submit\" value=\"Add\" />\r");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\r");
#nullable restore
#line 20 "C:\Users\admin\Desktop\Full Stack Developer Course\C# Fundamentals\CustomerApp - Angular\CustomerApp\Views\Customer\CustomerAdd.cshtml"
 if (Model != null){    

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\admin\Desktop\Full Stack Developer Course\C# Fundamentals\CustomerApp - Angular\CustomerApp\Views\Customer\CustomerAdd.cshtml"
     foreach (var error in Model.errors)    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p style=\"color: red;\">");
#nullable restore
#line 23 "C:\Users\admin\Desktop\Full Stack Developer Course\C# Fundamentals\CustomerApp - Angular\CustomerApp\Views\Customer\CustomerAdd.cshtml"
                          Write(error.ErrorMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r");
#nullable restore
#line 24 "C:\Users\admin\Desktop\Full Stack Developer Course\C# Fundamentals\CustomerApp - Angular\CustomerApp\Views\Customer\CustomerAdd.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\admin\Desktop\Full Stack Developer Course\C# Fundamentals\CustomerApp - Angular\CustomerApp\Views\Customer\CustomerAdd.cshtml"
     }

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r<a href=\"/\">Back</a>\r");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CustomerApp.ViewModels.CustomerViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
