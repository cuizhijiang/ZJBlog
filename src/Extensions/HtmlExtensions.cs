using MarkdownSharp;

namespace System.Web.Mvc
{
    public static class HtmlExtensions
    {
        //markdown格式转成html
        public static MvcHtmlString ToHtml(this HtmlHelper html,string markdown) 
        {
            Markdown mark = new Markdown();
            var str = mark.Transform(markdown);
            return MvcHtmlString.Create(str);
        } 
    }
}