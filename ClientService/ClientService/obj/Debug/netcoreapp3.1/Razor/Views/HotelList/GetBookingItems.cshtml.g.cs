#pragma checksum "C:\Users\nikhitha\source\repos\ClientService\ClientService\Views\HotelList\GetBookingItems.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2ca6ccb3b464f7d54a99ea1bccd591c17ffe916c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_HotelList_GetBookingItems), @"mvc.1.0.view", @"/Views/HotelList/GetBookingItems.cshtml")]
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
#line 1 "C:\Users\nikhitha\source\repos\ClientService\ClientService\Views\_ViewImports.cshtml"
using ClientService;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\nikhitha\source\repos\ClientService\ClientService\Views\_ViewImports.cshtml"
using ClientService.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ca6ccb3b464f7d54a99ea1bccd591c17ffe916c", @"/Views/HotelList/GetBookingItems.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00789d2e7e023fa814ef8abb9cdbd92c01f15443", @"/Views/_ViewImports.cshtml")]
    public class Views_HotelList_GetBookingItems : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ClientService.Models.Booking>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\nikhitha\source\repos\ClientService\ClientService\Views\HotelList\GetBookingItems.cshtml"
  
    ViewData["Title"] = "GetBookingItems";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>User ");
#nullable restore
#line 6 "C:\Users\nikhitha\source\repos\ClientService\ClientService\Views\HotelList\GetBookingItems.cshtml"
    Write(ViewBag.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral(" booking details</h1>\r\n<p>\r\n    <h5>Here is your Booking Details Mr./Ms ");
#nullable restore
#line 8 "C:\Users\nikhitha\source\repos\ClientService\ClientService\Views\HotelList\GetBookingItems.cshtml"
                                       Write(ViewBag.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral(".</h5>\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 14 "C:\Users\nikhitha\source\repos\ClientService\ClientService\Views\HotelList\GetBookingItems.cshtml"
           Write(Html.DisplayNameFor(model => model.BookingId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Users\nikhitha\source\repos\ClientService\ClientService\Views\HotelList\GetBookingItems.cshtml"
           Write(Html.DisplayNameFor(model => model.HotelId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "C:\Users\nikhitha\source\repos\ClientService\ClientService\Views\HotelList\GetBookingItems.cshtml"
           Write(Html.DisplayNameFor(model => model.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "C:\Users\nikhitha\source\repos\ClientService\ClientService\Views\HotelList\GetBookingItems.cshtml"
           Write(Html.DisplayNameFor(model => model.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "C:\Users\nikhitha\source\repos\ClientService\ClientService\Views\HotelList\GetBookingItems.cshtml"
           Write(Html.DisplayNameFor(model => model.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "C:\Users\nikhitha\source\repos\ClientService\ClientService\Views\HotelList\GetBookingItems.cshtml"
           Write(Html.DisplayNameFor(model => model.BillAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 35 "C:\Users\nikhitha\source\repos\ClientService\ClientService\Views\HotelList\GetBookingItems.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 39 "C:\Users\nikhitha\source\repos\ClientService\ClientService\Views\HotelList\GetBookingItems.cshtml"
           Write(Html.DisplayFor(modelItem => item.BookingId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 42 "C:\Users\nikhitha\source\repos\ClientService\ClientService\Views\HotelList\GetBookingItems.cshtml"
           Write(Html.DisplayFor(modelItem => item.HotelId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 45 "C:\Users\nikhitha\source\repos\ClientService\ClientService\Views\HotelList\GetBookingItems.cshtml"
           Write(Html.DisplayFor(modelItem => item.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 48 "C:\Users\nikhitha\source\repos\ClientService\ClientService\Views\HotelList\GetBookingItems.cshtml"
           Write(Html.DisplayFor(modelItem => item.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 51 "C:\Users\nikhitha\source\repos\ClientService\ClientService\Views\HotelList\GetBookingItems.cshtml"
           Write(Html.DisplayFor(modelItem => item.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 54 "C:\Users\nikhitha\source\repos\ClientService\ClientService\Views\HotelList\GetBookingItems.cshtml"
           Write(Html.DisplayFor(modelItem => item.BillAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n\r\n        </tr>\r\n");
#nullable restore
#line 58 "C:\Users\nikhitha\source\repos\ClientService\ClientService\Views\HotelList\GetBookingItems.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n<p>\r\n    <h6>Thanks for choosing our service.</h6>\r\n</p>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ClientService.Models.Booking>> Html { get; private set; }
    }
}
#pragma warning restore 1591
