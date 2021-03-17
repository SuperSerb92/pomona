#pragma checksum "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Login\Registration.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0330503161293143fa2b0c00dadfc3781a88417a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Pomona.Views.Login.Views_Login_Registration), @"mvc.1.0.view", @"/Views/Login/Registration.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0330503161293143fa2b0c00dadfc3781a88417a", @"/Views/Login/Registration.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9eeb343440400e3984c17453faa3a0fd9afbfb14", @"/Views/_ViewImports.cshtml")]
    public class Views_Login_Registration : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Login\Registration.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Login\Registration.cshtml"
   await Html.RenderPartialAsync("PopupMessage"); 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 8 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Login\Registration.cshtml"
   await Html.RenderPartialAsync("PopupMessageWithOnHidden"); 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 10 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Login\Registration.cshtml"
 using (Html.BeginForm())
{
    using (Html.DevExtreme().ValidationGroup())
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Login\Registration.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Login\Registration.cshtml"
    Write(Html.DevExtreme().Form<Pomona.Models.User>().ID("regForm").ColCount(1)
                        .Items(items =>
                        {
                            items.AddGroup()
                            .ColSpan(1)
                            .ColCount(1)
                            .Items(groupItems =>
                            {
                                groupItems.AddSimpleFor(m => m.FirstName)
                                .Label(t => t.Location(FormLabelLocation.Left)
                                .Text("Ime"))
                                .ValidationRules(rules => rules.AddRequired()
                                .Message("Ime obavezno polje"))
                                .Editor(e => e.TextBox().FocusStateEnabled(true)
                                .ElementAttr(new { id = "FirstName",  @class = "focus" }));

                                groupItems.AddSimpleFor(m => m.LastName)
                                .Label(t => t.Location(FormLabelLocation.Left)
                                .Text("Prezime"))
                                .ValidationRules(rules => rules.AddRequired()
                                .Message("Prezime obavezno polje"))
                                .Editor(e => e.TextBox());

                                groupItems.AddSimpleFor(m => m.UserName)
                               .Label(t => t.Location(FormLabelLocation.Left)
                               .Text("Korisničko ime"))
                               .ValidationRules(rules => rules.AddRequired()
                               .Message("UserName obavezno polje"))
                               .Editor(e => e.TextBox());

                                groupItems.AddSimpleFor(m => m.Password)
                                 .Label(t => t.Location(FormLabelLocation.Left)
                                 .Text("Lozinka"))
                                 .ValidationRules(rules => rules.AddRequired()
                                 .Message("Pasword obavezno polje"))
                                 .Editor(e => e.TextBox().Mode(TextBoxMode.Password).Width(560)
                                 .ElementAttr(new { ID = "loginpassword" }));

                                groupItems.AddSimpleFor(m => m.RepeatedPassword)
                                 .Label(t => t.Location(FormLabelLocation.Left)
                                 .Text("Ponovi lozinku"))
                                 .ValidationRules(rules => rules.AddRequired()
                                 .Message("Pasword obavezno polje"))
                                 .Editor(e => e.TextBox().Mode(TextBoxMode.Password)
                                 .ElementAttr(new { ID = "RepeatedPassword" }));

                                groupItems.AddSimpleFor(m => m.Email)
                                .Label(t => t.Location(FormLabelLocation.Left)
                                .Text("E-mail"))
                                .ValidationRules(rules => rules.AddRequired()
                                .Message("Email obavezno polje"))
                                .ValidationRules(r=>r.AddEmail().Message("Neispravan e-mail"))
                                .Editor(e => e.TextBox()
                                .ElementAttr(new { ID = "Email" }));

                                groupItems.AddSimpleFor(m => m.FarmName)
                               .Label(t => t.Location(FormLabelLocation.Left)
                               .Text("Naziv gazdinstva"))
                               .ValidationRules(rules => rules.AddRequired()
                               .Message("FarmName obavezno polje"))
                               .Editor(e => e.TextBox());

                                groupItems.AddSimpleFor(m => m.FarmNo)
                               .Label(t => t.Location(FormLabelLocation.Left)
                               .Text("Broj gazdinstva"))
                               .ValidationRules(rules => rules.AddRequired()
                               .Message("FarmNo obavezno polje"))
                               .Editor(e => e.TextBox());

                                groupItems.AddSimpleFor(m => m.IdGroup)
                                            .ColSpan(1)
                                            .Editor(e => e.SelectBox().ID("IdGroupSelectBox")
                                                  .Width("560px")
                                                  .Placeholder("")
                                                  .SearchEnabled(true)
                                                  .DataSource(d => d.Mvc().Controller("Login").LoadAction("GetGroups").Key("IdGroup"))
                                                  .DisplayExpr("GroupName")
                                                  .ValueExpr("IdGroup"))
                                                  .Label(t => t.Text("Korisnik").Location(FormLabelLocation.Left))
                                                  .ValidationRules(rules => rules.AddRequired()
                                                  .Message("Morate izabrati grupu"));
                            });

                            items.AddGroup()
                         //.ColSpan(2)
                         //.ColCount(2)
                         .ColSpan(1)
                        .ColCount(1)
                        .Items(groupItems =>
                        {
                            groupItems.AddButton().HorizontalAlignment(HorizontalAlignment.Center)
                                                  .ButtonOptions(x => x.ID("RegistrationButton")//.Type(ButtonType.Success)
                                                  .OnClick("OnRegistration")
                                                  .Text("Registruj se"));

                            //groupItems.AddButton().HorizontalAlignment(HorizontalAlignment.Right)
                            //                      .ButtonOptions(x => x.ID("AddEditVolumeCancel").Type(ButtonType.Danger)
                            //                      .OnClick("onCancelRegistration")
                            //                      .Text("Odustani"));
                        });


                        }).FormData(Model)
                );

#line default
#line hidden
#nullable disable
#nullable restore
#line 119 "C:\Users\Filip\Desktop\Pomona\Pomona\Views\Login\Registration.cshtml"
                 

    }


}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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
