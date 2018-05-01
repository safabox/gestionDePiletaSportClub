using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace gestionDePiletaSportClub
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {


            var setting = config.Formatters.JsonFormatter.SerializerSettings;
            setting.ContractResolver = new CamelCasePropertyNamesContractResolver();
            setting.Formatting = Formatting.Indented;

            config.MapHttpAttributeRoutes();


            config.MessageHandlers.Add(new TokenValidationHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
