using System.Web;
using System.Web.Mvc;

namespace Book_Raven
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
            // This filter ensure the web app is not accessable from non secure channel
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
