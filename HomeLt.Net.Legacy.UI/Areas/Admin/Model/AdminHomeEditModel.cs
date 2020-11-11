using HomeLt.Net.Legacy.ENTITIES;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeLt.Net.Legacy.UI.Areas.Admin.Model
{
    public class AdminHomeEditModel
    {
        public HomeLt.Net.Legacy.UI.Models.Property.AddHomeModel AddHomeModel { get; set; }
        public Home Home { get; set; }
        public ICollection<City> Cities { get; set; }
        public ICollection<District> Districts { get; set; }
       

    }
}