using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLt.Net.Legacy.DAL
{
    public class HomeltPostgre : BaseContext
    {
        public HomeltPostgre() : base("name=HomeLtPgContext")
        {
        }
    }
}
