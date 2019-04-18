using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Contracts.Interfaces;
using Services;

namespace WEBAPI.IoC.Installer
{
    public class ServicesInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IFacilitiesService>().ImplementedBy<FacilitiesService>());
            container.Register(Component.For<IReservationsService>().ImplementedBy<ReservationsService>());
        }
    }
}