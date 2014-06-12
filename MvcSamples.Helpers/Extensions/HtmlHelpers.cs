using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MvcSamples.Helpers.Extensions
{
    public static class HtmlHelpers
    {
        public static string SayHello(this HtmlHelper html)
        {
            return string.Format("Hello, it is {0}", DateTime.Now.ToShortTimeString());
        }

        public static MvcHtmlString BootstrapButton(this HtmlHelper html, string buttonText = null, ButtonType? buttonType = null,
            ButtonSize? buttonSize = null)
        {
            var tagBuilder = new TagBuilder("button");
            tagBuilder.AddCssClass("btn");

            if (buttonType.HasValue)
            {
                tagBuilder.AddCssClass(string.Format("btn-{0}", buttonType.Value.ToString().ToLower()));
            }

            if (buttonSize.HasValue)
            {
                switch (buttonSize)
                {
                    case ButtonSize.Small:
                        tagBuilder.AddCssClass("btn-sm");
                        break;
                    case ButtonSize.Large:
                        tagBuilder.AddCssClass("btn-lg");
                        break;
                }
            }

            tagBuilder.SetInnerText(buttonText ?? "I'm a button");

            return new MvcHtmlString(tagBuilder.ToString());
        }

        public static MvcHtmlString YearSelector<T, TProp>(this HtmlHelper<T> html, Expression<Func<T, TProp>> expression, int rangeFromCurrentYear)
        {
            var currentYear = DateTime.Now.Year;
            var cutOffYear = currentYear - rangeFromCurrentYear + 1;
            var yearList = new List<int>(rangeFromCurrentYear);
            for (int i = currentYear; i >= cutOffYear; i--)
            {
                yearList.Add(i);
            }
            return html.DropDownListFor(expression, new SelectList(yearList));
        }
    }

    public abstract class ContainerBase : IDisposable
    {
        private readonly TextWriter _writer;

        protected ContainerBase(HtmlHelper html)
        {
            _writer = html.ViewContext.Writer;
        }

        protected abstract void OnClosing(TextWriter writer);

        public void Dispose()
        {
            OnClosing(_writer);
        }
    }

    #region Extras
    public enum ButtonType
    {
        Info,
        Danger,
        Warning,
        Primary,
        Success
    }

    public enum ButtonSize
    {
        Small,
        Large
    }
    #endregion
}