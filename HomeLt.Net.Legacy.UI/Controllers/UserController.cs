using HomeLt.Net.Legacy.BLL.Postgre;
using HomeLt.Net.Legacy.UI.Models;
using HomeLt.Net.Legacy.UI.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeLt.Net.Legacy.UI.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login(LoginViewModel model)
        {
            using (UserManager manager = new UserManager())
            {
                var result = manager.Get(f => f.Email == model.Email && f.Password == model.Password);
                if (result != null)
                {
                    Session.Add(Constants.Sessions.SessionUser, result);

                }
                return RedirectToAction("Index", "Home");
            }
        }

        public JsonResult Register(RegisterViewModel model)
        {
            using (UserManager manager = new UserManager())
            {
                var result = manager.Add(new ENTITIES.User
                {
                    Email = model.Email,
                    Password = model.Password,
                    ActivationCode = new Guid()
                });
                return result == true ? Json("Success") : Json("Fail");
            }


        }
    }
}