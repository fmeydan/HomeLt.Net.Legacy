using HomeLt.Net.Legacy.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeLt.Net.Legacy.UI.Models.UserViewModel
{
    public class UserProfileViewModel
    {
        public ENTITIES.User User { get; set; }
        public List<ENTITIES.Home> Homes { get; set; }
        public List<ENTITIES.Favorite> Favorites { get; set; }
        public List<ENTITIES.Ticket> Tickets { get; set; }
    }
}