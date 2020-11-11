using HomeLt.Net.Legacy.BLL.Postgre;
using HomeLt.Net.Legacy.ENTITIES;
using HomeLt.Net.Legacy.UI.Areas.Admin.Model;
using HomeLt.Net.Legacy.UI.Filters;
using HomeLt.Net.Legacy.UI.Models.Property;
using ImageSaver;
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
            AdminHomeEditModel model = new AdminHomeEditModel();
            
            using (HomeManager manager = new HomeManager())
            {
                model.Home= manager.Get(f => f.HomeId == id);
             
            }
            using (CityManager manager=new CityManager())
            {
                model.Cities = manager.GetList();
            }
            using (DistrictManager manager=new DistrictManager())
            {
                model.Districts = manager.GetList(f => f.CityId == model.Home.Address.District.CityId);
            }
            return View(model);
        }
      
        [HttpPost]
        public ActionResult Edit(AddHomeModel model)
        {
            
            using (HomeManager manager=new HomeManager())
            {
                var property = new Home();
                property = manager.Get(f => f.HomeId == model.HomeId);
            
            var adress = new PropertyAdress();
            model.UserId = property.UserId;
            using (PropertyAdressManager adressManager=new PropertyAdressManager()) 
            {
                adress = adressManager.Get(f => f.PropertyAdressId == property.AddressId);
                adress.DistrictId = model.DistrictId;
                adress.AddressLine1 = model.Street;
                adress.AddressLine2 = model.AdresssDescription;
                    adressManager.Update(adress);
            }
            property.BathNumber = model.BathNumber;
            property.BedroomNumber = model.BedroomNumber;
            //BuildingAge = model.BuildingAge,
            property.ExcerciseRoom = model.ExcerciseRoom;
            property.CentralHeating = model.CentralHeating;
            property.Sqft = Convert.ToInt16(model.Area);
            property.InsertDate = DateTime.Now.Date;
            property.Name = model.Name;
            property.Parking = model.Parking;
            property.Price = model.Price;
            property.TicketPrice = model.TicketPrice;
            property.Description = model.Description;
            property.SellingType = model.SellingType;
            property.PropertyType = model.PropertyType;
            property.RoomNumber = model.RoomNumber;
            property.SellingType = model.SellingType;
            property.AddressId = adress.PropertyAdressId;
            property.isAvaible = model.isAvailable;
            property.isApproved = model.isApproved;
            property.TotalTickets = model.TotalTicket;
                property.UpdateTime = DateTime.Now;

                if (manager.Update(property))
                {
                    using (ImageSaver.ImageSave imgs = new ImageSaver.ImageSave())
                    {
                        
                        var floorPlans = imgs.SaveMultiImage(model.FloorPlans, new FileNamer().ConvertTRCharToENChar(model.Name));
                        var gallery = imgs.SaveMultiImage(model.Gallery, new FileNamer().ConvertTRCharToENChar(model.Name));
                        var propertyPapers = imgs.SaveMultiImage(model.PropertyPapers, new FileNamer().ConvertTRCharToENChar(model.Name));
                        using (PropertyMediaManager propertyMediaManager = new PropertyMediaManager())
                        {
                            if (floorPlans[0]!=null)
                            {

                           
                            foreach (var item in floorPlans)
                            {
                                propertyMediaManager.Add(new PropertyMedia { HomeId = property.HomeId, Path = item, MediaType = Convert.ToInt16(Constants.EnumMediaType.FloorPlans) });
                            }
                            }
                            if (gallery[0]!=null)
                            {

                            
                            foreach (var item in gallery)
                            {
                                propertyMediaManager.Add(new PropertyMedia { HomeId = property.HomeId, Path = item, MediaType = Convert.ToInt16(Constants.EnumMediaType.Galerry) });

                            }
                            }
                            if (propertyPapers[0]!=null)
                            {

                          
                            foreach (var item in propertyPapers)
                            {
                                propertyMediaManager.Add(new PropertyMedia { HomeId = property.HomeId, Path = item, MediaType = Convert.ToInt16(Constants.EnumMediaType.PropertyPapers) });
                            }

                            }

                        }

                    }


                }
            }
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


       
    }
}