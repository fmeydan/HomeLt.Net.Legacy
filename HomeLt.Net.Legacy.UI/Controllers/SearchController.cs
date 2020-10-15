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
        public ActionResult Index(int? propertyType, int? residency,int? saleType)
        {
            
            using (HomeManager manager = new HomeManager())
            {
                if (propertyType != null)
                {
                    var filtered = manager.GetList(f => f.PropertyType == propertyType && f.isAvaible==true);
                    return View(filtered);

                }
                try
                {
                    if (residency != null)
                    {
                        bool residennt = Convert.ToBoolean(residency);
                        var result = manager.GetList(f => f.isApproved == residennt && f.isAvaible==true);
                        return View(result);
                    }

                    if (saleType!=null)
                    {
                        bool saletype = Convert.ToBoolean(saleType);
                        var result = manager.GetList(f => f.SellingType == saletype && f.isAvaible==true);
                        return View(result);
                    }
                }
                catch (Exception e)
                {
                    

                }
                var unfiltered = manager.GetList(f => f.isAvaible == true);
                return View(unfiltered);



            }
          
        }

        [HttpPost]
        public ActionResult Index(SearchFilterModel model)
        {
            using (HomeManager manager= new HomeManager())
            {

                var list = manager.GetList();
                if (model.isApproved!=null)
                {
                    list = list.Where(f => f.isApproved == model.isApproved).ToList();
                }
                if (model.MaxPrice>0)
                {
                    list = list.Where(f => f.Price <= model.MaxPrice).ToList();

                }
                if (model.MinPrice > 0)
                {
                    list = list.Where(f => f.Price >= model.MinPrice).ToList();

                }
                if (model.PropertyType>0)
                {
                    list = list.Where(f => f.PropertyType == model.PropertyType).ToList();

                }

                if (model.Sqft > 0)
                {
                    list = list.Where(f => f.Sqft == model.Sqft).ToList();

                }
                if (model.Bedroom > 0)
                {
                    list = list.Where(f => f.BedroomNumber <= model.Bedroom).ToList();

                }







              
                    //var result = manager.GetList(f => f.Price >= model.MinPrice && f.Price <= model.MaxPrice && f.Sqft >= model.Sqft && f.BedroomNumber == model.Bedroom && f.PropertyType == model.PropertyType && f.isApproved==model.isApproved);
                    return View(list);
               
                
            }
        }


       
    }
}