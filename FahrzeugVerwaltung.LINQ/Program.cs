using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Common;

namespace FahrzeugVerwaltung.LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vehicles = VehicleList.models.Where(vehicle => vehicle.Brand != "Audi");
            var query = vehicles.Where(vehicle => vehicle.Brand == "Audi").First();
            Console.WriteLine(query);
        }
        static IEnumerable<string> Suits()
        {
            yield return "clubs";
            yield return "diamonds";
            yield return "hearts";
            yield return "spades";
        }
        static IEnumerable<string> Ranks()
        {
            yield return "two";
            yield return "three";
            yield return "four";
            yield return "five";
            yield return "six";
            yield return "seven";
            yield return "eight";
            yield return "nine";
            yield return "ten";
            yield return "jack";
            yield return "queen";
            yield return "king";
            yield return "ace";
        }
    }
}
