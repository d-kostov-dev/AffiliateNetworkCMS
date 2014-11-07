using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AffiliateNetwork.Web.Infrastructure.Helpers.Html
{
    public static class FormGroup
    {
        public static MvcHtmlString FormGroupFor<TModel, TValue>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression,
            object htmlAttributes = null)
        {
            var outerDiv = GenerateOuterDiv();
            var innerDiv = GenerateInnerDiv();

            innerDiv.InnerHtml += 
                htmlHelper.EditorFor(expression, new { htmlAttributes = new { @class = "form-control" } });

            innerDiv.InnerHtml += 
                htmlHelper.ValidationMessageFor(expression, "", new { @class = "text-danger" });

            outerDiv.InnerHtml += 
                htmlHelper.LabelFor(expression, htmlAttributes: new { @class = "control-label col-md-2" });
            outerDiv.InnerHtml += innerDiv.ToString();

            return new MvcHtmlString(outerDiv.ToString());

        }

        public static MvcHtmlString EnumFormGroupFor<TModel, TValue>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression,
            object htmlAttributes = null)
        {
            var outerDiv = GenerateOuterDiv();
            var innerDiv = GenerateInnerDiv();

            innerDiv.InnerHtml +=
                htmlHelper.EnumDropDownListFor(expression, htmlAttributes: new { @class = "form-control" });

            innerDiv.InnerHtml +=
                htmlHelper.ValidationMessageFor(expression, "", new { @class = "text-danger" });

            outerDiv.InnerHtml +=
                htmlHelper.LabelFor(expression, htmlAttributes: new { @class = "control-label col-md-2" });
            outerDiv.InnerHtml += innerDiv.ToString();

            return new MvcHtmlString(outerDiv.ToString());

        }

        private static TagBuilder GenerateOuterDiv()
        {
            var outerDiv = new TagBuilder("div");
            outerDiv.AddCssClass("form-group");
            return outerDiv;
        }

        private static TagBuilder GenerateInnerDiv()
        {
            var innerDiv = new TagBuilder("div");
            innerDiv.AddCssClass("col-md-10");
            return innerDiv;
        }
    }
}