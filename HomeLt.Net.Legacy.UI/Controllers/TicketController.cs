﻿using HomeLt.Net.Legacy.BLL.Postgre;
using HomeLt.Net.Legacy.ENTITIES;
using HomeLt.Net.Legacy.UI.Filters;
using HomeLt.Net.Legacy.UI.Models.Pay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeLt.Net.Legacy.UI.Controllers
{
    public class TicketController : Controller
    {
        // GET: Ticket
        [LoginFilter]
        public ActionResult Buy(int id)
        {
            var currentUser = Session[Constants.Sessions.SessionUser] as User;
            Home home = new Home();
            using (HomeManager manager= new HomeManager())
            {
                home = manager.Get(f => f.HomeId == id);
            }

            return View(home);
        }


        [LoginFilter]
        [HttpPost]
        public ActionResult Pay(PayViewModel model)
        {
            var ticketList = new List<Ticket>();
            var currentUser = Session[Constants.Sessions.SessionUser] as User;
            using (TicketManager ticketManager=new TicketManager())
            {
                int amount = model.Amount==0? 1:model.Amount;
                for (int i = 1; i <= amount; i++)
                {
                    Ticket ticket = new Ticket();
                    ticket.HomeId = model.HomeId;
                   

                    ticket.TicketCode = Guid.NewGuid().ToString();
                    ticket.UserId = currentUser.UserId;
                    
                    ticketManager.Add(ticket);
                    ticketList.Add(ticket);

                }
                
            }
            TempData["ticketList"] = ticketList;

            return RedirectToAction("Summary");
        }

        public ActionResult Summary()
        {
           
            List<Ticket> tickets = TempData["ticketList"] as List<Ticket>;
            if (tickets==null)
            {
                return RedirectToAction("/Search/Index");
            }
            return View(tickets);
        }

    }
}