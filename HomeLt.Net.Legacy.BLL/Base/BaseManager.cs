using HomeLt.Net.Legacy.BLL.Postgre;
using HomeLt.Net.Legacy.DAL;
using HomeLt.Net.Legacy.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLt.Net.Legacy.BLL.Base
{
    public class BaseManager<E> : BaseRepository<E, HomeLtSql> where E : IEntitiy
    {
    }
}
