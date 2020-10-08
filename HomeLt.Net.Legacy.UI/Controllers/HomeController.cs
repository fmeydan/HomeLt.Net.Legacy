using HomeLt.Net.Legacy.BLL.Postgre;
using HomeLt.Net.Legacy.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeLt.Net.Legacy.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            new UserManager().GetList();
            return View();
        }
    }
}