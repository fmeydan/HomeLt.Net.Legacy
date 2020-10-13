using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeLt.Net.Legacy.UI.Constants
{
    public class EnumPropertyModel
    {
        public int Value { get; set; }
        public string Name { get; set; }
    }

   public enum EnumPropertyType
    {
        Flat,
        Apartment,
        Bungalow,
        Mansion,
        Castle,
        Villa,
        Manor,
        Office

    }


    public static class CastEnumToList
    {
        
        public static List<EnumPropertyModel> EnumList()
        {
            return ((EnumPropertyType[])Enum.GetValues(typeof(EnumPropertyType))).Select(c => new EnumPropertyModel() { Value = (int)c, Name = c.ToString() }).ToList();
        }
       

        

    }
}