#pragma checksum "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Login\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "490c1d936cd0e09d3d36547a52c2ad73a7a9630a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Pomona.Views.Login.Views_Login_Login), @"mvc.1.0.view", @"/Views/Login/Login.cshtml")]
namespace Pomona.Views.Login
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
#line 1 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\_ViewImports.cshtml"
using Pomona;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\_ViewImports.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"490c1d936cd0e09d3d36547a52c2ad73a7a9630a", @"/Views/Login/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9eeb343440400e3984c17453faa3a0fd9afbfb14", @"/Views/_ViewImports.cshtml")]
    public class Views_Login_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/Untitled.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Login\Login.cshtml"
  
    Layout = "/Views/Shared/_LoginLayout.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Login\Login.cshtml"
   await Html.RenderPartialAsync("PopupMessage"); 

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "490c1d936cd0e09d3d36547a52c2ad73a7a9630a3807", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<div class=\"simulator\">\r\n\r\n");
#nullable restore
#line 9 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Login\Login.cshtml"
     using (Html.BeginForm())
    {
        using (Html.DevExtreme().ValidationGroup())
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Login\Login.cshtml"
       Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Login\Login.cshtml"
 Write(Html.DevExtreme().Form<Pomona.Models.User>()
      .ID("loginForm")
      //  .ShowValidationSummary(true)
      .OnEditorEnterKey("SubmitLoginForm")
      .Items(items =>
      {
      items.AddGroup()
      .Caption("Pomona")
      .Items(groupItems =>
      {
          groupItems.AddSimpleFor(m => m.UserName)
          .Label(t => t.Location(FormLabelLocation.Left)
          .Text("Korisničko ime"))
          .ValidationRules(rules => rules.AddRequired()
          .Message("Morate uneti korisnika"))
          .Editor(e => e.TextBox().Width(500)
          .ElementAttr(new { ID = "loginusername", @class = "focus" }));

          groupItems.AddSimpleFor(m => m.Password)
          .Label(t => t.Location(FormLabelLocation.Left)
          .Text("Lozinka"))
          .ValidationRules(rules => rules.AddRequired()
          .Message("Morate uneti lozinku"))
          .Editor(e => e.TextBox().Mode(TextBoxMode.Password).Width(537)
          .ElementAttr(new { ID = "loginpassword" }));});

      items.AddButton()
      .HorizontalAlignment(HorizontalAlignment.Left)
      .ButtonOptions(b => b.Text("Uloguj se")
      .ID("loginButton")
      //  .Type(ButtonType.Success)
      .OnClick("OnClickbtnLogin")
      );     

      items.AddSimple()
      .Template(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("\r\n              <a id=\"CreateAccountButton\" href=\"#\" onclick=\"OnClickCreateAccount();\">Registracija</a>\r\n                           ");
    PopWriter();
}
));
      
              //items.AddButton()
              //.HorizontalAlignment(HorizontalAlignment.Left)
              //.ButtonOptions(b => b.Text("Kreiraj nalog").StylingMode(ButtonStylingMode.Outlined)
              //.ID("CreateAccountButton")
              //.OnClick("OnClickCreateAccount"));
          }).FormData(Model));

#line default
#line hidden
#nullable disable
#nullable restore
#line 58 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Login\Login.cshtml"
                             
              }
          }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 62 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Login\Login.cshtml"
Write(Html.DevExtreme().Popup().ID("popupFormRegistration")
                  .ShowCloseButton(true)
                  .DragEnabled(true)
                  .CloseOnOutsideClick(false)
                  .ElementAttr("class", "popup")
                  .OnContentReady("onContentReadyRegistration")
                  .OnShown("onShownpopupFormRegistration")
                //  .OnHiding("onHidingAttribute")
                  .Position(pos => pos
                      .My(HorizontalAlignment.Center, VerticalAlignment.Center)
                      .At(HorizontalAlignment.Center, VerticalAlignment.Center)
                      .Of(new JS("window"))
                  )
                  .ResizeEnabled(false)
                  .ContentTemplate(new TemplateName("popup-templateRegistration"))
    );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 78 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Login\Login.cshtml"
     using (Html.DevExtreme().NamedTemplate("popup-templateRegistration"))
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 80 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Login\Login.cshtml"
    Write(Html.DevExtreme().ScrollView()
                    .ID("scrollViewRegistration")
                    .Width("100%")
                    .Height("100%")
                    .Direction(ScrollDirection.Both)
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 85 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Login\Login.cshtml"
         

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n\r\n");
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
