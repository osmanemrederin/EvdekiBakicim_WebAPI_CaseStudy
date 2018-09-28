using EvdekiBakicim_WebAPI_CaseStudy.BusinessLayer.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EvdekiBakicim_WebAPI_CaseStudy.DataAccessLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private MyProjectDBEntities context;
        private DbSet<T> dbSet;

        public Repository()
        {
            context = new MyProjectDBEntities();
            dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll(int count)
        {
            return dbSet
                //.Reverse()
                .Take(count)
                .ToList();
        }

        public T Insert(T obj)
        {
            dbSet.Add(obj);
            return obj;
        }

    }
}
