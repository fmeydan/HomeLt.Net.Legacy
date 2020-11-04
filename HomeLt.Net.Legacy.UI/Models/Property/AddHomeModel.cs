using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HomeLt.Net.Legacy.UI.Models.Property
{
    public class AddHomeModel
    {
        public int HomeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal TicketPrice { get; set; }
        public short RoomNumber { get; set; }
        public short BedroomNumber { get; set; }
        public short BathNumber { get; set; }
        
        public short Area { get; set; }
        public short PropertyType { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public DateTime InsertDate { get; set; }
        public string BuildingAge { get; set; }
        [DefaultValue(false)]
        public bool Parking { get; set; }
        [DefaultValue(false)]
        public bool CentralHeating { get; set; }
        [DefaultValue(false)]
        public bool ExcerciseRoom { get; set; }
        [DefaultValue(true)]
        public bool SellingType { get; set; }

        [DefaultValue(true)]
        public bool isAvailable { get; set; }

        [DefaultValue(false)]
        public bool isApproved { get; set; }

        public HttpPostedFileBase[] Gallery  { get; set; }
        public HttpPostedFileBase[] FloorPlans { get; set; }
        
        public string VideoUrl { get; set; }
        public string GoogleMapAdress { get; set; }
        public int District { get; set; }
        public int City { get; set; }
        public string Street { get; set; }
        public string AdresssDescription { get; set; }

    }
}