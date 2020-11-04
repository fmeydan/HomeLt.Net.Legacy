using HomeLt.Net.Legacy.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeLt.Net.Legacy.UI.Areas.Admin.Model
{
    public class AdminIndexModel
    {
        public List<Home> Homes { get; set; }
        public List<User> Users { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}