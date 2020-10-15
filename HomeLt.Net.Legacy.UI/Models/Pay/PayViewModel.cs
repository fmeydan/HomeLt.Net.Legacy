using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeLt.Net.Legacy.UI.Models.Pay
{
    public class PayViewModel
    {
        public int Amount { get; set; }
        public string number { get; set; }
        public string name { get; set; }
        public string expiry { get; set; }
        public string cvc { get; set; }
        public int HomeId { get; set; }
        public int UserId { get; set; }
        
    }
}