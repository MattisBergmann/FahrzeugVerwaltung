using FahrzeugVerwaltung.Shared;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace FahrzeugVerwaltung.Service
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly List<Vehicle> vehicles;

        public VehicleRepository(string path)
        {
            Path = path;
            var json = File.ReadAllText(path);
            vehicles = JsonSerializer.Deserialize<List<Vehicle>>(json, new JsonSerializerOptions { Converters = { new VehicleJsonConverter() } });
        }

        ~VehicleRepository()
        {
            SaveToFile();
        }

        public void SaveToFile(string path)
        {
            File.WriteAllText(path, JsonSerializer.Serialize(vehicles));
        }

        public void SaveToFile()
        {
            SaveToFile(Path);
        }

        public void Delete(Vehicle entity)
        {
            vehicles.Remove(entity);
        }

        public Vehicle Get(int ident)
        {
            return vehicles[ident];
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return vehicles;
        }

        public void Save(Vehicle entity)
        {
            vehicles.Add(entity);
        }

        public void Update(Vehicle entity)
        {
            int index = vehicles.IndexOf(entity);
            vehicles[index] = entity;
        }

        public string Path { get; set; }
    }
}
