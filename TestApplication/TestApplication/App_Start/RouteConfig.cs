using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace TestApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                "",
                new
                {
                    controller = "Product",
                    action = "List",
                    page = 1
                }
                );

            routes.MapRoute("filtred",
               "{values}",
               new { controller = "Product", action = "List", page = 1 }
               );

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
