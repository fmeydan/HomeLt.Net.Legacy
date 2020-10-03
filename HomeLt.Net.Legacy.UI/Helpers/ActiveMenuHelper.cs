using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeLt.Net.Legacy.UI.Helpers
{
    public static class ActiveMenuHelper
    {
        public static MvcHtmlString MenuLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string areaName,string classNames)
        {
            var currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            var currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
            var currentArea = htmlHelper.ViewContext.RouteData.DataTokens["area"];
            

            var builder = new TagBuilder("li")
            {
               
                //InnerHtml = htmlHelper.ActionLink(linkText, actionName, controllerName).ToHtmlString()
                InnerHtml = "<a class='"+classNames+"' href=\"" + new UrlHelper(htmlHelper.ViewContext.RequestContext).Action(actionName, controllerName, new { area = areaName }).ToString() + "\">" + linkText + "</a>"
            };

            if (String.Equals(controllerName, currentController, StringComparison.CurrentCultureIgnoreCase) && String.Equals(actionName, currentAction, StringComparison.CurrentCultureIgnoreCase))
                builder.AddCssClass("active nav-item");

            return new MvcHtmlString(builder.ToString());
        }
    }
}