#pragma checksum "C:\Users\HP\OneDrive\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\SecondMenu\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0128aed0943a11796715606408607fc67ec4857a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_SecondMenu_Default), @"mvc.1.0.view", @"/Views/Shared/Components/SecondMenu/Default.cshtml")]
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
#line 1 "C:\Users\HP\OneDrive\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\_ViewImports.cshtml"
using PasaLife;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\OneDrive\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\_ViewImports.cshtml"
using PasaLife.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\OneDrive\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\_ViewImports.cshtml"
using PasaLife.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\OneDrive\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0128aed0943a11796715606408607fc67ec4857a", @"/Views/Shared/Components/SecondMenu/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"304385378a6866560a3046311af37f4723185c8f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_SecondMenu_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<SecondMenu>>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\HP\OneDrive\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\SecondMenu\Default.cshtml"
  
    var culture = System.Globalization.CultureInfo.CurrentCulture.Name;
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"abn_wrap\">\r\n    <div class=\"about_navigation\">\r\n        <ul>\r\n");
#nullable restore
#line 11 "C:\Users\HP\OneDrive\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\SecondMenu\Default.cshtml"
             foreach (SecondMenu item in Model)
            {
                if (culture == "az")
                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0128aed0943a11796715606408607fc67ec4857a4465", async() => {
#nullable restore
#line 16 "C:\Users\HP\OneDrive\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\SecondMenu\Default.cshtml"
                                                 Write(item.AzTitle);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 16 "C:\Users\HP\OneDrive\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\SecondMenu\Default.cshtml"
                               WriteLiteral(item.URL);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-controller", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n");
#nullable restore
#line 17 "C:\Users\HP\OneDrive\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\SecondMenu\Default.cshtml"


                }
                else if (culture == "en")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0128aed0943a11796715606408607fc67ec4857a6719", async() => {
#nullable restore
#line 22 "C:\Users\HP\OneDrive\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\SecondMenu\Default.cshtml"
                                                 Write(item.EnTitle);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 22 "C:\Users\HP\OneDrive\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\SecondMenu\Default.cshtml"
                               WriteLiteral(item.URL);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-controller", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n");
#nullable restore
#line 23 "C:\Users\HP\OneDrive\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\SecondMenu\Default.cshtml"


                }
                else if (culture == "ru")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0128aed0943a11796715606408607fc67ec4857a8973", async() => {
#nullable restore
#line 28 "C:\Users\HP\OneDrive\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\SecondMenu\Default.cshtml"
                                                 Write(item.RuTitle);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 28 "C:\Users\HP\OneDrive\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\SecondMenu\Default.cshtml"
                               WriteLiteral(item.URL);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-controller", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n");
#nullable restore
#line 29 "C:\Users\HP\OneDrive\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\SecondMenu\Default.cshtml"


                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            \r\n        </ul>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<SecondMenu>> Html { get; private set; }
    }
}
#pragma warning restore 1591
