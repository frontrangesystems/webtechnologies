using System.Web.Mvc;
using System.Web.Routing;

namespace FrontRangeSystems.WebTechnologies.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("angular1", "angular1/{*catchall}", new { controller = "Home", action = "Angular1" });
            routes.MapRoute("angular2", "angular2/{*catchall}", new { controller = "Home", action = "Angular2" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
