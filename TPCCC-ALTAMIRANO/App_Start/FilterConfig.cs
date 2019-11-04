using System.Web;
using System.Web.Mvc;

namespace TPCCC_ALTAMIRANO
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
