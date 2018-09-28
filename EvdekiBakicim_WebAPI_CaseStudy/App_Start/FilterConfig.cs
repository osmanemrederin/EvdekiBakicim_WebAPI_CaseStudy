using System.Web;
using System.Web.Mvc;

namespace EvdekiBakicim_WebAPI_CaseStudy
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
