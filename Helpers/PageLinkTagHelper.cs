using CinemaPortal_ASP.NET_Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Security.Policy;

namespace CinemaPortal_ASP.NET_Core.Helpers
{
    public class PageLinkTagHelper:TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PageViewModel PageModel { get; set; }
        public string PageAction { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            output.TagName = "div";

            // the set of links will represent the url list
            TagBuilder tag = new TagBuilder("url");
            tag.AddCssClass("pagination justify-content-center");

            // create a link to the previous page, if any
            if (PageModel.HasPreviousPage)
            {
                TagBuilder backBtn = CreateBtn(PageModel.PageNumber - 1, urlHelper, "Back to");
                //TagBuilder prevItem = CreateTag(PageModel.PageNumber - 1, urlHelper);
                tag.InnerHtml.AppendHtml(backBtn);
                //tag.InnerHtml.AppendHtml(prevItem);
            }
            // we form three links - to the current, previous and next

            for (int i=1;i<=PageModel.TotalPages;i++)
            {
                TagBuilder currentItem = CreateTag(i, urlHelper);
                tag.InnerHtml.AppendHtml(currentItem);
            }





            // create a link to the next page, if any
            if (PageModel.HasNextPage)
            {
                
                TagBuilder nextBtn = CreateBtn(PageModel.PageNumber + 1, urlHelper, "Forward");
                tag.InnerHtml.AppendHtml(nextBtn);
            }
            output.Content.AppendHtml(tag);
        }

        TagBuilder CreateBtn(int pageNumber,IUrlHelper urlHelper, string btnText)
        {
            TagBuilder link = new TagBuilder("a");
            link.Attributes["href"] = urlHelper.Action(PageAction, new { page = pageNumber });
            link.AddCssClass("page-link");
            link.InnerHtml.Append(btnText);
            return link;
        }

        TagBuilder CreateTag(int pageNumber, IUrlHelper urlHelper)
        {
            TagBuilder item = new TagBuilder("li");
            TagBuilder link = new TagBuilder("a");
            if (pageNumber == this.PageModel.PageNumber)
            {
                item.AddCssClass("active");
            }
            else
            {
                link.Attributes["href"] = urlHelper.Action(PageAction, new { page = pageNumber });
            }
            item.AddCssClass("page-item");
            link.AddCssClass("page-link");
            link.InnerHtml.Append(pageNumber.ToString());
            item.InnerHtml.AppendHtml(link);
            return item;
        }
    }
}
