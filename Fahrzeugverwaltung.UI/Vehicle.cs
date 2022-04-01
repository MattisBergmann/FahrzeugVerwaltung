using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace FahrzeugVerwaltung.UI
{
    /// <summary>
    /// <see cref="Vehicle"/> class used in UI Excerises
    /// </summary>
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

        public Vehicle(string type, string brand, string model, bool inRepair)
        {
            Type = type;
            Brand = brand;
            Model = model;
            InRepair = inRepair;
        }

        public override string ToString()
        {
            return $"Type: {Type}, Brand: {Brand}, Model: {Model}, InRepair: {InRepair}";
        }

        /// <summary>
        /// Returns a clone of this <see cref="Vehicle"/>
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// Gets or sets the type of the <see cref="Vehicle"/>
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the brand of the <see cref="Vehicle"/>
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the model of the <see cref="Vehicle"/>
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the repair state of the <see cref="Vehicle"/>
        /// </summary>
        public bool InRepair { get; set; }

        /// <summary>
        /// Gets or sets the information of the <see cref="Vehicle"/>
        /// </summary>
        public string Information { get; set; }
    }
}