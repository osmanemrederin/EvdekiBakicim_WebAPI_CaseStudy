using EvdekiBakicim_WebAPI_CaseStudy.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;

namespace EvdekiBakicim_WebAPI_CaseStudy.DataAccessLayer.UniteOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private MyProjectDBEntities context;

        public UnitOfWork()
        {
            context = new MyProjectDBEntities();
        }
        public List<string> SaveChanges()
        {
            List<string> errors = new List<string>();
            try
            {
                context.SaveChanges();

            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errors.Add("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }
            return errors;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }
            }
        }
    }
}
