using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeLt.Net.Legacy.UI.Models.Search
{
    public class SearchFilterModel
    {
        public short PropertyType { get; set; }
        public short Bedroom { get; set; }
        public int Sqft { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public bool isApproved { get; set; }

    }
}