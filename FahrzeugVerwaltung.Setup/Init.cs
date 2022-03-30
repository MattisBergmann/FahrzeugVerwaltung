using FahrzeugVerwaltung.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace FahrzeugVerwaltung.Setup
{
    public class Init
    {
        private readonly UnityContainer container = new UnityContainer();
        public void Initialize()
        {
            container.RegisterType<IVehicleRepository, VehicleRepository>(new ContainerControlledLifetimeManager());
        }
    }
}
