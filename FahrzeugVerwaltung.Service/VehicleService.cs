using FahrzeugVerwaltung.Shared;
using System.Collections.Generic;

namespace FahrzeugVerwaltung.Service
{
    public class VehicleService : IVehicleService
    {
        private IVehicleRepository vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        public void Delete(Vehicle entity)
        {
            vehicleRepository.Delete(entity);
        }

        public Vehicle Get(int ident)
        {
            return vehicleRepository.Get(ident);
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return vehicleRepository.GetAll();
        }

        public void Save(Vehicle entity)
        {
            vehicleRepository.Update(entity);
        }

        public void Update(Vehicle entity)
        {
            vehicleRepository.Update(entity);
        }
    }
}
