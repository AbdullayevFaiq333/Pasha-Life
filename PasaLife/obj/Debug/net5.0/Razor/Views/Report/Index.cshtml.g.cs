#pragma checksum "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c9867529813e04a9daa70330cbdc9f482608bf76"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_Index), @"mvc.1.0.view", @"/Views/Report/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9867529813e04a9daa70330cbdc9f482608bf76", @"/Views/Report/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"304385378a6866560a3046311af37f4723185c8f", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ReportViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/video/background.mp4"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("video/mp4"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/asistent.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/video/eye.mov"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("video/mp4; codecs=\'hvc1\'"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/video/eye.webm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("video/webm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
  
    var culture = System.Globalization.CultureInfo.CurrentCulture.Name;

    ViewData["Title"] = "Hesabatlar";
    bool IsTrueCat = true;
    bool IsTrueRep = true;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"page_content total_page\">\r\n    <div class=\"static_page_header\">\r\n");
#nullable restore
#line 13 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
         if (culture == "az")
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h2>Hesabatlar</h2>\r\n");
#nullable restore
#line 16 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"

        }
        else if (culture == "en")
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h2>Reports</h2>\r\n");
#nullable restore
#line 21 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"

        }
        else if (culture == "ru")
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h2>Отчеты</h2>\r\n");
#nullable restore
#line 26 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
            
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
#nullable restore
#line 28 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
   Write(await Component.InvokeAsync("SecondMenu"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </div>\r\n\r\n    <div class=\"white_background_content static_page_content\">\r\n        <div class=\"reports_item\">\r\n            <div class=\"page_section_head\">\r\n");
#nullable restore
#line 35 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                 if (culture == "az")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <h4>Hesabatlar</h4>\r\n");
#nullable restore
#line 38 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"

                }
                else if (culture == "en")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <h4>Reports</h4>\r\n");
#nullable restore
#line 43 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"

                }
                else if (culture == "ru")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <h4>Отчеты</h4>\r\n");
#nullable restore
#line 48 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
            
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <ul class=\"switcher\" data-switcher-name=\"reports\">\r\n");
#nullable restore
#line 51 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                     foreach (ReportCategory item in Model.ReportCategories)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                         if (culture == "az")
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li><button");
            BeginWriteAttribute("class", " class=\"", 1427, "\"", 1460, 1);
#nullable restore
#line 55 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
WriteAttributeValue(" ", 1435, IsTrueCat?"active":"", 1436, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-tab=\"cat-");
#nullable restore
#line 55 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                                                                                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 55 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                                                                                             Write(item.AzName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button></li>\r\n");
#nullable restore
#line 56 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"

                        }
                        else if (culture == "en")
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li><button");
            BeginWriteAttribute("class", " class=\"", 1660, "\"", 1693, 1);
#nullable restore
#line 60 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
WriteAttributeValue(" ", 1668, IsTrueCat?"active":"", 1669, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("  data-tab=\"cat-");
#nullable restore
#line 60 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                                                                                    Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 60 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                                                                                              Write(item.EnName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button></li>\r\n");
#nullable restore
#line 61 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"

                        }
                        else if (culture == "ru")
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li><button");
            BeginWriteAttribute("class", "  class=\"", 1894, "\"", 1928, 1);
#nullable restore
#line 65 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
WriteAttributeValue(" ", 1903, IsTrueCat?"active":"", 1904, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("  data-tab=\"cat-");
#nullable restore
#line 65 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                                                                                     Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(")\">");
#nullable restore
#line 65 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                                                                                                Write(item.RuName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button></li>\r\n");
#nullable restore
#line 66 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"

                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                         
                        IsTrueCat = false;

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </ul>\r\n            </div>\r\n            <div class=\"tabs_for_switcher\" data-switcher-name=\"reports\">\r\n");
#nullable restore
#line 75 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                 foreach (var item in Model.ReportCategories)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 77 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                     if (culture == "az")
                    {
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div");
            BeginWriteAttribute("class", " class=\"", 2403, "\"", 2447, 2);
            WriteAttributeValue("", 2411, "tab_content", 2411, 11, true);
#nullable restore
#line 80 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
WriteAttributeValue(" ", 2422, IsTrueRep?"active":"", 2423, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-tab=\"cat-");
#nullable restore
#line 80 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                                                                                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" >\r\n                            <div class=\"r_content_grid\">\r\n");
#nullable restore
#line 82 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                                 foreach (var report in item.Reports)
                               {
                                   

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                  <div class=""report_item""  >
                                    <a href=""#"" class=""report_link"" target=""_blank"">
                                        <div class=""report_top"">
                                            <div class=""file_format"">PDF</div>
                                            <div class=""rp_y"">");
#nullable restore
#line 89 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                                                         Write(report.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                            <strong>");
#nullable restore
#line 90 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                                               Write(report.AzName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                                        </div>\r\n                                        <p>");
#nullable restore
#line 92 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                                      Write(report.Size.ToUpper());

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    </a>\r\n                                </div> \n");
#nullable restore
#line 95 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"

                               }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                \r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 100 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                    }
                    else if (culture == "en")
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div");
            BeginWriteAttribute("class", " class=\"", 3586, "\"", 3630, 2);
            WriteAttributeValue("", 3594, "tab_content", 3594, 11, true);
#nullable restore
#line 103 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
WriteAttributeValue(" ", 3605, IsTrueRep?"active":"", 3606, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-tab=\"cat-");
#nullable restore
#line 103 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                                                                                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                            <div class=\"r_content_grid\">\r\n");
#nullable restore
#line 105 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                                 foreach (var report in item.Reports)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <div class=""report_item"">
                                    <a href=""#"" class=""report_link"" target=""_blank"">
                                        <div class=""report_top"">
                                            <div class=""file_format"">PDF</div>
                                            <div class=""rp_y"">");
#nullable restore
#line 111 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                                                         Write(report.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                            <strong>");
#nullable restore
#line 112 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                                               Write(report.EnName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                                        </div>\r\n                                        <p>");
#nullable restore
#line 114 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                                      Write(report.Size.ToUpper());

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    </a>\r\n                                </div>\r\n");
#nullable restore
#line 117 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                \r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 121 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                    }
                    else if (culture == "ru")
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div");
            BeginWriteAttribute("class", " class=\"", 4735, "\"", 4779, 2);
            WriteAttributeValue("", 4743, "tab_content", 4743, 11, true);
#nullable restore
#line 124 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
WriteAttributeValue(" ", 4754, IsTrueRep?"active":"", 4755, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-tab=\"cat-");
#nullable restore
#line 124 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                                                                                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                            <div class=\"r_content_grid\">\r\n");
#nullable restore
#line 126 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                                 foreach (var report in item.Reports)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                   <div class=""report_item"">
                                    <a href=""#"" class=""report_link"" target=""_blank"">
                                        <div class=""report_top"">
                                            <div class=""file_format"">PDF</div>
                                            <div class=""rp_y"">");
#nullable restore
#line 132 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                                                         Write(report.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                            <strong>");
#nullable restore
#line 133 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                                               Write(report.RuName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                                        </div>\r\n                                        <p>");
#nullable restore
#line 135 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                                      Write(report.Size.ToUpper());

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    </a>\r\n                                </div> \r\n");
#nullable restore
#line 138 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 142 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 142 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
                     
                    IsTrueRep = false;

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n        ");
#nullable restore
#line 151 "C:\Users\HP\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Views\Report\Index.cshtml"
   Write(await Component.InvokeAsync("Footer"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n</div>\r\n\r\n<div class=\"page_background\">\r\n    <video muted loop class=\"video\" autoplay playsinline>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("source", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c9867529813e04a9daa70330cbdc9f482608bf7625381", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </video>\r\n</div>\r\n\r\n<div class=\"assistant_wrap\">\r\n    <div class=\"eye\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c9867529813e04a9daa70330cbdc9f482608bf7626585", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</div>\r\n    <div class=\"eye_animated\">\r\n        <video autoplay=\"autoplay\" muted=\"muted\" loop=\"loop\" data-v-a95f347a=\"\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("source", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c9867529813e04a9daa70330cbdc9f482608bf7627762", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("source", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c9867529813e04a9daa70330cbdc9f482608bf7628892", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </video>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ReportViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591