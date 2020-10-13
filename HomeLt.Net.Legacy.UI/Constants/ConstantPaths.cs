using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeLt.Net.Legacy.UI.Constants
{
    public static class ConstantPaths
    {
        public static string UserImagePath = HttpContext.Current.Server.MapPath("~/Content/Media/Users/");
        public static string HomeImagePath = HttpContext.Current.Server.MapPath("~/Content/Media/Homes/");
    }
}