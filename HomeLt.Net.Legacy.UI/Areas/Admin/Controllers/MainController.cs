using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using HomeLt.Net.Legacy.BLL.Postgre;
using HomeLt.Net.Legacy.ENTITIES;
using HomeLt.Net.Legacy.UI.Filters;
using HomeLt.Net.Legacy.UI.Helpers;

namespace HomeLt.Net.Legacy.UI.Areas.Admin.Controllers
{
    public class MainController : Controller
    {
        public ActionResult cookiedelete()
        {
            using (CookieHelper cookieHelper=new CookieHelper())
            {
               
                if (cookieHelper.DeleteCookie("RememberMe"))
                {
                    return RedirectToAction("Login");
                }
              return  RedirectToAction("Index", "Home");
            }
        }
     
        public ActionResult Login()
        {
            using (CookieHelper cookieHelper = new CookieHelper())
            {
                string cookieMail = cookieHelper.GetCookie("RememberMeMail");
                string cookiePass = cookieHelper.GetCookie("RememberMePass");
                if ( cookieMail != null && cookiePass!=null)
                {
                    
                    using (AdminUserManager manager = new AdminUserManager())
                    {
                        var admin = manager.Get(f => f.Email == cookieMail && f.Password == cookiePass);
                        Session.Add(Constants.Sessions.SessionAdmin, admin);
                    }

                        return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpPost]
   
        public ActionResult Login(AdminUser model,string rememberMe)
        {
            
            using (AdminUserManager manager=new AdminUserManager())
            {
                var admin = manager.Get(f => f.Email == model.Email && f.Password == model.Password);
                if (admin!=null)
                {
                    if (rememberMe!=null)
                    {
                        using (CookieHelper cookieHelper=new CookieHelper())
                        {
                            cookieHelper.CreateCookie("RememberMeMail", model.Email);
                            cookieHelper.CreateCookie("RememberMePass", model.Password);
                        }

                    }
                    Session.Add(Constants.Sessions.SessionAdmin,admin);
                    return RedirectToAction("Index");
                }
                TempData["Message"] = Constants.TempDataMessages.CreateTempDataMessage("alert alert-danger", "Invalid Email or Password");
                return View();
            }
            
        }

        // GET: Admin/Main
        [AdminFilter]
        public ActionResult Index()
        { var model = new HomeLt.Net.Legacy.UI.Areas.Admin.Model.AdminIndexModel();
            using (HomeManager manager=new HomeManager())
            {
                model.Homes = manager.GetList();
            }
            using (UserManager manager=new UserManager())
            {
                model.Users = manager.GetList();
            }

            using (TicketManager manager = new TicketManager())
            {
                model.Tickets = manager.GetList();
            }
            return View(model);
        }
    }
}