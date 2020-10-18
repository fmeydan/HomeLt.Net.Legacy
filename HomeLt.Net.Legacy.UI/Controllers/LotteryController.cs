using HomeLt.Net.Legacy.BLL.Postgre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeLt.Net.Legacy.UI.Controllers
{
    public class LotteryController : Controller
    {
        // GET: Lottary
        public ActionResult Results()
        {
            using (TicketManager manager= new TicketManager() )
            {
                var list = manager.GetList(f => f.isWin == true);
                return View(list);

            }
        }
    }
}