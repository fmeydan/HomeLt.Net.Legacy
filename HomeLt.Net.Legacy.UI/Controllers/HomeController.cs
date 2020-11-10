using HomeLt.Net.Legacy.BLL.Postgre;
using HomeLt.Net.Legacy.ENTITIES;
using HomeLt.Net.Legacy.UI.Filters;
using HomeLt.Net.Legacy.UI.Models.Home;
using HomeLt.Net.Legacy.UI.Models.Property;
using ImageSaver;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace HomeLt.Net.Legacy.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            HomeIndexViewModel model = new HomeIndexViewModel();

            using (HomeManager manager = new HomeManager())
            {

                model.FeaturedProperties = manager.GetList(f=>f.isAvaible==true).Take(6).ToList();
                model.BestOffer = manager.GetList(f => f.isAvaible == true).OrderBy(f=>f.Price).Take(5).ToList();
                
            }
            using (TestimonalManager manager= new TestimonalManager())
            {
                model.Testimonals = manager.GetList().Take(5).ToList();
            }

            return View(model);
        }


        public ActionResult Detail(int id)
        {
            using (HomeManager manager=new HomeManager())
            {
                var home = manager.Get(f => f.HomeId == id);
                return View(home);
            }
        }


        public ActionResult AddFav(int homeId, int userId)
        {
            return View();
        }

        [LoginFilter]
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
                        AddressId = adress.PropertyAdressId,
                        isAvaible = true,
                        isApproved = model.isApproved,
                        TotalTickets = model.TotalTicket
                       
                        

                    };


                    if (manager.Add(home))
                    {
                        using (ImageSaver.ImageSave imgs = new ImageSaver.ImageSave())
                        {
                            var floorPlans = imgs.SaveMultiImage(model.FloorPlans, new FileNamer().ConvertTRCharToENChar(model.Name));
                            var gallery = imgs.SaveMultiImage(model.Gallery, new FileNamer().ConvertTRCharToENChar(model.Name));
                            var propertyPapers = imgs.SaveMultiImage(model.PropertyPapers, new FileNamer().ConvertTRCharToENChar(model.Name));
                            using (PropertyMediaManager propertyMediaManager = new PropertyMediaManager())
                            {
                                foreach (var item in floorPlans)
                                {
                                    propertyMediaManager.Add(new PropertyMedia { HomeId = home.HomeId, Path = item,MediaType=Convert.ToInt16(Constants.EnumMediaType.FloorPlans) });
                                }
                                foreach (var item in gallery)
                                {
                                    propertyMediaManager.Add(new PropertyMedia { HomeId = home.HomeId, Path = item, MediaType =Convert.ToInt16(Constants.EnumMediaType.Galerry) });

                                }
                                foreach (var item in propertyPapers)
                                {
                                    propertyMediaManager.Add(new PropertyMedia { HomeId = home.HomeId, Path = item, MediaType = Convert.ToInt16(Constants.EnumMediaType.PropertyPapers) });
                                }
                                
                                

                        }
                            
                        }
                       
                       
                    }
                    return RedirectToAction("Profile", "User");
                }
                return View();
            }
        }






        public ActionResult ChangeLang(string lang)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = lang;
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }
    }
}