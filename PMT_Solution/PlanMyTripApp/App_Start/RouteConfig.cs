using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PlanMyTripApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[]{"PlanMyTripApp.Controllers"}
                );
                routes.MapRoute(
                name: "AddFlight",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Flight", action = "AddFlight", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "SearchFlight",
               url: "{controller}/{action}/{origin}/{dest}/{dtime}",
               defaults: new { controller = "Schedule", action = "SearchFlights" }
               );
        }
    }
}
