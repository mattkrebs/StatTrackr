using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using StatTrackr.WebApi.Modules;
using Autofac.Integration.WebApi;
using System.Reflection;
using StatTrackr.WebApi.Models.Mappings;
using System.Web.Compilation;
using StatTrackr.WebApi.Controllers;


namespace StatTrackr.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            AutoMapperConfiguration.Configure();

            //Autofac Configuration
            var builder = new Autofac.ContainerBuilder();

            builder.RegisterType<StatLineController>().InstancePerRequest();
            builder.RegisterType<GameController>().InstancePerRequest();
            builder.RegisterType<PlayerController>().InstancePerRequest();
            builder.RegisterType<TeamController>().InstancePerRequest();
            builder.RegisterType<AccountController>().InstancePerRequest();

            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new EFModule());

            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            

        }
    }
}
