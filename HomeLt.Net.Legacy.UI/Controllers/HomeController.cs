using HomeLt.Net.Legacy.BLL.Postgre;
using HomeLt.Net.Legacy.ENTITIES;
using HomeLt.Net.Legacy.UI.Models.Home;
using ImageSaver;
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
            using (CityManager mn = new CityManager())
            {
                var test = mn.GetList();
                var test2 = test.FirstOrDefault().Districts.FirstOrDefault().Name;
            }

            return View();
        }


        public ActionResult AddFav(int homeId, int userId)
        {
            return View();
        }


        public ActionResult AddHome()
        {
            using (CityManager manager = new CityManager())
            {
                var cityList = manager.GetList();
                return View(cityList);
            }

        }

        [HttpPost]
        public ActionResult AddHome(AddHomeModel model/*,HttpPostedFileBase[] floorPlans, HttpPostedFileBase[] gallery*/)
        {
            User currentUser = Session[Constants.Sessions.SessionUser] as User;
            using (HomeManager manager = new HomeManager())
            {
                var adress = new PropertyAdress { DistrictId = model.District, AddressLine1 = model.AdresssDescription };
                if (new PropertyAdressManager().Add(adress))
                {
                    Home home = new Home
                    {
                        BathNumber = model.BathNumber,
                        BedroomNumber = model.BedroomNumber,
                        //BuildingAge = model.BuildingAge,
                        ExcerciseRoom = model.ExcerciseRoom,
                        CentralHeating = model.CentralHeating,
                        Sqft = Convert.ToInt16(model.Area),
                        InsertDate = DateTime.Now.Date,
                        Name = model.Name,
                        Parking = model.Parking,
                        Price = model.Price,
                        TicketPrice = model.TicketPrice,
                        Description = model.Description,
                        SellingType = model.SellingType,
                        PropertyType = model.PropertyType,
                        RoomNumber = model.RoomNumber,
                        UserId = currentUser.UserId,
                        AddressId = adress.PropertyAdressId
                        

                    };


                    if (manager.Add(home))
                    {
                        using (ImageSaver.ImageSave imgs = new ImageSaver.ImageSave())
                        {
                            var floorPlans = imgs.SaveMultiImage(model.FloorPlans, new FileNamer().ConvertTRCharToENChar(model.Name));
                            var gallery = imgs.SaveMultiImage(model.Gallery, new FileNamer().ConvertTRCharToENChar(model.Name));
                            using (PropertyMediaManager propertyMediaManager = new PropertyMediaManager())
                            {
                                foreach (var item in floorPlans)
                                {
                                    propertyMediaManager.Add(new PropertyMedia { HomeId = home.HomeId, Path = item });
                                }
                                foreach (var item in gallery)
                                {
                                    propertyMediaManager.Add(new PropertyMedia { HomeId = home.HomeId, Path = item, MediaType = true });

                                }
                                
                                

                        }
                            
                        }
                       
                       
                    }
                    return RedirectToAction("Profile", "User");
                }
                return View();
            }
        }
    }
}