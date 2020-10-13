using HomeLt.Net.Legacy.BLL.Postgre;
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
            return View();
        }


        public ActionResult AddFav(int homeId,int userId)
        {
            return View();
        }


        public ActionResult AddHome()
        {
            using (CityManager manager = new CityManager() )
            {
                var cityList = manager.GetList();
                return View(cityList);
            }
            
        }
    }
}