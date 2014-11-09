namespace AffiliateNetwork.Infrastructure.HtmlHelpers
{
    using System.Collections.Generic;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    public static class PerPageSelector
    {
        public static MvcHtmlString PerPageDropDown(this HtmlHelper htmlHelper, int? perPage)
        {
            var defaultPageSize = int.Parse(htmlHelper.ViewContext.Controller.ViewBag.Settings["ItemsPerPage"]);

            var perPageOptions = new List<SelectListItem>();

            perPageOptions.Add(new SelectListItem()
            {
                Value = "1", 
                Text = "1", 
                Selected = 
                perPage == 1 ? true : false
            });

            for (int i = 1; i <= 7; i++)
			{
                perPageOptions.Add(new SelectListItem()
                {
                    Value = (defaultPageSize * i).ToString(),
                    Text = (defaultPageSize * i).ToString(),
                    Selected = perPage == defaultPageSize * i ? true : false
                });
			}

            return htmlHelper.DropDownList("perPage", perPageOptions, new { onchange = "submit()"});
        }
    }
}