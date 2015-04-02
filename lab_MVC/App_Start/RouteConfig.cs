using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace lab_MVC
{
    public class dataRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            DateTime d;
            return DateTime.TryParse(values[parameterName].ToString(), out d);
        }
    }
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "Default",
              url: "",
              defaults: new { controller = "Products", action = "Index" }
          );

            routes.MapRoute(
                name: "Product",
                url: "Product/{kod}",
                defaults: new { controller = "Products", action = "Product", kod = "AB-100" },
                constraints: new { kod = @"[A-Z,a-z]{2}\-\d{3}" }
            );

            routes.MapRoute(
                name: "Print",
                url: "Product/{kod}/print", //AB - 112
                defaults: new { controller = "Products", action = "Print", kod = "AB-100" },
                constraints: new { kod = @"[A-Z,a-z]{2}\-\d{3}" }
            );

            routes.MapRoute(
                name: "Athletes",
                url: "Products/{athletes}/{page}", //AB - 112
                defaults: new { controller = "Products", action = "Athletes", athletes = "Biathletes", page = 1 },
                constraints: new { athletes = new athletesRouteConstraint(), page = @"\d+" }
            );

            routes.MapRoute(
                name: "Date",
                url: "Products/date/{date}/{page}", //page def = 1
                defaults: new { controller = "Products", action = "Date", date = "2015-01-32", page = 1 },
                constraints: new { date = new dataRouteConstraint(), page = @"\d+" }
            );
        }
    }
}
