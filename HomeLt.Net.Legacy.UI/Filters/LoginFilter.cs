using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeLt.Net.Legacy.UI.Filters
{
  
        public class LoginFilter : FilterAttribute, IActionFilter
        {
            void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
            {

            }

            void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
            {
                var session = filterContext.HttpContext.Session[Constants.Sessions.SessionUser];
                if (session == null)
                {

                  filterContext.Controller.TempData.Add("Message", Constants.TempDataMessages.CreateTempDataMessage("alert alert-danger", "Please login to continue"));
                
               

                filterContext.Result = new RedirectResult("/User/LoginRegister/");
                }
            }
        }
    
}