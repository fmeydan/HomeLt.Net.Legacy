using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLt.Net.Legacy.DAL
{
    public class HomeLtSql : BaseContext
    {
        //TODO şuraya da sql connection string lazım
        public HomeLtSql() : base("name=HomeLtSqlContext") { 
        }
    }
}
