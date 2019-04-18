using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Reservations.Repositories;
using Contracts.Interfaces;

namespace WEBAPI.IoC.Installer
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IFacilitiesRepository>().ImplementedBy<FacilitiesRepository>());
            container.Register(Component.For<IReservationsRepository>().ImplementedBy<ReservationsRepository>());
        }
    }
}