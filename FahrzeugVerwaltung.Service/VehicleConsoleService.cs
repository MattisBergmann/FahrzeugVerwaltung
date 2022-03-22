using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FahrzeugVerwaltung.Shared;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FahrzeugVerwaltung.Service
{
    public class VehicleConsoleService
    {
        private List<Vehicle> vehicleList;
        private int id;

        public VehicleConsoleService()
        {
            vehicleList = new List<Vehicle>();
        }

        private VehicleConsoleService(List<Vehicle> vehicles)
        {
            vehicleList = vehicles;
            if(!check())
            {
                throw new ArgumentException("List of vehicles contains duplicate ids");
            }
        }

        // checks for duplicated Ids and sets current id to max + 1
        private bool check() {
            var ids = new List<int>();
            foreach(Vehicle vehicle in vehicleList)
            {
                if(vehicle.Id >= id)
                {
                    id = vehicle.Id + 1;
                }
                if(ids.Contains(vehicle.Id))
                {
                    return false;
                }
                ids.Add(vehicle.Id);
            }
            return true;
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(vehicleList, new JsonSerializerOptions { WriteIndented = true });
        }

        public static VehicleConsoleService FromJSON(string json)
        {
            try
            {
                var vehicles = JsonSerializer.Deserialize<List<Vehicle>>(json, new JsonSerializerOptions { Converters = { new VehicleJsonConverter() } });
                var service = new VehicleConsoleService(vehicles);
                if (service.check())
                {
                    return service;
                }
                else
                {
                    return new VehicleConsoleService();
                }
            } catch (Exception ex)
            {
                Console.WriteLine("\u001b[31mFahrzeugliste konnte nicht geladen werden\u001b[0m" + ex);
                return new VehicleConsoleService();
            }
        }

        public override string ToString()
        {
            var text = "";
            foreach (Vehicle vehicle in vehicleList)
            {
                text += vehicle + "\n";
            }
            return text;
        }

        // returns true if the vehicle was added and false if the id was already taken
        public bool Save(Vehicle toAdd)
        {
            toAdd.Id = id;
            vehicleList.Add(toAdd);
            id++;
            return true;
        }

        // returns true if the vehicle was deleted, otherwise false is returned
        public bool Delete(int id)
        {
            foreach (Vehicle vehicle in vehicleList)
            {
                if (id == vehicle.Id)
                {
                    vehicleList.Remove(vehicle);
                    return true;
                }
            }
            return false;
        }

        // Updates a vehicle in the list
        public bool Update(Vehicle update)
        {
            foreach (Vehicle vehicle in vehicleList)
            {
                if (update.Id == vehicle.Id)
                {
                    int index = vehicleList.IndexOf(vehicle);
                    vehicleList[index] = update;
                    return true;
                }
            }
            return false;
        }

        // Gets the Vehicle with 
        public Vehicle GetVehicle(int id)
        {
            foreach (Vehicle vehicle in vehicleList)
            {
                if(id == vehicle.Id)
                {
                    return vehicle;
                }
            }
            return null;
        }

        // Checks if there is a vehicle with the specified Id
        public bool HasVehicle(int id)
        {
            foreach (Vehicle vehicle in vehicleList)
            {
                if (id == vehicle.Id)
                {
                    return true;
                }
            }
            return false;
        }

        // Prints out all vehicles
        public void GetAll()
        {
            foreach (Vehicle vehicle3 in vehicleList)
            {
                Console.WriteLine(vehicle3);
            }
        }
    }
}
