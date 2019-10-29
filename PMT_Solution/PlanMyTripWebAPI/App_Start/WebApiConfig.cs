using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PlanMyTripWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
         config.Routes.MapHttpRoute(
             name: "DefaultScreen",
             routeTemplate: "{controller}/{action}/{id}",
         defaults: new { controller = "Home", action = "Index" }
         );
            config.Routes.MapHttpRoute(
                name: "customApi",
                routeTemplate: "api/{controller}/{origin}/{dest}/{departureTime}",
                defaults: new { origin = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{city}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
