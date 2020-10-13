using HomeLt.Net.Legacy.BLL.Postgre;
using HomeLt.Net.Legacy.UI.Models.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeLt.Net.Legacy.UI.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index(int? propertyType)
        {
            
            using (HomeManager manager = new HomeManager())
            {
                if (propertyType==null)
                {
                    var result = manager.GetList(f => f.isAvaible == true);
                    return View(result);
                }
                    var filtered = manager.GetList(f=>f.PropertyType == propertyType);
                    return View(filtered);
                
                
                
            }
          
        }

        [HttpPost]
        public ActionResult Index(SearchFilterModel model)
        {
            using (HomeManager manager= new HomeManager())
            {
                
                    var result = manager.GetList(f => f.Price >= model.MinPrice && f.Price <= model.MaxPrice && f.Sqft >= model.Sqft && f.BedroomNumber == model.Bedroom && f.PropertyType == model.PropertyType);
                    return View(result);
               
                
            }
        }


       
    }
}