using System.Web;
using System.Web.Mvc;

namespace BuildSharper.Course402.WebFramework
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
