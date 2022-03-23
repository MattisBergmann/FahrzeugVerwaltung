using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace FahrzeugVerwaltung.UI
{
    public class MainViewModel : ViewModelBase
    {
        private Vehicle vehicle;

        /// <summary>
        /// Constructor
        /// </summary>
        public MainViewModel()
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
            //MessageBox.Show($"Es wurde folgendes Fahrzeug angelegt: Typ: {Type}, Marke: {Brand}, Modell: {Model}");
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
        /// Binding for Editing a Vehicle
        /// </summary>
        /// <param name="index"></param>
        internal void Edit(int index)
        {
            Vehicle = Vehicles[index];
            var editWindow = new VehicleWindow(Vehicle);
            editWindow.ShowDialog();
            Vehicles[index] = editWindow.viewModel.Vehicle;
        }

        /// <summary>
        /// Binding for Editing a Vehicle
        /// </summary>
        /// <param name="index"></param>
        internal void Delete(int index)
        {
            Vehicles.RemoveAt(index);
        }

        /// <summary>
        /// Gets or sets a <see cref="UI.Vehicle"/> and updates listeners.
        /// </summary>
        private Vehicle Vehicle { get; set; }

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