using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OnlineFoodOrderingSystem
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and servicesD:\cSharp workspace\M4\Virendra Pratap Singh Jhala\Sprint-2\OnlineFoodOrderingSystem\OnlineFoodOrderingSystem\App_Start\WebApiConfig.cs

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            EnableCorsAttribute cors = new EnableCorsAttribute("*","*","*");
            config.EnableCors(cors);
        }
    }
}
