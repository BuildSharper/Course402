using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using BuildSharper.Course402.WebFramework.Services;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace BuildSharper.Course402.WebFramework
{
    public static class Configuration
    {
        public static void Configure(HttpConfiguration config)
        {
            Configure(config, false);
        }

        public static void Configure(HttpConfiguration config, bool isSelfHosted)
        {
            Configure(config, isSelfHosted, null);
        }

        public static void Configure(HttpConfiguration config, bool isSelfHosted, Action<ContainerBuilder> builderAction)
        {
            ConfigureMediaTypeFormatters(config);

            ConfigureDependencyInjection(config, builderAction);
        }

        private static void ConfigureMediaTypeFormatters(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.Indent = false;
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }

        public static void ConfigureDependencyInjection(HttpConfiguration config, Action<ContainerBuilder> builderAction)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterAssemblyTypes(typeof(DbLogService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces()
               .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
               .SingleInstance();

            builder.RegisterWebApiFilterProvider(config);

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); //Set the MVC DependencyResolver
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver
        }
    }
}