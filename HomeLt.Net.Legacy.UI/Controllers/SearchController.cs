using HomeLt.Net.Legacy.BLL.Postgre;
using HomeLt.Net.Legacy.UI.Models.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;

namespace HomeLt.Net.Legacy.UI.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        [HttpGet]
        public ActionResult Index(/*int? propertyType, int? residency,int? saleType,int? count,int? pageNumber,int? cityId*/ SearchFilterModel model)
       {
            
            using (HomeManager manager = new HomeManager())
            {
                if (model.PropertyType == null && model.Residency==null&&model.SaleType==null)
                {
                    var unfiltered = manager.GetList(f => f.isAvaible == true);
                    unfiltered = unfiltered.Take(10).ToList();
                    return View(unfiltered);
                   
                }
                else
                {
                    
                    try
                    {
                        if (model.PropertyType!=null)
                        {
                            var filtered = manager.GetList(f => f.PropertyType == model.PropertyType && f.isAvaible == true).Take(10).ToList();
                            return View(filtered);

                        }
                        if (model.Residency != null)
                        {
                            bool residennt = Convert.ToBoolean(model.Residency);
                            var result = manager.GetList(f => f.isApproved == residennt && f.isAvaible == true).Take(10).ToList();
                            return View(result);
                        }

                        if (model.SaleType != null)
                        {
                            bool saletype = Convert.ToBoolean(model.SaleType);
                            var result = manager.GetList(f => f.SellingType == saletype && f.isAvaible == true).Take(10).ToList();
                            return View(result);
                        }
                        if (model.CityId!=null)
                        {
                            var result = manager.GetList(f => f.Address.District.City.CityId == model.CityId);
                            return View(result);
                        }
                       
                    }
                    catch (Exception e)
                    {


                    }




                }

                return View (manager.GetList(f => f.isAvaible == true).Take(10));
            }
               
          
        }



        

        [HttpPost]
        public ActionResult SearchWithFilter(SearchFilterModel model)
        {
            using (HomeManager manager= new HomeManager())
            {

                var list = manager.GetList(f=>f.isAvaible==true);
                if (model.isApproved!=null)
                {
                    list = list.Where(f => f.isApproved == model.isApproved).ToList();
                }
                if (model.MaxPrice!=null && model.MaxPrice>0)
                {
                    list = list.Where(f => f.Price <= model.MaxPrice).ToList();

                }
                if (model.MinPrice > 0 && model.MinPrice!=null)
                {
                    list = list.Where(f => f.Price >= model.MinPrice).ToList();

                }
                if (model.PropertyType!=null)
                {
                    list = list.Where(f => f.PropertyType == model.PropertyType).ToList();

                }

                if (model.Sqft > 0 && model.Sqft!=null)
                {
                    list = list.Where(f => f.Sqft == model.Sqft).ToList();

                }
                if (model.Bedroom !=null)
                {
                    list = list.Where(f => f.BedroomNumber == model.Bedroom).ToList();

                }







              
                    //var result = manager.GetList(f => f.Price >= model.MinPrice && f.Price <= model.MaxPrice && f.Sqft >= model.Sqft && f.BedroomNumber == model.Bedroom && f.PropertyType == model.PropertyType && f.isApproved==model.isApproved);
                    return View(list);
               
                
            }
        }



        public void FilterCount(int count,int pageNumber)
        {

        }

       
    }
}