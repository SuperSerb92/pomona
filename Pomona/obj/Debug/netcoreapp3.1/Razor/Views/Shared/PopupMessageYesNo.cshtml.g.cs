#pragma checksum "C:\Users\Uros\Desktop\pomo\Pomona\Views\Shared\PopupMessageYesNo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "36244fbee25a89c91a5589ce9d30db7c516a16b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Pomona.Views.Shared.Views_Shared_PopupMessageYesNo), @"mvc.1.0.view", @"/Views/Shared/PopupMessageYesNo.cshtml")]
namespace Pomona.Views.Shared
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
#line 1 "C:\Users\Uros\Desktop\pomo\Pomona\Views\_ViewImports.cshtml"
using Pomona;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Uros\Desktop\pomo\Pomona\Views\_ViewImports.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"36244fbee25a89c91a5589ce9d30db7c516a16b1", @"/Views/Shared/PopupMessageYesNo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9eeb343440400e3984c17453faa3a0fd9afbfb14", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_PopupMessageYesNo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Uros\Desktop\pomo\Pomona\Views\Shared\PopupMessageYesNo.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 7 "C:\Users\Uros\Desktop\pomo\Pomona\Views\Shared\PopupMessageYesNo.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Uros\Desktop\pomo\Pomona\Views\Shared\PopupMessageYesNo.cshtml"
Write(Html.DevExtreme().Popup()
        .ID("popup-messageYesNo") 
        .ElementAttr("class", "popup")
        .Width(500)
        //.Height(250)
        //.Width("auto")
        .Height("auto")
        .ShowTitle(true)
        .Title("Information")
        .Visible(false)
        .DragEnabled(true)
        .CloseOnOutsideClick(false)
        .Position(pos => pos
        .My(HorizontalAlignment.Center, VerticalAlignment.Center)
        .At(HorizontalAlignment.Center, VerticalAlignment.Center)
        .Of(new JS("window"))

          )
    );

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\Uros\Desktop\pomo\Pomona\Views\Shared\PopupMessageYesNo.cshtml"
     using (Html.DevExtreme().NamedTemplate("myPopupContentTemplate"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p id=\"custom_text\"></p>\r\n");
            WriteLiteral(@"        <div id=""popup-bottom"" class=""dx-toolbar dx-widget dx-visibility-change-handler dx-collection dx-popup-bottom"" role=""toolbar"">
                <div class=""dx-toolbar-items-container"">
                    <div class=""dx-toolbar-before"">
                    </div>
                    <div class=""dx-toolbar-center"" style=""margin: 0px 225px 0px 0px; float: right;""></div>
                    <div class=""dx-toolbar-after"">
                        <div class=""dx-item dx-toolbar-item dx-toolbar-button"">
                            <div class=""dx-item-content dx-toolbar-item-content"">
                                <div class=""dx-button dx-button-normal dx-button-mode-contained dx-widget dx-button-has-text"">
                                        ");
#nullable restore
#line 44 "C:\Users\Uros\Desktop\pomo\Pomona\Views\Shared\PopupMessageYesNo.cshtml"
                                    Write(Html.DevExtreme().Button()
                                        .Text("!P! Yes")
                                        .ID("btnYes")
                                        .OnClick("onYes")
                                           );

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                    </div>
                                </div>
                            </div>
                            <div class=""dx-item dx-toolbar-item dx-toolbar-button"">
                                <div class=""dx-item-content dx-toolbar-item-content"">
                                    <div class=""dx-button dx-button-normal dx-button-mode-contained dx-widget dx-button-has-text"">
                                        ");
#nullable restore
#line 55 "C:\Users\Uros\Desktop\pomo\Pomona\Views\Shared\PopupMessageYesNo.cshtml"
                                    Write(Html.DevExtreme().Button()
                                         .Text("!P! No")
                                         .ID("btnNo")
                                         .OnClick("onNo")
                                        );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 66 "C:\Users\Uros\Desktop\pomo\Pomona\Views\Shared\PopupMessageYesNo.cshtml"


    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 100 "C:\Users\Uros\Desktop\pomo\Pomona\Views\Shared\PopupMessageYesNo.cshtml"
                

}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
