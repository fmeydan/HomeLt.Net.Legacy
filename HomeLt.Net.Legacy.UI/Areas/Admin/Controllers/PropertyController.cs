using HomeLt.Net.Legacy.BLL.Postgre;
using HomeLt.Net.Legacy.UI.Filters;
using HomeLt.Net.Legacy.UI.Models.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeLt.Net.Legacy.UI.Areas.Admin.Controllers
{
    public class PropertyController : Controller
    {
        // GET: Admin/Home
        [AdminFilter]
        public ActionResult List()
        {
            using (HomeManager manager = new HomeManager())
            {
                var list = manager.GetList();
                return View(list);

            }
        }



        [AdminFilter]
        public ActionResult ToggleActive(int id)
        {
            using (HomeManager manager= new HomeManager())
            {
                var property = manager.Get(f => f.HomeId == id);
                property.isAvaible = !property.isAvaible;
                manager.Update(property);

                if (property.isAvaible)
                {
                    TempData["Info"] = Constants.TempDataMessages.CreateTempDataInfo("success", "Property Set as Available");
                }
                else
                {
                    TempData["Info"] = Constants.TempDataMessages.CreateTempDataInfo("success", "Property Set as Unavailable");
                }
                
                return RedirectToAction("List");

            }
           
        }

        [AdminFilter]
        public ActionResult Edit(int id)
        {
            using (HomeManager manager = new HomeManager())
            {
                var property = manager.Get(f => f.HomeId == id);
                return View(property);
            }
        }


        [HttpPost]
        [AdminFilter]
        public ActionResult Edit(AddHomeModel model)
        {

            //TODO
            using (HomeManager manager=new HomeManager())
            {
                var property = manager.Get(f => f.HomeId == model.HomeId);
                property.isApproved = model.isApproved;
                property.Name = model.Name;

            }
           
        }
       
    }
}