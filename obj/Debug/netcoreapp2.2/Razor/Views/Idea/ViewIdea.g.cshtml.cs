#pragma checksum "C:\Users\shawn\OneDrive\Desktop\Coding Dojo\c_sharp\Exam2\Views\Idea\ViewIdea.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f92ec4ad4a8f57db53191cf9eaa16d75c808f84"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Idea_ViewIdea), @"mvc.1.0.view", @"/Views/Idea/ViewIdea.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Idea/ViewIdea.cshtml", typeof(AspNetCore.Views_Idea_ViewIdea))]
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
#line 1 "C:\Users\shawn\OneDrive\Desktop\Coding Dojo\c_sharp\Exam2\Views\_ViewImports.cshtml"
using Exam2;

#line default
#line hidden
#line 1 "C:\Users\shawn\OneDrive\Desktop\Coding Dojo\c_sharp\Exam2\Views\Idea\ViewIdea.cshtml"
using Exam2.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f92ec4ad4a8f57db53191cf9eaa16d75c808f84", @"/Views/Idea/ViewIdea.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e098b516698c4c5922c1cc0f0dd392a04227191", @"/Views/_ViewImports.cshtml")]
    public class Views_Idea_ViewIdea : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Idea>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin:auto;width:970px;height:970px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(35, 37, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            EndContext();
            BeginContext(72, 207, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f92ec4ad4a8f57db53191cf9eaa16d75c808f843755", async() => {
                BeginContext(78, 194, true);
                WriteLiteral("\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"ie=edge\">\r\n    <title>Document</title>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(279, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(281, 1269, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f92ec4ad4a8f57db53191cf9eaa16d75c808f845148", async() => {
                BeginContext(333, 355, true);
                WriteLiteral(@"
    <div>
        <a href=""/Dashboard"" style=""display:inline-block;width:120px;""><button style=""background-color: blue; color:white;"">Dashboard</button></a>
        <a href=""/ProcessLoggingOut""><button style=""background-color:blue;color:white;display:inline-block;"">LogOut</button></a>
    </div>
    <div>
        <p style=""display:inline-block;"">");
                EndContext();
                BeginContext(689, 19, false);
#line 18 "C:\Users\shawn\OneDrive\Desktop\Coding Dojo\c_sharp\Exam2\Views\Idea\ViewIdea.cshtml"
                                    Write(Model.Creator.Alias);

#line default
#line hidden
                EndContext();
                BeginContext(708, 90, true);
                WriteLiteral(" says:</p>\r\n        <p style=\"border: 2px solid black; width:100px;display:inline-block;\">");
                EndContext();
                BeginContext(799, 21, false);
#line 19 "C:\Users\shawn\OneDrive\Desktop\Coding Dojo\c_sharp\Exam2\Views\Idea\ViewIdea.cshtml"
                                                                         Write(Model.IdeaDescription);

#line default
#line hidden
                EndContext();
                BeginContext(820, 86, true);
                WriteLiteral("</p>\r\n    </div>\r\n\r\n\r\n    \r\n    \r\n    <h2>Idea Liked List</h2>\r\n\r\n        <h3>Likers: ");
                EndContext();
                BeginContext(907, 29, false);
#line 27 "C:\Users\shawn\OneDrive\Desktop\Coding Dojo\c_sharp\Exam2\Views\Idea\ViewIdea.cshtml"
               Write(Model.PeopleLikingIdeas.Count);

#line default
#line hidden
                EndContext();
                BeginContext(936, 59, true);
                WriteLiteral("</h3>\r\n\r\n    \r\n        <h3>People Who Like This Post</h3>\r\n");
                EndContext();
#line 31 "C:\Users\shawn\OneDrive\Desktop\Coding Dojo\c_sharp\Exam2\Views\Idea\ViewIdea.cshtml"
             foreach (Association idea in Model.PeopleLikingIdeas)
            {   

#line default
#line hidden
                BeginContext(1081, 143, true);
                WriteLiteral("                <div style=\"display:inline-block;\">\r\n                    <p>Alias</p>\r\n                    <li style=\"list-style-type:none;\"><a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 1224, "\"", 1256, 2);
                WriteAttributeValue("", 1231, "/PersonsIdea/", 1231, 13, true);
#line 35 "C:\Users\shawn\OneDrive\Desktop\Coding Dojo\c_sharp\Exam2\Views\Idea\ViewIdea.cshtml"
WriteAttributeValue("", 1244, idea.IdeaId, 1244, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1257, 1, true);
                WriteLiteral(">");
                EndContext();
                BeginContext(1259, 17, false);
#line 35 "C:\Users\shawn\OneDrive\Desktop\Coding Dojo\c_sharp\Exam2\Views\Idea\ViewIdea.cshtml"
                                                                                     Write(idea.AGuest.Alias);

#line default
#line hidden
                EndContext();
                BeginContext(1276, 175, true);
                WriteLiteral("</a></li>\r\n                </div>\r\n                <div style=\"display:inline-block;\">\r\n                    <p>Name</p>\r\n                    <li style=\"list-style-type:none;\">");
                EndContext();
                BeginContext(1452, 21, false);
#line 39 "C:\Users\shawn\OneDrive\Desktop\Coding Dojo\c_sharp\Exam2\Views\Idea\ViewIdea.cshtml"
                                                 Write(idea.AGuest.FirstName);

#line default
#line hidden
                EndContext();
                BeginContext(1473, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(1475, 20, false);
#line 39 "C:\Users\shawn\OneDrive\Desktop\Coding Dojo\c_sharp\Exam2\Views\Idea\ViewIdea.cshtml"
                                                                        Write(idea.AGuest.LastName);

#line default
#line hidden
                EndContext();
                BeginContext(1495, 31, true);
                WriteLiteral("</li>\r\n                </div>\r\n");
                EndContext();
#line 41 "C:\Users\shawn\OneDrive\Desktop\Coding Dojo\c_sharp\Exam2\Views\Idea\ViewIdea.cshtml"
            }

#line default
#line hidden
                BeginContext(1541, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1550, 9, true);
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Idea> Html { get; private set; }
    }
}
#pragma warning restore 1591