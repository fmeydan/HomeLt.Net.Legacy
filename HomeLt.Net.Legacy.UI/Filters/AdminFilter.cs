using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeLt.Net.Legacy.UI.Filters
{
    public class AdminFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
          
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session[Constants.Sessions.SessionAdmin];
            if (session == null)
            {
                filterContext.Controller.TempData.Remove("Message");
                filterContext.Controller.TempData.Add("Message", Constants.TempDataMessages.CreateTempDataMessage("alert alert-danger", "Please login to continue"));



                filterContext.Result = new RedirectResult("/Admin/Main/Login/");
            }
        }
    }
}