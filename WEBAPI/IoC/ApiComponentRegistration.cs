using System;
using System.Configuration;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using WEBAPI.IoC.Installer;
using Castle.Windsor;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace WEBAPI.IoC
{
    public class ApiComponentRegistration
    {
        private static IWindsorContainer _container;

        public static IWindsorContainer Register(HttpConfiguration configuration)
        {
            _container = new WindsorContainer();
            _container.Install(new DrapperInstaller());
            return DoRegistration(configuration);
        }

        private static IWindsorContainer DoRegistration(HttpConfiguration configuration)
        {
            configuration.SuppressDefaultHostAuthentication();
            configuration.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            _container.Install(new RepositoriesInstaller());
            _container.Install(new ServicesInstaller());
            _container.Install(new ApiControllerInstaller());

            configuration.Services.Replace(typeof(IHttpControllerActivator), new WindsorCompositionRoot(_container));
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(_container));

            //configuration.Filter.Add(new LogActionFilter());
            //configuration.Filter.Add(new ApiAuthorizeAttribute());
            //configuration.Filter.Add(new WebApiOutputCacheAttribute());

            configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
            configuration.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/octet-stream"));
            configuration.EnableCors();
            return _container;

        }

        public static void Release()
        {
            if (_container != null)
                _container.Dispose();
        }
    }
}