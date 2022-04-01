using System;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using System.Collections.ObjectModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace FahrzeugVerwaltung.UI
{
    public class MainViewModel : ObservableRecipient
    {
        private int selectedIndex = -1;
        /// <summary>
        /// Constructor
        /// </summary>
        public MainViewModel()
        {
            EditAllCommand = new RelayCommand(EditAll);
            RandomCommand = new RelayCommand(Random);
            Vehicle[] vehicles = VehicleList.RandomVehicles(3, 5);
            VehicleViewModel[] vehicleViewModels = new VehicleViewModel[vehicles.Length];
            for (int i = 0; i < vehicles.Length; i++)
            {
                vehicleViewModels[i] = new VehicleViewModel(vehicles[i]);
            }
            Vehicles = new ObservableCollection<VehicleViewModel>(vehicleViewModels);
        }

        /// <summary>
        /// Binding for the Edit All Button
        /// </summary>
        private void EditAll()
        {
            var editWindow = new VehicleEditWindow(Vehicles.Select(viewModel => viewModel.Vehicle.Clone() as Vehicle).ToArray());
            editWindow.ShowDialog();
            var vehicles = editWindow.viewModel.ReturnVehicles;
            if(vehicles != null)
            {
                Vehicles = new ObservableCollection<VehicleViewModel>(vehicles.Select(vehicle => new VehicleViewModel(vehicle)));
                OnPropertyChanged(nameof(Vehicles));
            }
        }

        /// <summary>
        /// Binding for the Random Button
        /// </summary>
        private void Random()
        {
            Vehicles.Add(new VehicleViewModel(VehicleList.RandomVehicle()));
        }

        /// <summary>
        /// Opens a <see cref="VehicleInformationWindow"/>
        /// </summary>
        /// <param name="index"></param>
        internal void EditInformation(int index)
        {
            var editWindow = new VehicleInformationWindow(Vehicles[index].Vehicle.Information);
            editWindow.ShowDialog();
            Vehicles[index].Vehicle.Information = editWindow.viewModel.Return;
        }

        /// <summary>
        /// Opens a <see cref="VehicleEditWindow"/> and adds as new Vehicle
        /// </summary>
        internal void New()
        {
            var editWindow = new VehicleEditWindow(new Vehicle());
            editWindow.ShowDialog();
            var vehicle = editWindow.viewModel.ReturnVehicle;
            if(vehicle != null)
            {
                Vehicles.Add(new VehicleViewModel(vehicle));
            }
        }

        /// <summary>
        /// Opens a <see cref="VehicleEditWindow"/> to edit a Vehicle
        /// </summary>
        /// <param name="index"></param>
        internal void Edit(int index)
        {
            if (!Selected) { return; }
            var editWindow = new VehicleEditWindow(Vehicles[index].Vehicle.Clone() as Vehicle);
            editWindow.ShowDialog();
            var vehicle = editWindow.viewModel.ReturnVehicle;
            if (vehicle != null)
            {
                Vehicles[index].Vehicle = vehicle;
            }
        }

        /// <summary>
        /// Delete a Vehicle
        /// </summary>
        /// <param name="index"></param>
        internal void Delete(int index)
        {
            if (index < 0) { return; }
            Vehicles.RemoveAt(index);
        }

        /// <summary>
        /// Gets or sets the selected Index of the ListBox
        /// <br>triggers event PropertyChanged when modified</br>
        /// </summary>
        public int SelectedIndex
        {
            set
            {
                if (selectedIndex >= 0 && selectedIndex < Vehicles.Count)
                {
                    Vehicles[selectedIndex].Check = false;
                }
                if (value >= 0 && value < Vehicles.Count)
                {
                    Vehicles[value].Check = true;
                }
                selectedIndex = value;
                OnPropertyChanged(nameof(Selected));
            }

            get
            {
                return selectedIndex;
            }
        }

        /// <summary>
        /// true if an item in the ListBox is selected
        /// </summary>
        public bool Selected { get => SelectedIndex >= 0 && SelectedIndex < Vehicles.Count; }

        /// <summary>
        /// The list of vehicles
        /// </summary>
        public ObservableCollection<VehicleViewModel> Vehicles { get; set; }

        /// <summary>
        /// Gets or sets a edit all command
        /// </summary>
        public ICommand EditAllCommand { get; set; }

        /// <summary>
        /// Gets or sets a random command
        /// </summary>
        public ICommand RandomCommand { get; set; }
    }
}