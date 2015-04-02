using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Routing;
using Newtonsoft.Json.Schema;

namespace lab_MVC
{
    

    public class athletesRouteConstraint : IRouteConstraint
    {

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {

            var regex = new Regex(@"[A-Z,a-z]+");

            if (values[parameterName].ToString() == "date")
                return false;
            return regex.Matches(values[parameterName].ToString()).Count != 0;
        }
    }
}