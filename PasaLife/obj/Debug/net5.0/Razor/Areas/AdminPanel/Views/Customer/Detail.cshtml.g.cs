#pragma checksum "C:\Users\HP\OneDrive\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Areas\AdminPanel\Views\Customer\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2141d490f005c1fdc736e91c7881d97012ab9c1b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_AdminPanel_Views_Customer_Detail), @"mvc.1.0.view", @"/Areas/AdminPanel/Views/Customer/Detail.cshtml")]
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
#line 1 "C:\Users\HP\OneDrive\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Areas\AdminPanel\Views\_ViewImports.cshtml"
using PasaLife;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\OneDrive\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Areas\AdminPanel\Views\_ViewImports.cshtml"
using PasaLife.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\OneDrive\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Areas\AdminPanel\Views\_ViewImports.cshtml"
using PasaLife.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2141d490f005c1fdc736e91c7881d97012ab9c1b", @"/Areas/AdminPanel/Views/Customer/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20d5c2ff9d91fd151934fb249677ecee6f45205a", @"/Areas/AdminPanel/Views/_ViewImports.cshtml")]
    public class Areas_AdminPanel_Views_Customer_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-top: 5px; justify-content:end"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:100px;height:100px;object-fit:cover;border-radius:50%"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\HP\OneDrive\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Areas\AdminPanel\Views\Customer\Detail.cshtml"
  
    ViewData["Title"] = "Detail";
    Customer customer = Model;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"col-lg-12\">\r\n    <div class=\"card\">\r\n        <div class=\"card-body\">\r\n            <h2 class=\"mt-0 header-title\">Müştəri Haqqında</h2>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2141d490f005c1fdc736e91c7881d97012ab9c1b5835", async() => {
                WriteLiteral("\r\n                Go Back\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            <div class=""table-responsive"">
                <table class=""table table-bordered mb-0"">
                    <tbody>
                        <tr>
                            <th scope=""row"">Ad</th>
                            <td>
                                ");
#nullable restore
#line 19 "C:\Users\HP\OneDrive\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Areas\AdminPanel\Views\Customer\Detail.cshtml"
                           Write(customer.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n                        <tr>\r\n                            <th scope=\"row\">Şirkət</th>\r\n                            <td>\r\n                                ");
#nullable restore
#line 25 "C:\Users\HP\OneDrive\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Areas\AdminPanel\Views\Customer\Detail.cshtml"
                           Write(customer.Work);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n                        <tr>\r\n                            <th scope=\"row\">Mətn</th>\r\n                            <td>\r\n                                ");
#nullable restore
#line 31 "C:\Users\HP\OneDrive\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Areas\AdminPanel\Views\Customer\Detail.cshtml"
                           Write(Html.Raw(customer.AzDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n\r\n                        <tr>\r\n                            <th scope=\"row\">Текст</th>\r\n                            <td>\r\n                                ");
#nullable restore
#line 38 "C:\Users\HP\OneDrive\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Areas\AdminPanel\Views\Customer\Detail.cshtml"
                           Write(Html.Raw(customer.RuDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n\r\n                        <tr>\r\n                            <th scope=\"row\">Description</th>\r\n                            <td>\r\n                                ");
#nullable restore
#line 45 "C:\Users\HP\OneDrive\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Areas\AdminPanel\Views\Customer\Detail.cshtml"
                           Write(Html.Raw(customer.EnDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n                        \r\n                        <tr>\r\n                            <th scope=\"row\">Şəkil</th>\r\n                            <td>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2141d490f005c1fdc736e91c7881d97012ab9c1b10354", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2021, "~/images/", 2021, 9, true);
#nullable restore
#line 52 "C:\Users\HP\OneDrive\Desktop\Pasa-Life\jis-pasha-life-back-end\PasaLife\Areas\AdminPanel\Views\Customer\Detail.cshtml"
AddHtmlAttributeValue("", 2030, customer.Image, 2030, 15, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n\r\n                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
