#pragma checksum "F:\ASP.core Project\Final Project\MovieBlend\Views\PostDetail\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4d2dbc51109136a12508adf207d64f6f54696a06"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PostDetail_Index), @"mvc.1.0.view", @"/Views/PostDetail/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/PostDetail/Index.cshtml", typeof(AspNetCore.Views_PostDetail_Index))]
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
#line 1 "F:\ASP.core Project\Final Project\MovieBlend\Views\_ViewImports.cshtml"
using MovieBlend;

#line default
#line hidden
#line 2 "F:\ASP.core Project\Final Project\MovieBlend\Views\_ViewImports.cshtml"
using MovieBlend.Models;

#line default
#line hidden
#line 5 "F:\ASP.core Project\Final Project\MovieBlend\Views\PostDetail\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 11 "F:\ASP.core Project\Final Project\MovieBlend\Views\PostDetail\Index.cshtml"
using Humanizer;

#line default
#line hidden
#line 12 "F:\ASP.core Project\Final Project\MovieBlend\Views\PostDetail\Index.cshtml"
using StmlParsing;

#line default
#line hidden
#line 13 "F:\ASP.core Project\Final Project\MovieBlend\Views\PostDetail\Index.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d2dbc51109136a12508adf207d64f6f54696a06", @"/Views/PostDetail/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf50ce4c69a94c4db98bb8e4bc85777f4b1af47a", @"/Views/_ViewImports.cshtml")]
    public class Views_PostDetail_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MovieData>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "F:\ASP.core Project\Final Project\MovieBlend\Views\PostDetail\Index.cshtml"
  
    ViewData["Title"] = Model.Title;

#line default
#line hidden
            BeginContext(199, 240, true);
            WriteLiteral("<script src=\"https://cdnjs.cloudflare.com/ajax/libs/vue/2.3.4/vue.min.js\"></script>\r\n<script src=\"https://cdnjs.cloudflare.com/ajax/libs/axios/0.16.2/axios.min.js\"></script>\r\n<script src=\"https://js.pusher.com/4.4/pusher.min.js\"></script>\r\n");
            EndContext();
            BeginContext(501, 1859, true);
            WriteLiteral(@"<style>
    .user_name {
        font-size: 14px;
        font-weight: bold;
    }

    .comments-list .media {
        border-bottom: 1px dotted #ccc;
    }

    h1 {
        color: snow;
        text-shadow: -1px 0 black, 0 1px black, 1px 0 black, 0 -1px black;
    }

    h3 {
        text-align: center;
        color: snow;
        text-shadow: -1px 0 black, 0 1px black, 1px 0 black, 0 -1px black;
    }

    .poster_name {
        text-align: left;
        color: darkred;
        text-decoration: underline
    }

    section {
        width: 100%;
        float: left;
    }

    .banner-section {
        background-image: url(""https://static.pexels.com/photos/373912/pexels-photo-373912.jpeg"");
        background-size: cover;
        height: 380px;
        left: 0;
        position: absolute;
        top: inherit;
        background-position: 0;
    }

    .post-title-block {
        padding: 100px 0;
    }

        .post-title-block h1 {
            color: #ff");
            WriteLiteral(@"f;
            font-size: 85px;
            font-weight: bold;
            text-transform: capitalize;
        }

        .post-title-block li {
            font-size: 20px;
            color: #fff;
        }

    .image-block {
        float: left;
        width: 100%;
        margin-bottom: 10px;
    }

    .footer-link {
        float: left;
        width: 100%;
        background: #222222;
        text-align: center;
        padding: 30px;
    }

        .footer-link a {
            color: #A9FD00;
            font-size: 18px;
            text-transform: uppercase;
        }

    .div-post {
        margin-top: 45px;
    }

    img {
        all: inherit;
        align-content: center;
        height: 380px;
    }
</style>
<div>
    <section class=""banner-section"">
        <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 2360, "\"", 2407, 2);
            WriteAttributeValue("", 2366, "/PostDetail/ViewImage/", 2366, 22, true);
#line 104 "F:\ASP.core Project\Final Project\MovieBlend\Views\PostDetail\Index.cshtml"
WriteAttributeValue("", 2388, Model.Cover_pic_id, 2388, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2408, 251, true);
            WriteLiteral(" />\r\n    </section>\r\n    <section class=\"post-content-section\">\r\n        <div class=\"container\">\r\n            <div class=\"row\">\r\n                <div class=\"col-lg-12 col-md-12 col-sm-12 post-title-block\">\r\n                    <h1 class=\"text-center\">");
            EndContext();
            BeginContext(2660, 11, false);
#line 110 "F:\ASP.core Project\Final Project\MovieBlend\Views\PostDetail\Index.cshtml"
                                       Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(2671, 32, true);
            WriteLiteral("</h1>\r\n                    <h3> ");
            EndContext();
            BeginContext(2704, 13, false);
#line 111 "F:\ASP.core Project\Final Project\MovieBlend\Views\PostDetail\Index.cshtml"
                    Write(Model.Release);

#line default
#line hidden
            EndContext();
            BeginContext(2717, 3, true);
            WriteLiteral(" | ");
            EndContext();
            BeginContext(2721, 14, false);
#line 111 "F:\ASP.core Project\Final Project\MovieBlend\Views\PostDetail\Index.cshtml"
                                     Write(Model.Language);

#line default
#line hidden
            EndContext();
            BeginContext(2735, 3, true);
            WriteLiteral(" | ");
            EndContext();
            BeginContext(2739, 11, false);
#line 111 "F:\ASP.core Project\Final Project\MovieBlend\Views\PostDetail\Index.cshtml"
                                                       Write(Model.Genre);

#line default
#line hidden
            EndContext();
            BeginContext(2750, 182, true);
            WriteLiteral("</h3>\r\n                </div>\r\n                <div class=\"col-lg-9 col-md-9 col-sm-12 div-post\">\r\n                    <p>\r\n                        <h6 class=\"poster_name\">Posted By ");
            EndContext();
            BeginContext(2933, 15, false);
#line 115 "F:\ASP.core Project\Final Project\MovieBlend\Views\PostDetail\Index.cshtml"
                                                     Write(Model.User_name);

#line default
#line hidden
            EndContext();
            BeginContext(2948, 62, true);
            WriteLiteral("</h6>\r\n                        <h7 class=\"poster_name\">Posted ");
            EndContext();
            BeginContext(3011, 26, false);
#line 116 "F:\ASP.core Project\Final Project\MovieBlend\Views\PostDetail\Index.cshtml"
                                                  Write(Model.Postedate.Humanize());

#line default
#line hidden
            EndContext();
            BeginContext(3037, 37, true);
            WriteLiteral("</h7>\r\n                        <br />");
            EndContext();
            BeginContext(3075, 46, false);
#line 117 "F:\ASP.core Project\Final Project\MovieBlend\Views\PostDetail\Index.cshtml"
                         Write(Html.Raw(@StmlParser.Parse(Model.Description)));

#line default
#line hidden
            EndContext();
            BeginContext(3121, 28, true);
            WriteLiteral("\r\n                    </p>\r\n");
            EndContext();
#line 119 "F:\ASP.core Project\Final Project\MovieBlend\Views\PostDetail\Index.cshtml"
                     if (User.Identity.Name.ToString() == Model.User_name)
                    {


#line default
#line hidden
            BeginContext(3250, 54, true);
            WriteLiteral("                        <button class=\"btn btn-danger\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 3304, "\"", 3417, 3);
            WriteAttributeValue("", 3314, "location.href=\'", 3314, 15, true);
#line 122 "F:\ASP.core Project\Final Project\MovieBlend\Views\PostDetail\Index.cshtml"
WriteAttributeValue("", 3329, Url.Action("Index", "EditData", new { @data = JsonConvert.SerializeObject(Model.Id) }), 3329, 87, false);

#line default
#line hidden
            WriteAttributeValue("", 3416, "\'", 3416, 1, true);
            EndWriteAttribute();
            BeginContext(3418, 48, true);
            WriteLiteral("><i class=\"fa fa-fw fa-edit\"></i>Edit</button>\r\n");
            EndContext();
#line 123 "F:\ASP.core Project\Final Project\MovieBlend\Views\PostDetail\Index.cshtml"
                    }

#line default
#line hidden
            BeginContext(3489, 150, true);
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n    <div class=\"fb-comments\" data-href=\"https://localhost:5001/PostDetail/");
            EndContext();
            BeginContext(3640, 8, false);
#line 128 "F:\ASP.core Project\Final Project\MovieBlend\Views\PostDetail\Index.cshtml"
                                                                     Write(Model.Id);

#line default
#line hidden
            EndContext();
            BeginContext(3648, 51, true);
            WriteLiteral("\" data-width=\"\" data-numposts=\"10\"></div>\r\n</div>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<IdentityUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<IdentityUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MovieData> Html { get; private set; }
    }
}
#pragma warning restore 1591
