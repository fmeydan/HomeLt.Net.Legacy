﻿using HomeLt.Net.Legacy.DAL;
using HomeLt.Net.Legacy.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HomeLt.Net.Legacy.BLL.Postgre
{
    public class UserManager : BaseRepository<User, HomeltPostgre>, IDisposable
    {
        private bool disposedValue;

        

        

        public bool CheckUser(string email)
        {
            var result=context.User.FirstOrDefault(f=>f.Email==email);
            if (result!=null)
            {
                return true;
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
        // ~UserManager()
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
