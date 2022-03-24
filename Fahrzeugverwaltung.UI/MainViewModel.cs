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
        private int selectedIndex = -1;
        /// <summary>
        /// Constructor
        /// </summary>
        public MainViewModel()
        {
            EditAllCommand = new RelayCommand(EditAll);
            RandomCommand = new RelayCommand(Random);
            Vehicle[] vehicles = VehicleList.RandomVehicles(30, 50);
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
            for(int i = 0; i < Vehicles.Count; i++)
            {
                Edit(i);
            }
        }

        /// <summary>
        /// Binding for the Random Button
        /// </summary>
        private void Random()
        {
            Vehicles.Add(new VehicleViewModel(VehicleList.RandomVehicle()));
        }

        internal void EditInformation(int index)
        {
            var editWindow = new VehicleInformationWindow(Vehicles[index].Vehicle.Information);
            editWindow.ShowDialog();
            Vehicles[index].Vehicle.Information = editWindow.viewModel.Return;
        }

        internal void New()
        {
            var editWindow = new VehicleEditWindow(new Vehicle());
            editWindow.ShowDialog();
            Vehicles.Add(new VehicleViewModel(editWindow.viewModel.Return));
        }

        /// <summary>
        /// Edit a Vehicle
        /// </summary>
        /// <param name="index"></param>
        internal void Edit(int index)
        {
            if (index < 0) { return; }
            var editWindow = new VehicleEditWindow(Vehicles[index].Vehicle);
            editWindow.ShowDialog();
            Vehicles[index].Vehicle = editWindow.viewModel.Return;
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
                RaisePropertyChanged(nameof(Selected));
            }

            get
            {
                return selectedIndex;
            }
        }

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