#pragma checksum "C:\pomona\Pomona\Views\TreeViewPomona\TreeViewPomona.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "312a83b0de08c6347b86e2fbaae6d09fe4186a24"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Pomona.Views.TreeViewPomona.Views_TreeViewPomona_TreeViewPomona), @"mvc.1.0.view", @"/Views/TreeViewPomona/TreeViewPomona.cshtml")]
namespace Pomona.Views.TreeViewPomona
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
#line 1 "C:\pomona\Pomona\Views\_ViewImports.cshtml"
using Pomona;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\pomona\Pomona\Views\_ViewImports.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"312a83b0de08c6347b86e2fbaae6d09fe4186a24", @"/Views/TreeViewPomona/TreeViewPomona.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9eeb343440400e3984c17453faa3a0fd9afbfb14", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_TreeViewPomona_TreeViewPomona : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\pomona\Pomona\Views\TreeViewPomona\TreeViewPomona.cshtml"
Write(Html.DevExtreme().TreeView()
    .ID("treeViewPomona")
    .DataSource(d => d.Mvc().Controller("TreeViewPomona").LoadAction("Get"))
    .DataStructure(TreeViewDataStructure.Plain)
    .ParentIdExpr("ParentId")
    .KeyExpr("ID")
    .DisplayExpr("Text")
    .ExpandedExpr("Expanded")
    .Width(260)
    .SelectionMode(NavSelectionMode.Single)
    .SelectByClick(true)   
   .FocusStateEnabled(false) 
    .OnItemClick("TreeViewPomonaItemClick")
);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
