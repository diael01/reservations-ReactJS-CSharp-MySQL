using System;
using System.Configuration;
using System.IO;
using System.Web.Hosting;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Drapper;
using Drapper.Configuration;
using Drapper.Configuration.Json;
using Newtonsoft.Json;

namespace WEBAPI.IoC.Installer
{
    public class DrapperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var fileName = ConfigurationManager.AppSettings["drapperFileName"];
            string path = null;
            if(HostingEnvironment.IsHosted)
            {
                path = HostingEnvironment.MapPath("~/" + fileName);
            }

            var fileContent = File.ReadAllText(path ?? fileName);
            var settings = JsonConvert.DeserializeObject<Settings>(fileContent);

            container.Register(Component.For<ISettings>().Instance(settings))
                .Register(Component.For<IDbConnector>().ImplementedBy<DbConnector>())
                .Register(Component.For<ICommandReader>().ImplementedBy<JsonFileCommandReader>())
                .Register(Component.For<IDbCommander>().ImplementedBy<DbCommander>());
        }
    }
}