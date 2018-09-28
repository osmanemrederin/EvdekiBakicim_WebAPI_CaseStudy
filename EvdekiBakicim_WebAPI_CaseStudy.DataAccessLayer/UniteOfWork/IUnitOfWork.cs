using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvdekiBakicim_WebAPI_CaseStudy.DataAccessLayer.UniteOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        List<string> SaveChanges();
    }
}
