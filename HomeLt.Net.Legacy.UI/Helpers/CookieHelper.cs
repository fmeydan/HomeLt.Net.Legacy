using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeLt.Net.Legacy.UI.Helpers
{
    public class CookieHelper:IDisposable
    {
        private bool disposedValue;

        public bool CreateCookie(string name,string value)
        {
            if (name!=null&&value!=null)
            {
                HttpCookie cookie = new HttpCookie(name, value);
                HttpContext.Current.Response.Cookies.Add(cookie);
                return true;
            }

            return false;
           
        }



        public string GetCookie(string name)
        {
           
                var cookie= HttpContext.Current.Request.Cookies.Get(name);
            if (cookie!=null)
            {
                return cookie.Value;
            }
            return null;
               
           
        }


        public bool DeleteCookie(string name)
        {
            if (name!=null)
            {
                HttpContext.Current.Response.Cookies[name].Expires = DateTime.Now.AddDays(-1);
                var test = HttpContext.Current.Request.Cookies.Get(name);
               return HttpContext.Current.Request.Cookies.Get(name) == null ? true : false;
                
            }
            return false;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~CookieHelper()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}