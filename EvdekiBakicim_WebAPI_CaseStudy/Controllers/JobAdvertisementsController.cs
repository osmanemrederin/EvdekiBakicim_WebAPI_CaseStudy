using EvdekiBakicim_WebAPI_CaseStudy.BusinessLayer.Models;
using EvdekiBakicim_WebAPI_CaseStudy.DataAccessLayer.Repository;
using EvdekiBakicim_WebAPI_CaseStudy.DataAccessLayer.UniteOfWork;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EvdekiBakicim_WebAPI_CaseStudy.Controllers
{
    public class JobAdvertisementsController : ApiController
    {
        private IRepository<JobAdvertisement> _JobAdvertisementrepository = null;
        private IUnitOfWork _UnitOfWork = null;

        public JobAdvertisementsController()
        {
            _JobAdvertisementrepository = new Repository<JobAdvertisement>();
            _UnitOfWork = new UnitOfWork();
        }

        public HttpResponseMessage Get()
        {
            var result = _JobAdvertisementrepository.GetAll(100);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }


        public HttpResponseMessage Get(int count)
        {
            var result = _JobAdvertisementrepository.GetAll(count);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        [HttpPost]
        public HttpResponseMessage Post(JObject jsonResult)
        {
            List<string> errors = new List<string>();
            HttpResponseMessage response;
            JobAdvertisement jobAdvertisement = JsonConvert.DeserializeObject<JobAdvertisement>(jsonResult.ToString());
            var result = _JobAdvertisementrepository.Insert(jobAdvertisement);
            errors = _UnitOfWork.SaveChanges();
            if (errors.Count == 0)
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            else
                response = Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            return response;
        }

    }
}