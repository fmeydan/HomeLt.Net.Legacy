using HomeLt.Net.Legacy.BLL.Base;
using HomeLt.Net.Legacy.DAL;
using HomeLt.Net.Legacy.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLt.Net.Legacy.BLL.Postgre
{
    public class UserManager : BaseManager<User>, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
