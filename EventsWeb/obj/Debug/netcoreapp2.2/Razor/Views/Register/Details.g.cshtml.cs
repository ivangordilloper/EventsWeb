#pragma checksum "C:\Users\ivang\Desktop\Events\EventsWeb\EventsWeb\Views\Register\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1fb523f40a60eff0c538a4f78b585d4c97592398"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Register_Details), @"mvc.1.0.view", @"/Views/Register/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Register/Details.cshtml", typeof(AspNetCore.Views_Register_Details))]
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
#line 1 "C:\Users\ivang\Desktop\Events\EventsWeb\EventsWeb\Views\_ViewImports.cshtml"
using EventsWeb;

#line default
#line hidden
#line 2 "C:\Users\ivang\Desktop\Events\EventsWeb\EventsWeb\Views\_ViewImports.cshtml"
using EventsWeb.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fb523f40a60eff0c538a4f78b585d4c97592398", @"/Views/Register/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71ba8779ff9795b4192b97d7b7090448b2a18930", @"/Views/_ViewImports.cshtml")]
    public class Views_Register_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EventsWeb.Models.Register>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Valid", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(34, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\ivang\Desktop\Events\EventsWeb\EventsWeb\Views\Register\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(79, 206, true);
            WriteLiteral("\r\n<div>\r\n    <h4>Detalles del registro</h4>\r\n    <hr />\r\n    <dl class=\"row\">     \r\n      \r\n        <dt class = \"col-sm-2\">\r\n            Nombre\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(286, 121, false);
#line 16 "C:\Users\ivang\Desktop\Events\EventsWeb\EventsWeb\Views\Register\Details.cshtml"
       Write(string.Format("{0} {1} {2}", Model.IduserNavigation.Name, Model.IduserNavigation.Lastname,Model.IduserNavigation.Surname));

#line default
#line hidden
            EndContext();
            BeginContext(407, 130, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            Email\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(538, 54, false);
#line 22 "C:\Users\ivang\Desktop\Events\EventsWeb\EventsWeb\Views\Register\Details.cshtml"
       Write(Html.DisplayFor(model => model.IduserNavigation.Email));

#line default
#line hidden
            EndContext();
            BeginContext(592, 17, true);
            WriteLiteral("\r\n        </dd>\r\n");
            EndContext();
#line 24 "C:\Users\ivang\Desktop\Events\EventsWeb\EventsWeb\Views\Register\Details.cshtml"
         if(Model.IduserNavigation.Userinfo != null){

#line default
#line hidden
            BeginContext(664, 127, true);
            WriteLiteral("        <dt class = \"col-sm-2\">\r\n            Fecha de nacimiento\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(792, 61, false);
#line 29 "C:\Users\ivang\Desktop\Events\EventsWeb\EventsWeb\Views\Register\Details.cshtml"
       Write(Html.DisplayFor(model => model.IduserNavigation.Userinfo.Dob));

#line default
#line hidden
            EndContext();
            BeginContext(853, 131, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            Genero\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(985, 88, false);
#line 35 "C:\Users\ivang\Desktop\Events\EventsWeb\EventsWeb\Views\Register\Details.cshtml"
       Write(Html.DisplayFor(model => model.IduserNavigation.Userinfo.IdgenderNavigation.Description));

#line default
#line hidden
            EndContext();
            BeginContext(1073, 25, true);
            WriteLiteral("\r\n        </dd>        \r\n");
            EndContext();
#line 37 "C:\Users\ivang\Desktop\Events\EventsWeb\EventsWeb\Views\Register\Details.cshtml"
        }

#line default
#line hidden
            BeginContext(1109, 9, true);
            WriteLiteral("         ");
            EndContext();
#line 38 "C:\Users\ivang\Desktop\Events\EventsWeb\EventsWeb\Views\Register\Details.cshtml"
          if(Model.Documents != null && Model.Documents.Any()){

#line default
#line hidden
            BeginContext(1174, 103, true);
            WriteLiteral("             <dd class = \"col-sm-12\" style=\"font-weight: bold;\">Archivos cargados por el usuario</dd>\r\n");
            EndContext();
#line 40 "C:\Users\ivang\Desktop\Events\EventsWeb\EventsWeb\Views\Register\Details.cshtml"
             foreach (var item in Model.Documents)
             {

#line default
#line hidden
            BeginContext(1345, 65, true);
            WriteLiteral("                  <dt class = \"col-sm-2\">\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1410, "\"", 1468, 2);
            WriteAttributeValue("", 1417, "/Register/GetFileResult?documentId=", 1417, 35, true);
#line 43 "C:\Users\ivang\Desktop\Events\EventsWeb\EventsWeb\Views\Register\Details.cshtml"
WriteAttributeValue("", 1452, item.Iddocument, 1452, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1469, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1471, 16, false);
#line 43 "C:\Users\ivang\Desktop\Events\EventsWeb\EventsWeb\Views\Register\Details.cshtml"
                                                                             Write(item.Description);

#line default
#line hidden
            EndContext();
            BeginContext(1487, 31, true);
            WriteLiteral("</a>\r\n                  </dt>\r\n");
            EndContext();
#line 45 "C:\Users\ivang\Desktop\Events\EventsWeb\EventsWeb\Views\Register\Details.cshtml"
             }
         }

#line default
#line hidden
            BeginContext(1546, 16, true);
            WriteLiteral("    </dl>\r\n     ");
            EndContext();
            BeginContext(1562, 267, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1fb523f40a60eff0c538a4f78b585d4c975923989124", async() => {
                BeginContext(1587, 58, true);
                WriteLiteral("\r\n            \r\n            <input type=\"hidden\" name=\"id\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1645, "\"", 1670, 1);
#line 50 "C:\Users\ivang\Desktop\Events\EventsWeb\EventsWeb\Views\Register\Details.cshtml"
WriteAttributeValue("", 1653, Model.Idregister, 1653, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1671, 151, true);
                WriteLiteral("/>\r\n            <div class=\"form-group\">\r\n                <input type=\"submit\" value=\"Validar\" class=\"btn btn-primary\" />\r\n            </div>\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1829, 27, true);
            WriteLiteral("\r\n</div>\r\n<div>\r\n    \r\n    ");
            EndContext();
            BeginContext(1856, 45, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1fb523f40a60eff0c538a4f78b585d4c9759239811457", async() => {
                BeginContext(1878, 19, true);
                WriteLiteral("Regresar a la lista");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1901, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EventsWeb.Models.Register> Html { get; private set; }
    }
}
#pragma warning restore 1591
