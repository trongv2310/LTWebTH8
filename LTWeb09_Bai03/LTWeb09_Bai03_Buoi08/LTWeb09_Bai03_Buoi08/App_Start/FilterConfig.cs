using System.Web;
using System.Web.Mvc;

namespace LTWeb09_Bai03_Buoi08
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
