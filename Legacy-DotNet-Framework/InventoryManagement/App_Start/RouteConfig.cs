using System.Web.Mvc;
using System.Web.Routing;

namespace InventoryManagement
{
    /// <summary>
    /// Legacy Route Configuration - .NET Framework 4.5 MVC pattern
    /// Shows basic routing without modern features
    /// </summary>
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Legacy: Basic route ignore for static files
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Legacy: Simple default route pattern
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            // Legacy: No API routes (no Web API support)
            // Legacy: No attribute routing
            // Legacy: No route constraints
            // Legacy: No area support configured
        }
    }
}