using System;
using System.IO;
using System.Collections.Generic;
using FahrzeugVerwaltung.Shared;
using FahrzeugVerwaltung.Service;

namespace FahrzeugVerwaltung
{
    public class Program
    {
        private Program(VehicleConsoleService service)
        {
            ColorConsole.EnableColor();
            Service = service;
            Console.WriteLine("Hallo und herzlich willkommen!");
            while (true)
            {
                try
                {
                    Input();
                }
                catch (Exception ex)
                {
                    // using ANSI Color Escape Codes for better readability
                    Console.Error.WriteLine("\u001b[31mEs ist ein Fehler bei der Eingabe aufgetreten:" + ex.Message);
                    Console.Error.WriteLine("Bitte erneut versuchen oder den Support kontaktieren\u001b[0m");
                    Console.ReadKey();
                }
                // Console.WriteLine("\u001b[2J");
            }
        }
        static void Main(string[] args)
        {
            string path = "C:/dev/vehicles.json";
            if (args.Length > 0)
            {
                path = args[0];
            }
            new Program(Load(path));
        }

        private static VehicleConsoleService Load(string path)
        {
            if (File.Exists(path))
            {
                return VehicleConsoleService.FromJSON(File.ReadAllText(path));
            }
            else
            {
                return new VehicleConsoleService();
            }
            
        }

        private void Input()
        {
            Show_Menu();
            var action = Console.ReadLine();
            switch (action)
            {
                // Create a new vehicle
                case "1":
                    Vehicle vehicle1 = Create_Vehicle(false);
                    bool added = Service.Save(vehicle1);
                    if (added)
                    {
                        if (vehicle1.VehicleType == VehicleType.PKW)
                        {
                            WaitLine("\u001b[32mPKW wurde erstellt\u001b[0m");
                        } else
                        {
                            WaitLine("\u001b[32mLKW wurde erstellt\u001b[0m");
                        }
                    } else
                    {
                        WaitLine("\u001b[31mFahrzeug existiert bereits!\u001b[0m");
                    }
                    break;
                // Remove a vehicle
                case "2":
                    Console.Write("Bitte geben Sie nun die Id ein\n\r>");
                    int id2 = Int32.Parse(Console.ReadLine());
                    Service.Delete(id2);
                    break;
                // List all vehicles
                case "3":
                    Service.GetAll();
                    Console.ReadKey();
                    break;
                // Edit a vehicle
                case "4":
                    Vehicle vehicle4 = Create_Vehicle(true);
                    if(Service.Update(vehicle4))
                    {
                        WaitLine($"\u001b[32mFahrzeug mit Ident: {vehicle4.Id} wurde bearbeitet!\u001b[0m");
                    } else
                    {
                        WaitLine($"\u001b[31mFahrzeug mit Ident: {vehicle4.Id} konnte nicht gefunden werden!\u001b[0m");
                    }
                    break;
                case "5":
                    Console.Write("Bitte geben Sie den Dateipfad ein\n\r>");
                    string path5 = Console.ReadLine();
                    File.WriteAllText(path5, Service.ToJson());
                    WaitLine("\u001b[32mDatei wurde gespeicheret!\u001b[0m");
                    break;
                case "6":
                    Console.Write("Bitte geben Sie den Dateipfad ein\n\r>");
                    string path6 = Console.ReadLine();
                    Service = VehicleConsoleService.FromJSON(File.ReadAllText(path6));
                    WaitLine("\u001b[32mDatei wurde geladen!\u001b[0m");
                    break;
                // Exit the Application
                case "10":
                    Environment.Exit(0);
                    break;
                // The input could not be recognized
                default:
                    WaitLine("\u001b[31mUnbekannte Eingabe!\u001b[0m");
                    break;
            }
        }

        private static void Show_Menu()
        {
            // \u001bC clears the terminal
            Console.WriteLine("\u001bc\u001b[37;1mBitte wählen Sie die Aktion aus\u001b[0m");
            Console.WriteLine("1) Fahrzeug anlegen");
            Console.WriteLine("2) Fahrzeug löschen");
            Console.WriteLine("3) Alle Fahrzeuge anzeigen");
            Console.WriteLine("4) Vehicle bearbeiten");
            Console.WriteLine("5) Daten speichern");
            Console.WriteLine("6) Daten laden");
            Console.WriteLine("10) Programm beenden");
            Console.Write(">");
        }

        private static void WaitLine(string text)
        {
            Console.WriteLine(text);
            Console.ReadKey();
        }

        private static Vehicle Create_Vehicle(bool needId)
        {
            Console.WriteLine("Welchen Typ wollen sie anlegen?");
            Console.WriteLine("1) PKW");
            Console.WriteLine("2) LKW");
            Console.Write(">");
            int type = Int32.Parse(Console.ReadLine());
            int id = 0;
            if (needId)
            {
                Console.Write("Bitte geben Sie nun die Id ein\n\r>");
                id = Int32.Parse(Console.ReadLine());
            }
            Console.Write("Bitte geben Sie nun die Marke ein\n\r>");
            string brand = Console.ReadLine();
            Console.Write("Bitte geben Sie nun das Modell ein\n\r>");
            string model = Console.ReadLine();
            if (type == 1)
            {
                return new PKW(id, brand, model);
            } else
            {
                Console.Write("Bitte geben Sie die Frachtkapazität in kg ein\n\r>");
                double capacity = Double.Parse(Console.ReadLine());
                return new LKW(id, brand, model, capacity);
            }
        }

        public VehicleConsoleService Service { get; set; }

    }
}
