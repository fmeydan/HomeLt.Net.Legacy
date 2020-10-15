using HomeLt.Net.Legacy.BLL.Postgre;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;
using System.Web.Mvc;

namespace HomeLt.Net.Legacy.UI.Controllers
{
    public class AdressController : Controller
    {
        // GET: Adress
        [HttpPost]
        public JsonResult GetDistricts(int id)
        {
      
            using (DistrictManager manager = new DistrictManager())
            {
                var districts = manager.GetList(f => f.CityId == id);

                var jsonDistrict = Json(districts);
                var test = JsonConvert.SerializeObject(districts,Formatting.None,new JsonSerializerSettings() { 
                ReferenceLoopHandling=ReferenceLoopHandling.Ignore});




                return Json(test, JsonRequestBehavior.AllowGet);
            }

        }
    }
}