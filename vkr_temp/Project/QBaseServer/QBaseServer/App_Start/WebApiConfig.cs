using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace QBaseServer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}/{action}",
                defaults: new { action = "Index", id = RouteParameter.Optional }
            );
        }
    }
}
