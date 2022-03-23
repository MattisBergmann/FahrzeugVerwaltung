using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace FahrzeugVerwaltung.UI
{
    public class VehicleViewModel : ViewModelBase
    {
        private Vehicle vehicle;

        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleViewModel()
        {
            SaveCommand = new RelayCommand(Save);
            RandomCommand = new RelayCommand(Random);
            Vehicle = new Vehicle();
            Vehicles = new ObservableCollection<Vehicle>(VehicleList.RandomVehicles(5, 10));
        }

        /// <summary>
        /// Binding for the Save Button
        /// </summary>
        private void Save()
        {
            MessageBox.Show($"Es wurde folgendes Fahrzeug angelegt: Typ: {Type}, Marke: {Brand}, Modell: {Model}");
            Vehicles.Add(Vehicle);
            Vehicle = new Vehicle();
        }

        /// <summary>
        /// Binding for the Random Button
        /// </summary>
        private void Random()
        {
            Vehicle = VehicleList.RandomVehicle();
        }

        /// <summary>
        /// Gets or sets a <see cref="UI.Vehicle"/> and updates listeners.
        /// </summary>
        private Vehicle Vehicle
        {
            get
            {
                return vehicle;
            }
            set
            {
                vehicle = value;
                RaisePropertyChanged(nameof(Type));
                RaisePropertyChanged(nameof(Brand));
                RaisePropertyChanged(nameof(Model));
            }
        }

        /// <summary>
        /// Gets or sets a type of a <see cref="UI.Vehicle"/>.
        /// </summary>
        public string Type { get => Vehicle.Type; set => Vehicle.Type = value; }

        /// <summary>
        /// Gets or sets a model of a <see cref="UI.Vehicle"/>.
        /// </summary>
        public string Brand { get => Vehicle.Brand; set => Vehicle.Brand = value; }

        /// <summary>
        /// Gets or sets a model of a <see cref="UI.Vehicle"/>.
        /// </summary>
        public string Model { get => Vehicle.Model; set => Vehicle.Model = value; }

        /// <summary>
        /// The list of vehicles
        /// </summary>
        public ObservableCollection<Vehicle> Vehicles { get; set; }

        /// <summary>
        /// Gets or sets a save command
        /// </summary>
        public ICommand SaveCommand { get; set; }

        /// <summary>
        /// Gets or sets a random command
        /// </summary>
        public ICommand RandomCommand { get; set; }

    }
}