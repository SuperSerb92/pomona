#pragma checksum "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Shared\PopupMessageYesNo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f5821a2e5d6178bdb678b04eb4342ac0dcbf1930"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5821a2e5d6178bdb678b04eb4342ac0dcbf1930", @"/Views/Shared/PopupMessageYesNo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9eeb343440400e3984c17453faa3a0fd9afbfb14", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_PopupMessageYesNo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Shared\PopupMessageYesNo.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 7 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Shared\PopupMessageYesNo.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Shared\PopupMessageYesNo.cshtml"
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
#line 27 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Shared\PopupMessageYesNo.cshtml"
     

    //    groupItems.AddButton().HorizontalAlignment(HorizontalAlignment.Left)
    //                          .ButtonOptions(x => x.ID("AddEditVolumeOk")
    //                          .OnClick("saveVolumeClick")
    //                          .Text(Osa.Unidocs.Shared.ResourceReader.ResourceManager.Proxy.GetValue(32)));


    

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Shared\PopupMessageYesNo.cshtml"
     using (Html.DevExtreme().NamedTemplate("myPopupContentTemplate"))
    {

        

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Shared\PopupMessageYesNo.cshtml"
    Write(Html.DevExtreme().Button().ID("yesPopupButton").Option("HorizontalAlignment", "Center")
                .Text("Da")
                .OnClick("onYes")
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Shared\PopupMessageYesNo.cshtml"
    Write(Html.DevExtreme().Button().ID("noPopupButton")
                .Text("Ne")
                .OnClick("onNo")
        );

#line default
#line hidden
#nullable disable
#nullable restore
#line 80 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Shared\PopupMessageYesNo.cshtml"
                


    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 83 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Shared\PopupMessageYesNo.cshtml"
     



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
