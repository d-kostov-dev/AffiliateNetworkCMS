namespace AffiliateNetwork.Infrastructure.HtmlHelpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    public static class FormGroup
    {
        private const string OuterDivClass = "form-group";
        private const string InnerDivClass = "col-md-10";
        private const string InputClass = "form-control";
        private const string ValidationMessageClass = "text-danger";
        private const string LabelClass = "control-label col-md-2";
        private const string InitialSelectText = "-- Select --";

        public static MvcHtmlString FormGroupFor<TModel, TValue>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression)
        {
            var input = htmlHelper.EditorFor(expression, new { htmlAttributes = new { @class = InputClass } });
            var generatedGroup = GenerateGroup(htmlHelper, expression, input);

            return new MvcHtmlString(generatedGroup.ToString());
        }

        public static MvcHtmlString PassowrdFormGroupFor<TModel, TValue>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression)
        {
            var input = htmlHelper.PasswordFor(expression, new { @class = InputClass });
            var generatedGroup = GenerateGroup(htmlHelper, expression, input);

            return new MvcHtmlString(generatedGroup.ToString());
        }

        public static MvcHtmlString EnumFormGroupFor<TModel, TValue>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression)
        {
            var input = htmlHelper.EnumDropDownListFor(expression, htmlAttributes: new { @class = InputClass });
            var generatedGroup = GenerateGroup(htmlHelper, expression, input);

            return new MvcHtmlString(generatedGroup.ToString());
        }

        public static MvcHtmlString DropdownFormGroupFor<TModel, TValue>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression,
            IEnumerable<SelectListItem> collection)
        {
            var input = htmlHelper.DropDownListFor(expression, collection, InitialSelectText, new { @class = InputClass });
            var generatedGroup = GenerateGroup(htmlHelper, expression, input);

            return new MvcHtmlString(generatedGroup.ToString());
        }

        private static MvcHtmlString GenerateGroup<TModel, TValue>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression,
            MvcHtmlString input)
        {
            var outerDiv = GenerateOuterDiv();
            var innerDiv = GenerateInnerDiv();

            innerDiv.InnerHtml += input;

            innerDiv.InnerHtml +=
                htmlHelper.ValidationMessageFor(expression, string.Empty, new { @class = ValidationMessageClass });

            outerDiv.InnerHtml +=
                htmlHelper.LabelFor(expression, htmlAttributes: new { @class = LabelClass });

            outerDiv.InnerHtml += innerDiv.ToString();

            return new MvcHtmlString(outerDiv.ToString());
        }

        private static TagBuilder GenerateOuterDiv()
        {
            var outerDiv = new TagBuilder("div");
            outerDiv.AddCssClass(OuterDivClass);
            return outerDiv;
        }

        private static TagBuilder GenerateInnerDiv()
        {
            var innerDiv = new TagBuilder("div");
            innerDiv.AddCssClass(InnerDivClass);
            return innerDiv;
        }
    }
}