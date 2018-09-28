using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvdekiBakicim_WebAPI_CaseStudy.DataAccessLayer.Repository
{
    public interface IRepository<T> where T : class 
    {
        IEnumerable<T> GetAll(int count);
        T Insert(T obj);
    }
}
