#pragma checksum "C:\Users\SD - Staff\source\repos\MVC-WEB-2\MVC-WEB-Project-Git\MVC WEB Project\Views\Home\OrderDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d04241455de54cc7c5175bdfef2ba09be7ed73d3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_OrderDetail), @"mvc.1.0.view", @"/Views/Home/OrderDetail.cshtml")]
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
#line 1 "C:\Users\SD - Staff\source\repos\MVC-WEB-2\MVC-WEB-Project-Git\MVC WEB Project\Views\_ViewImports.cshtml"
using MVC_WEB_Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\SD - Staff\source\repos\MVC-WEB-2\MVC-WEB-Project-Git\MVC WEB Project\Views\_ViewImports.cshtml"
using MVC_WEB_Project.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d04241455de54cc7c5175bdfef2ba09be7ed73d3", @"/Views/Home/OrderDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b74b0fde7cca874894969f488041155f8c923f1d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_OrderDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MVC_WEB_Project.Models.Order>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\SD - Staff\source\repos\MVC-WEB-2\MVC-WEB-Project-Git\MVC WEB Project\Views\Home\OrderDetail.cshtml"
  
    ViewData["Title"] = "Order Detail";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Order Details</h1>\r\n    <table class=\"table\">\r\n        <tr>\r\n            <th>Order No</th>\r\n            <td>");
#nullable restore
#line 12 "C:\Users\SD - Staff\source\repos\MVC-WEB-2\MVC-WEB-Project-Git\MVC WEB Project\Views\Home\OrderDetail.cshtml"
           Write(Model.OrderNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <th>Order Date</th>\r\n            <td>");
#nullable restore
#line 16 "C:\Users\SD - Staff\source\repos\MVC-WEB-2\MVC-WEB-Project-Git\MVC WEB Project\Views\Home\OrderDetail.cshtml"
           Write(Model.OrderDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <th>Customer Name</th>\r\n            <td>");
#nullable restore
#line 20 "C:\Users\SD - Staff\source\repos\MVC-WEB-2\MVC-WEB-Project-Git\MVC WEB Project\Views\Home\OrderDetail.cshtml"
           Write(Model.CustomerName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <th>Total Amount</th>\r\n            <td>");
#nullable restore
#line 24 "C:\Users\SD - Staff\source\repos\MVC-WEB-2\MVC-WEB-Project-Git\MVC WEB Project\Views\Home\OrderDetail.cshtml"
           Write(Model.TotalAmount.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n    </table>\r\n    <a");
            BeginWriteAttribute("href", " href=\"", 653, "\"", 688, 1);
#nullable restore
#line 27 "C:\Users\SD - Staff\source\repos\MVC-WEB-2\MVC-WEB-Project-Git\MVC WEB Project\Views\Home\OrderDetail.cshtml"
WriteAttributeValue("", 660, Url.Action("Index", "Home"), 660, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">Go back to Orders Page</a>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MVC_WEB_Project.Models.Order> Html { get; private set; }
    }
}
#pragma warning restore 1591
