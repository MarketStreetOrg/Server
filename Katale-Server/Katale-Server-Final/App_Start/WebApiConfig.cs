using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Katale_Server_Final
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{Action}/{id}",
                  defaults: new { id = RouteParameter.Optional },
                 constraints: new { id = @"^[0-9]+$" }
              
            );

            config.Routes.MapHttpRoute(
            name: "ApiByName",
            routeTemplate: "api/{controller}/{action}/{name}/{id}",
            defaults: new { id = RouteParameter.Optional },
            constraints: new { name = @"^[a-z]+$" }
        );

        }
    }
}
