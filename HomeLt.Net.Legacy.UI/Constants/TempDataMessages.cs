using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeLt.Net.Legacy.UI.Constants
{
    public static class TempDataMessages
    {
        /// <summary>
        /// Creates tempdata messages
        /// </summary>
        /// <param name="classAttribute"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static TempDataDictionary CreateTempDataMessage(string classAttribute,string message)
        {
            TempDataDictionary result = new TempDataDictionary { { "class", classAttribute }, { "msg", message } };
            return result;
        }
      

}
}