namespace AffiliateNetwork.Web.Infrastructure.Helpers
{
    using System.Web;
    using System.Web.Mvc;
    using System.Linq;
    using System.Text;

    public static class HtmlExtensions
    {
        public static IHtmlString PerPageDropDown(this HtmlHelper Html, int? perPage)
        {
            var perPageOptions = new int[] { 1, 2, 3 };
            var result = new StringBuilder();

            result.AppendLine("<select name='perPage'>");

            foreach (var item in perPageOptions)
            {
                result.AppendLine(string.Format("<option value='{0}'", item));

                if(item == perPage)
                {
                    result.AppendLine("selected='selected'");
                }

                result.AppendLine(string.Format(">{0}</option>", item));
            }

            result.AppendLine("</select>");

            return new HtmlString(result.ToString());
        }
    }
}