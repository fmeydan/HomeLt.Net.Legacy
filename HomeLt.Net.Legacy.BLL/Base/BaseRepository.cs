
using HomeLt.Net.Legacy.DAL;
using HomeLt.Net.Legacy.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HomeLt.Net.Legacy.BLL.Postgre
{
    public class BaseRepository<T, C> where T : IEntitiy where C : BaseContext, new()
    {
        BaseContext context = new C();
        public bool Add(T entity)
        {
            using (context)
            {
                var added = context.Entry(entity);
                added.State = EntityState.Added;
                return context.SaveChanges() > 0 ? true : false;
            }

        }

        public bool Delete(T entity)
        {
            using (context)
            {
                var deleted = context.Entry(entity);
                deleted.State = EntityState.Deleted;
                return context.SaveChanges() > 0 ? true : false;

            }
        }

        public bool Update(T entity)
        {
            using (context)
            {
                var updated = context.Entry(entity);
                updated.State = EntityState.Modified;
                return context.SaveChanges() > 0 ? true : false;
            }
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            using (context)
            {
                return context.Set<T>().FirstOrDefault(filter);
            }
        }

        public List<T> GetList(Expression<Func<T, bool>> filter = null)
        {
            using (context)
            {
                return filter == null ? context.Set<T>().ToList() : context.Set<T>().Where(filter).ToList();
            }
        }

    }
}
