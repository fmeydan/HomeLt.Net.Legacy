using HomeLt.Net.Legacy.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeLt.Net.Legacy.UI.Areas.Admin.Model
{
    public class AdminHomeEditModel
    {
        public Home Home { get; set; }
        public HttpPostedFileBase[] Gallerry { get; set; }
        public HttpPostedFileBase[] FloorPlans { get; set; }
    }
}