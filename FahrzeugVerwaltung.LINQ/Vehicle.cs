using System;

namespace FahrzeugVerwaltung.LINQ
{
    public class Vehicle : ICloneable
    {
        public Vehicle(int id, string type, string brand, string model)
        {
            Id = id;
            Type = type;
            Brand = brand;
            Model = model;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Type: {Type}, Brand: {Brand}, Model: {Model}";
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Information { get; set; }
    }
}