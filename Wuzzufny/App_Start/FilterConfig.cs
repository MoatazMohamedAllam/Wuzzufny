using System.Web;
using System.Web.Mvc;
using Wuzzufny.Models;

namespace Wuzzufny
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new ProfileRequiredActionFilter());
           // filters.Add(new RequireHttpsAttribute());
        }
    }
}
