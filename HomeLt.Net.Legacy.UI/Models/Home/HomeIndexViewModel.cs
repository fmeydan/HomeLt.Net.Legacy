using HomeLt.Net.Legacy.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeLt.Net.Legacy.UI.Models.Home
{
    public class HomeIndexViewModel
    {
        public List<HomeLt.Net.Legacy.ENTITIES.Home> BestOffer { get; set; }
        public List<HomeLt.Net.Legacy.ENTITIES.Home> FeaturedProperties { get; set; }
        
        public List<Testimonal> Testimonals { get; set; }

    }
}