using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using GalaSoft.MvvmLight.Command;

namespace FahrzeugVerwaltung.UI
{
    public class Vehicle : ICloneable
    {
        public Vehicle()
        {

        }
        public Vehicle(string type, string brand, string model)
        {
            Type = type;
            Brand = brand;
            Model = model;
        }

        public override string ToString()
        {
            return $"Type: {Type}, Brand: {Brand}, Model: {Model}";
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Information { get; set; }
    }
}