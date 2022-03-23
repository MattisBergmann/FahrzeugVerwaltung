using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrzeugVerwaltung.UI
{
    public class VehicleList
    {
        public static readonly Vehicle[] models = LoadVehicles("vehicles.cars");

        public static Vehicle[] LoadVehicles(string path)
        {
            string[] lines;
            try
            {
                lines = File.ReadAllLines(path);
            } catch {
                return new Vehicle[]
                {
                    new Vehicle("None", "None", "None")
                };
            }
            var count = lines.Length;
            Vehicle[] vehicles = new Vehicle[count];
            for (var i = 0; i < lines.Length; i++)
            {
                string[] data = lines[i].Split('/', 3);
                if (data.Length < 3)
                {
                    vehicles[i] = new Vehicle("None", "None", "None");
                }
                else
                {
                    vehicles[i] = new Vehicle(data[0], data[1], data[2]);
                }

            }
            return vehicles;
        }

        public static Vehicle[] RandomVehicles(int min, int max)
        {
            var num = random.Next(min, max);
            Vehicle[] vehicles = new Vehicle[num];
            for (var i = 0; i < num; i++)
            {
                vehicles[i] = RandomVehicle();
            }
            return vehicles;
        }

        public static Vehicle RandomVehicle()
        {
            return (Vehicle)models[random.Next(0, models.Length - 1)].Clone();
        }

        private static readonly Random random = new Random();
    }
}
