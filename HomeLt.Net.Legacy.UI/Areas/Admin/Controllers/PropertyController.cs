using HomeLt.Net.Legacy.BLL.Postgre;
using HomeLt.Net.Legacy.ENTITIES;
using HomeLt.Net.Legacy.UI.Areas.Admin.Model;
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
        public ActionResult Edit(AddHomeModel model)
        {
            return View();

        }

        [AdminFilter]
        public ActionResult DeletePropertyMedia(int id)
        {
            
            using (PropertyMediaManager mediaManager = new PropertyMediaManager())
            {
               var media= mediaManager.Get(f => f.PropertyMediaId == id);
                var home = media.Home;

                if(new ImageSaver.ImageSave().DeleteImage(media.Path))
                {
                    mediaManager.Delete(media);
                }
                return RedirectToAction("Edit", new { id = home.HomeId });


            }
        }


        //[HttpPost]
        //[AdminFilter]
        //public ActionResult Edit(AddHomeModel model)
        //{
            
           
        //    //TODO
        //    using (HomeManager manager=new HomeManager())
        //    {
        //        var property = new Home();
        //        property.AddressId = model.AddressId;
        //        property.BathNumber = model.BathNumber;
        //        property.BedroomNumber = model.BedroomNumber;
        //        property.BuildingAge = model.BedroomNumber;
        //        property.CentralHeating = model.CentralHeating;
        //        property.Description = model.Description;
        //        property.ExcerciseRoom = model.ExcerciseRoom;
        //        property.isApproved = model.isApproved;
        //        property.isAvaible = model.isAvailable;
        //        property.Name = model.Name;
        //        property.Parking = model.Parking;
        //        property.Price = model.Price;
        //        property.PropertyType = model.PropertyType;
        //        property.RoomNumber = model.RoomNumber;
        //        property.SellingType = model.SellingType;
        //        property.Sqft = model.Area;
        //        property.TicketPrice = model.TicketPrice;
        //        property.UpdateTime = DateTime.Now;
                
                

        //    }
           
        //}
       
    }
}