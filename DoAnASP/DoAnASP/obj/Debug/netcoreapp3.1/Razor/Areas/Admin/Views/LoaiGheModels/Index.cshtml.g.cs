#pragma checksum "F:\GITHUB\ASP\DoAnASP\DoAnASP\Areas\Admin\Views\LoaiGheModels\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fda6d102c50cdd5e881df3e615a60f8fadbaa548"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_LoaiGheModels_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/LoaiGheModels/Index.cshtml")]
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
#line 1 "F:\GITHUB\ASP\DoAnASP\DoAnASP\Areas\Admin\Views\_ViewImports.cshtml"
using DoAnASP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\GITHUB\ASP\DoAnASP\DoAnASP\Areas\Admin\Views\_ViewImports.cshtml"
using DoAnASP.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fda6d102c50cdd5e881df3e615a60f8fadbaa548", @"/Areas/Admin/Views/LoaiGheModels/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6de2b670c6ee28ceb5127ebe54e4c5f12b414cd9", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_LoaiGheModels_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DoAnASP.Areas.Admin.Models.LoaiGheModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\GITHUB\ASP\DoAnASP\DoAnASP\Areas\Admin\Views\LoaiGheModels\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""main-content"">
    <div class=""section__content section__content--p30"">
        <div class=""container-fluid"">
            <div class=""row"">
                <div class=""col-md-12"">
                    <div class=""table-responsive table-responsive-data2"">
                        <h1>Loại ghế</h1>

                        <p>
                            <a class=""au-btn au-btn-icon au-btn--green au-btn--small""");
            BeginWriteAttribute("onclick", " onclick=\"", 537, "\"", 642, 6);
            WriteAttributeValue("", 547, "showModal(\'", 547, 11, true);
#nullable restore
#line 16 "F:\GITHUB\ASP\DoAnASP\DoAnASP\Areas\Admin\Views\LoaiGheModels\Index.cshtml"
WriteAttributeValue("", 558, Url.Action("Create","LoaiGheModels",null,Context.Request.Scheme), 558, 65, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 623, "\',", 623, 2, true);
            WriteAttributeValue(" ", 625, "\'Thêm", 626, 6, true);
            WriteAttributeValue(" ", 631, "loại", 632, 5, true);
            WriteAttributeValue(" ", 636, "ghế\')", 637, 6, true);
            EndWriteAttribute();
            WriteLiteral(@">Create New</a>
                        </p>
                        <table class=""table table-data2"">
                            <thead>
                                <tr>
                                    <th>
                                        Tên loại ghế
                                    </th>
                                    <th>
                                        Giá loại ghế
                                    </th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 31 "F:\GITHUB\ASP\DoAnASP\DoAnASP\Areas\Admin\Views\LoaiGheModels\Index.cshtml"
                                 foreach (var item in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr class=\"tr-shadow\">\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 35 "F:\GITHUB\ASP\DoAnASP\DoAnASP\Areas\Admin\Views\LoaiGheModels\Index.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.TenLoaiGhe));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 38 "F:\GITHUB\ASP\DoAnASP\DoAnASP\Areas\Admin\Views\LoaiGheModels\Index.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.GiaLoaiGhe));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            <div class=\"table-data-feature\">\r\n                                                <a");
            BeginWriteAttribute("onclick", " onclick=\"", 1964, "\"", 2089, 4);
            WriteAttributeValue("", 1974, "showModal(\'", 1974, 11, true);
#nullable restore
#line 42 "F:\GITHUB\ASP\DoAnASP\DoAnASP\Areas\Admin\Views\LoaiGheModels\Index.cshtml"
WriteAttributeValue("", 1985, Url.Action("Edit","LoaiGheModels",new { id = $"{item.IdLoaiGhe}" },Context.Request.Scheme), 1985, 91, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2076, "\',\'Cập", 2076, 6, true);
            WriteAttributeValue(" ", 2082, "nhật\')", 2083, 7, true);
            EndWriteAttribute();
            WriteLiteral(@" class=""item"" data-toggle=""tooltip"" data-placement=""top"" title=""Edit"">
                                                    <i class=""zmdi zmdi-edit""></i>
                                                </a>
                                                <a");
            BeginWriteAttribute("onclick", " onclick=\"", 2350, "\"", 2481, 5);
            WriteAttributeValue("", 2360, "showModal(\'", 2360, 11, true);
#nullable restore
#line 45 "F:\GITHUB\ASP\DoAnASP\DoAnASP\Areas\Admin\Views\LoaiGheModels\Index.cshtml"
WriteAttributeValue("", 2371, Url.Action("Delete","LoaiGheModels",new { id = $"{item.IdLoaiGhe}" },Context.Request.Scheme), 2371, 93, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2464, "\',\'Xóa", 2464, 6, true);
            WriteAttributeValue(" ", 2470, "loại", 2471, 5, true);
            WriteAttributeValue(" ", 2475, "ghế\')", 2476, 6, true);
            EndWriteAttribute();
            WriteLiteral(@" class=""item"" data-toggle=""tooltip"" data-placement=""top"" title=""Delete"">
                                                    <i class=""zmdi zmdi-delete""></i>
                                                </a>
                                            </div>
                                        </td>
                                    </tr>
");
#nullable restore
#line 51 "F:\GITHUB\ASP\DoAnASP\DoAnASP\Areas\Admin\Views\LoaiGheModels\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DoAnASP.Areas.Admin.Models.LoaiGheModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
