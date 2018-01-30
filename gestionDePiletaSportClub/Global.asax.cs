using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using gestionDePiletaSportClub.App_Start;
using AutoMapper;



namespace gestionDePiletaSportClub
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            #region webApi
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
    .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            #endregion

            #region autoMapper
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());
            #endregion

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
