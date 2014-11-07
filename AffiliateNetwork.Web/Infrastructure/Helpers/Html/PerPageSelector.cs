namespace AffiliateNetwork.Web.Infrastructure.Helpers.Html
{
    using System.Text;
    using System.Web;
    using System.Web.Mvc;

    public static class PerPageSelector
    {
        public static IHtmlString PerPageDropDown(this HtmlHelper Html, int? perPage)
        {
            var perPageOptions = new int[] { 1, 2, 3 };
            var result = new StringBuilder();

            result.AppendLine("<select onchange='submit()' name='perPage'>");

            foreach (var item in perPageOptions)
            {
                result.AppendLine(string.Format("<option value='{0}'", item));

                if (item == perPage)
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