#pragma checksum "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\Footer\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bdf7c50e1a7d1c36f8e3d794d2b6b04b6daef5ef"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Footer_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Footer/Default.cshtml")]
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
#line 1 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\_ViewImports.cshtml"
using PasaLife;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\_ViewImports.cshtml"
using PasaLife.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\_ViewImports.cshtml"
using PasaLife.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bdf7c50e1a7d1c36f8e3d794d2b6b04b6daef5ef", @"/Views/Shared/Components/Footer/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"304385378a6866560a3046311af37f4723185c8f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Footer_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FooterViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\Footer\Default.cshtml"
  
    var culture = System.Globalization.CultureInfo.CurrentCulture.Name;
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<footer>\r\n    <ul class=\"social\">\r\n");
#nullable restore
#line 13 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\Footer\Default.cshtml"
         foreach(SocialMedia item in Model.SocialMedias)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li><a");
            BeginWriteAttribute("href", " href=\"", 242, "\"", 258, 1);
#nullable restore
#line 15 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\Footer\Default.cshtml"
WriteAttributeValue("", 249, item.Url, 249, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><img");
            BeginWriteAttribute("src", " src=\"", 264, "\"", 290, 2);
            WriteAttributeValue("", 270, "style/img/", 270, 10, true);
#nullable restore
#line 15 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\Footer\Default.cshtml"
WriteAttributeValue("", 280, item.Icon, 280, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 291, "\"", 297, 0);
            EndWriteAttribute();
            WriteLiteral("></a></li>\r\n");
#nullable restore
#line 16 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\Footer\Default.cshtml"
				
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        \r\n\t</ul>\r\n    <div class=\"footer_left\">\r\n");
#nullable restore
#line 21 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\Footer\Default.cshtml"
         if (culture == "az")
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p class=\"copy_right\">© 2021 PAŞA Həyat Sığorta ASC</p>\r\n");
#nullable restore
#line 24 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\Footer\Default.cshtml"

        }
        else if (culture == "en")
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p class=\"copy_right\">© 2021 PASHA Life Insurance ASC</p>\r\n");
#nullable restore
#line 29 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\Footer\Default.cshtml"

        }
        else if (culture == "ru")
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p class=\"copy_right\">© 2021 PASHA Страхование жизни ASC</p>\r\n");
#nullable restore
#line 34 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\Footer\Default.cshtml"
            
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <ul>\r\n");
#nullable restore
#line 37 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\Footer\Default.cshtml"
             foreach (Footer item in Model.Footers)
            {
                if (culture == "az")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li><a");
            BeginWriteAttribute("href", " href=\"", 940, "\"", 956, 1);
#nullable restore
#line 41 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\Footer\Default.cshtml"
WriteAttributeValue("", 947, item.URL, 947, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">");
#nullable restore
#line 41 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\Footer\Default.cshtml"
                                                       Write(item.AzTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 42 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\Footer\Default.cshtml"


                }
                else if (culture == "en")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li><a");
            BeginWriteAttribute("href", " href=\"", 1109, "\"", 1125, 1);
#nullable restore
#line 47 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\Footer\Default.cshtml"
WriteAttributeValue("", 1116, item.URL, 1116, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">");
#nullable restore
#line 47 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\Footer\Default.cshtml"
                                                       Write(item.EnTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 48 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\Footer\Default.cshtml"


                }
                else if (culture == "ru")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li><a");
            BeginWriteAttribute("href", " href=\"", 1278, "\"", 1294, 1);
#nullable restore
#line 53 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\Footer\Default.cshtml"
WriteAttributeValue("", 1285, item.URL, 1285, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">");
#nullable restore
#line 53 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\Footer\Default.cshtml"
                                                       Write(item.RuTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 54 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Shared\Components\Footer\Default.cshtml"


                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            <li>
                <div class=""by_jis"">
                    <p>Site by</p>
                    <a href=""http://www.jis.az/"" target=""_blank"" class=""jis"">Jeykhun Imanov Studio</a>
                </div>
            </li>
        </ul>
    </div>
</footer>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FooterViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591