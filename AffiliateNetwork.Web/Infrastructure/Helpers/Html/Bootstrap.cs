namespace AffiliateNetwork.Web.Infrastructure.Helpers.Html
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    public static class Bootstrap
    {
        public static MvcHtmlString BootstrapFormTextInputFor<TModel, TValue>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TValue>> expression,
            object htmlAttributes = null)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            string propertyName = metaData.PropertyName;
            string displayName = metaData.DisplayName != null ? metaData.DisplayName : metaData.PropertyName;
            string currentValue = metaData.Model == null ? string.Empty : metaData.Model.ToString();

            return BuildFormControl(propertyName, displayName, currentValue, htmlAttributes, GenerateTextBox);
        }

        public static MvcHtmlString BootstrapFormTextAreaFor<TModel, TValue>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TValue>> expression,
            object htmlAttributes = null)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            string propertyName = metaData.PropertyName;
            string displayName = metaData.DisplayName != null ? metaData.DisplayName : metaData.PropertyName;
            string currentValue = metaData.Model == null ? string.Empty : metaData.Model.ToString();

            return BuildFormControl(propertyName, displayName, currentValue, htmlAttributes, GenerateTextArea);
        }

        public static MvcHtmlString BootstrapSubmitButton(this HtmlHelper helper, string value, object htmlAttributes = null)
        {
            var submitButton = new TagBuilder("input");
            submitButton.AddCssClass("btn btn-primary");
            submitButton.Attributes.Add("type", "submit");
            submitButton.Attributes.Add("value", value);
            submitButton.ApplyAttributes(htmlAttributes);
            return new MvcHtmlString(submitButton.ToString());
        }

        private static MvcHtmlString BuildFormControl(string name, string displayName, string value, object htmlAttributes, Func<string, string, object, TagBuilder> inputElement)
        {
            var outerDiv = GenerateOuterDiv();
            var label = GenerateLabel(displayName);
            var innerDiv = GenerateInnerDiv();
            var input = inputElement(name, value, htmlAttributes);

            innerDiv.InnerHtml = input.ToString();
            outerDiv.InnerHtml = label.ToString() + innerDiv.ToString();

            return new MvcHtmlString(outerDiv.ToString());
        }

        private static TagBuilder GenerateLabel(string name)
        {
            var label = new TagBuilder("label");
            label.AddCssClass("control-label col-md-2");
            label.SetInnerText(name);
            return label;
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

        private static TagBuilder GenerateTextBox(string name, string value, object htmlAttributes)
        {
            var input = new TagBuilder("input");
            input.AddCssClass("form-control");
            input.Attributes.Add("type", "text");
            input.Attributes.Add("name", name);
            input.Attributes.Add("placeholder", name);
            input.Attributes.Add("value", value);
            input.Attributes.Add("id", HtmlHelper.GenerateIdFromName(name));
            input.ApplyAttributes(htmlAttributes);

            return input;
        }

        private static TagBuilder GenerateTextArea(string name, string value, object htmlAttributes)
        {
            var textArea = new TagBuilder("textarea");
            textArea.AddCssClass("form-control");
            textArea.Attributes.Add("name", name);
            textArea.Attributes.Add("rows", "15");
            textArea.SetInnerText(value);
            textArea.Attributes.Add("id", HtmlHelper.GenerateIdFromName(name));
            textArea.ApplyAttributes(htmlAttributes);

            return textArea;
        }

        private static void ApplyAttributes(this TagBuilder tagBuilder, object htmlAttributes)
        {
            if (htmlAttributes != null)
            {
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                tagBuilder.MergeAttributes(attributes);
            }
        }
    }
}