
using HomeLt.Net.Legacy.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace HomeLt.Net.Legacy.BLL.Postgre
{
    public class BaseRepository<T, C> where T : class where C : BaseContext, new()
    {
       protected readonly BaseContext context = new C();
        public bool Add(T entity)
        {
           
                var added = context.Entry(entity);
                added.State = EntityState.Added;
                return context.SaveChanges() > 0 ? true : false;
            

        }

        public bool Delete(T entity)
        {
            
                var deleted = context.Entry(entity);
                deleted.State = EntityState.Deleted;
                return context.SaveChanges() > 0 ? true : false;

           
        }

        public bool Update(T entity)
        {
            
                var updated = context.Entry(entity);
                updated.State = EntityState.Modified;
            return context.SaveChanges() > 0 ? true : false;
           
        }

        public T Get(Expression<Func<T, bool>> filter, string includes = "")
        {
           
                if (!string.IsNullOrEmpty(includes))
                {
                    return context.Set<T>().Include(includes).FirstOrDefault(filter);

                }
                return context.Set<T>().FirstOrDefault(filter);

        }


        public List<T> GetList(Expression<Func<T, bool>> filter = null)
        {
            
                return filter == null ? context.Set<T>().ToList() : context.Set<T>().Where(filter).ToList();
            
        }

        public List<T> GetList(string incldes,Expression<Func<T, bool>> filter = null)
        {
            
                return filter == null ? context.Set<T>().Include(incldes).ToList() : context.Set<T>().Where(filter).Include(incldes).ToList();
            
        }

    }
}
