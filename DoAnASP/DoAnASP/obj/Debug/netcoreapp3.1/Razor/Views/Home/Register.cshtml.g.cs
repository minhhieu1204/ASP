#pragma checksum "E:\HK5\Web ASP.Net\ASP\DoAnASP\DoAnASP\Views\Home\Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1412b7a2526ac9f4373adb8983df7b6f912b896b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Register), @"mvc.1.0.view", @"/Views/Home/Register.cshtml")]
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
#line 1 "E:\HK5\Web ASP.Net\ASP\DoAnASP\DoAnASP\Views\_ViewImports.cshtml"
using DoAnASP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\HK5\Web ASP.Net\ASP\DoAnASP\DoAnASP\Views\_ViewImports.cshtml"
using DoAnASP.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1412b7a2526ac9f4373adb8983df7b6f912b896b", @"/Views/Home/Register.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01559e99e336597569724a303b01a6c874d0bd5d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Register : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DoAnASP.Areas.Admin.Models.UserModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "false", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "true", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\HK5\Web ASP.Net\ASP\DoAnASP\DoAnASP\Views\Home\Register.cshtml"
  
    ViewData["Title"] = "Login";
    Layout = "~/Views/Shared/_LayoutLogin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<section class=\"main\">\r\n    <div class=\"layer\">\r\n        <div class=\"bottom-grid\">\r\n            <div class=\"logo\">\r\n                <h1> ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1412b7a2526ac9f4373adb8983df7b6f912b896b5344", async() => {
                WriteLiteral("<span class=\"fa fa-key\"></span> Key");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</h1>\r\n            </div>\r\n            <div class=\"links\">\r\n                <ul class=\"links-unordered-list\">\r\n                    <li class=\"active\">\r\n                        <a href=\"#\"");
            BeginWriteAttribute("class", " class=\"", 525, "\"", 533, 0);
            EndWriteAttribute();
            WriteLiteral(">Login</a>\r\n                    </li>\r\n                    <li");
            BeginWriteAttribute("class", " class=\"", 596, "\"", 604, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <a href=\"#\"");
            BeginWriteAttribute("class", " class=\"", 643, "\"", 651, 0);
            EndWriteAttribute();
            WriteLiteral(@">Register</a>
                    </li>
                </ul>
            </div>
        </div>
        <div class=""content-w3ls"">
            <div class=""text-center icon"">
                <span class=""fa fa-html5""></span>
            </div>
            <div class=""content-bottom"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1412b7a2526ac9f4373adb8983df7b6f912b896b7578", async() => {
                WriteLiteral("\r\n                    <div class=\"field-group\">\r\n                        <span class=\"fa fa-user\" aria-hidden=\"true\"></span>\r\n                        <div class=\"wthree-field\">\r\n                            <input name=\"HoTen\" id=\"text1\" type=\"text\"");
                BeginWriteAttribute("value", " value=\"", 1252, "\"", 1260, 0);
                EndWriteAttribute();
                WriteLiteral(@" placeholder=""Fullname"" required>
                        </div>
                    </div>
                    <div class=""field-group"">
                        <span class=""fa fa-user"" aria-hidden=""true""></span>
                        <div class=""wthree-field"">
                            <input name=""SDT"" id=""text1"" type=""number""");
                BeginWriteAttribute("value", " value=\"", 1602, "\"", 1610, 0);
                EndWriteAttribute();
                WriteLiteral(@" placeholder=""Phone"" required>
                        </div>
                    </div>
                    <div class=""field-group"">
                        <span class=""fa fa-user"" aria-hidden=""true""></span>
                        <div class=""wthree-field"">
                            <input name=""NgaySinh"" id=""text1"" type=""date""");
                BeginWriteAttribute("value", " value=\"", 1952, "\"", 1960, 0);
                EndWriteAttribute();
                WriteLiteral(" placeholder=\"Birthday\" required>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"field-group\">\r\n                        <select name=\"GioiTinh\" class=\"wthree-field\">\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1412b7a2526ac9f4373adb8983df7b6f912b896b9539", async() => {
                    WriteLiteral("Nam");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1412b7a2526ac9f4373adb8983df7b6f912b896b10787", async() => {
                    WriteLiteral("Nữ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                        </select>
                    </div>
                    <div class=""field-group"">
                        <span class=""fa fa-user"" aria-hidden=""true""></span>
                        <div class=""wthree-field"">
                            <input name=""DiaChi"" id=""text1"" type=""text""");
                BeginWriteAttribute("value", " value=\"", 2610, "\"", 2618, 0);
                EndWriteAttribute();
                WriteLiteral(@" placeholder=""Address"" required>
                        </div>
                    </div>
                    <span id=""usernameisuse""></span>
                    <div class=""field-group"">
                        <span class=""fa fa-user"" aria-hidden=""true""></span>
                        <div class=""wthree-field"">
                            <input name=""Username"" id=""username"" type=""text""");
                BeginWriteAttribute("value", " value=\"", 3019, "\"", 3027, 0);
                EndWriteAttribute();
                WriteLiteral(@" placeholder=""Username"" required onchange=""checkUsername()"">
                        </div>
                    </div>
                    <div class=""field-group"">
                        <span class=""fa fa-lock"" aria-hidden=""true""></span>
                        <div class=""wthree-field"">
                            <input name=""Password"" id=""password"" type=""Password"" placeholder=""Password"" required>
                        </div>
                    </div>
                    <span id=""pwnotmatch""></span>
                    <div class=""field-group"">
                        <span class=""fa fa-lock"" aria-hidden=""true""></span>
                        <div class=""wthree-field"">
                            <input id=""cpassword"" type=""Password"" placeholder=""Confirm Password"" required oninput=""checkPasswordMatch(this)"">
                        </div>
                    </div>
                    <div class=""wthree-field"">
                        <button type=""submit"" id=""btn_register"" class=""bt");
                WriteLiteral("n btn-primary\" disabled>Get Started</button>\r\n                    </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script>
        function checkPasswordMatch(x) {
            if (x.value != $('#password').val()) {
                //x.setCustomValidity('Password do not match!')
                $('#pwnotmatch').html('<p style=""color:white; font-size:20px"">Password do not match!</p>');
                $(""#btn_register"").attr(""disabled"", true);
            }
            else {
                //x.setCustomValidity('')
                $('#pwnotmatch').html('');
                $(""#btn_register"").attr(""disabled"", false);
            }
        }
        function checkUsername() {
            $.ajax({
                method: ""GET"",
                url: ""../../api/UserModels/checkusername"",
                data: { 'username': $(""#username"").val() }
            }).done(function (data) {
                var dataJS = JSON.parse(data);
                if (!dataJS) {
                    $('#usernameisuse').html('<p style=""color:white; font-size:20px"">Usernam already exists ! </p>');
                }
  ");
                WriteLiteral("              else {\r\n                    $(\'#usernameisuse\').html(\'\');\r\n                }\r\n            });   \r\n        }            \r\n    </script>\r\n\r\n");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DoAnASP.Areas.Admin.Models.UserModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
