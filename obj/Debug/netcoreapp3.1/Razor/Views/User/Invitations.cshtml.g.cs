#pragma checksum "C:\Users\prakharsingh\Desktop\Execise\MVC\BookStore\Views\User\Invitations.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "68d36612939864e241c8f821c86d7b49676b1e06"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Invitations), @"mvc.1.0.view", @"/Views/User/Invitations.cshtml")]
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
#line 1 "C:\Users\prakharsingh\Desktop\Execise\MVC\BookStore\Views\_ViewImports.cshtml"
using BookStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\prakharsingh\Desktop\Execise\MVC\BookStore\Views\_ViewImports.cshtml"
using BookStore.Models.Book;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\prakharsingh\Desktop\Execise\MVC\BookStore\Views\_ViewImports.cshtml"
using BookStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68d36612939864e241c8f821c86d7b49676b1e06", @"/Views/User/Invitations.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f0e0d43d1039fb505f955101a6b22178c58b04b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_User_Invitations : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\prakharsingh\Desktop\Execise\MVC\BookStore\Views\User\Invitations.cshtml"
  
    ViewData["Title"] = "Invitations";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n \r\n    <div class=\"col-8\">\r\n        <div class=\"card border-0  h-100\">\r\n            \r\n        <div class=\"h3 pb-1\">Upcomming Events</div>\r\n");
#nullable restore
#line 12 "C:\Users\prakharsingh\Desktop\Execise\MVC\BookStore\Views\User\Invitations.cshtml"
             foreach(var item in ViewBag.UpcommingBookEvents)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"card pl-5 pt-1 pb-1 m-2 rounded-pill justify-content-evenly\">\r\n\r\n                        <div class=\"row pb-1 pt-2\">\r\n\r\n                            <div class=\"col-8 h5\">\r\n                                <a");
            BeginWriteAttribute("href", " href=\'", 521, "\'", 582, 1);
#nullable restore
#line 19 "C:\Users\prakharsingh\Desktop\Execise\MVC\BookStore\Views\User\Invitations.cshtml"
WriteAttributeValue("", 528, Url.Action("BookEvent", "User", new { id = item.Id }), 528, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 19 "C:\Users\prakharsingh\Desktop\Execise\MVC\BookStore\Views\User\Invitations.cshtml"
                                                                                            Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                            </div>\r\n                            <div class=\"col-2 pl-3 pr-3 pb-1 pt-1 btn btn-info rounded-pill bg-white text-info\">\r\n                                ");
#nullable restore
#line 22 "C:\Users\prakharsingh\Desktop\Execise\MVC\BookStore\Views\User\Invitations.cshtml"
                            Write(item.Type == 0 ? "Public" : "Private");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                        </div> \r\n\r\n                        \r\n                        <div class=\"row pb-2\">\r\n                            <div class=\"col-6\">\r\n                                Event Date: ");
#nullable restore
#line 29 "C:\Users\prakharsingh\Desktop\Execise\MVC\BookStore\Views\User\Invitations.cshtml"
                                       Write(item.Date.ToString("MMMM dd, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                        \r\n\r\n                </div>\r\n");
#nullable restore
#line 35 "C:\Users\prakharsingh\Desktop\Execise\MVC\BookStore\Views\User\Invitations.cshtml"
                
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n           \r\n        </div>\r\n    </div>\r\n\r\n\r\n    <div class=\"col-4\">\r\n        <div class=\"h5\">Past Events</div>\r\n\r\n        <div class=\"card border-0\">\r\n");
#nullable restore
#line 47 "C:\Users\prakharsingh\Desktop\Execise\MVC\BookStore\Views\User\Invitations.cshtml"
             foreach(var item in ViewBag.PastBookEvents)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"card p-3 m-1  rounded-pill \"> \r\n                    <a");
            BeginWriteAttribute("href", " href=\'", 1563, "\'", 1624, 1);
#nullable restore
#line 50 "C:\Users\prakharsingh\Desktop\Execise\MVC\BookStore\Views\User\Invitations.cshtml"
WriteAttributeValue("", 1570, Url.Action("BookEvent", "User", new { id = item.Id }), 1570, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 50 "C:\Users\prakharsingh\Desktop\Execise\MVC\BookStore\Views\User\Invitations.cshtml"
                                                                                Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                </div>\r\n");
#nullable restore
#line 52 "C:\Users\prakharsingh\Desktop\Execise\MVC\BookStore\Views\User\Invitations.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </div>\r\n    </div>\r\n</div>");
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
