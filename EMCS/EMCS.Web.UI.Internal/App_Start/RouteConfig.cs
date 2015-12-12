using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EMCS.Web.UI.Internal
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute( "{resource}.axd/{*pathInfo}" );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Reservation", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Equipment",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Asset", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}