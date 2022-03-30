using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;

namespace FahrzeugVerwaltung.UI
{
    public class VehicleEditViewModel : ViewModelBase
    {
        private bool saved = false;
        private readonly Vehicle oldVehicle;
        private Vehicle vehicle;
        private IClosable window;

        public VehicleEditViewModel(Vehicle vehicle, IClosable window)
        {
            Vehicle = (Vehicle)vehicle.Clone();
            oldVehicle = vehicle;
            this.window = window;
            RandomCommand = new RelayCommand(Random);
            SaveCommand = new RelayCommand(Save);
        }

        /// <summary>
        /// Binding for the Random Button
        /// </summary>
        private void Save()
        {
            saved = true;
            window.Close();
        }

        /// <summary>
        /// Binding for the Random Button
        /// </summary> 
        private void Random()
        {
            Vehicle = VehicleList.RandomVehicle();
        }

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

        public Vehicle Return { get => saved ? Vehicle : oldVehicle; }

        /// <summary>
        /// Gets or sets the type of a <see cref="UI.Vehicle"/>.
        /// </summary>
        public string Type { get => Vehicle.Type; set => Vehicle.Type = value; }

        /// <summary>
        /// Gets or sets the brand of a <see cref="UI.vehicle"/>.
        /// </summary>
        public string Brand { get => Vehicle.Brand; set => Vehicle.Brand = value; }

        /// <summary>
        /// Gets or sets the model of a <see cref="UI.Vehicle"/>.
        /// </summary>
        public string Model { get => Vehicle.Model; set => Vehicle.Model = value; }

        /// <summary>
        /// Gets or sets the repair state of a <see cref="UI.Vehicle"/>
        /// </summary>
        public bool InRepair { get => Vehicle.InRepair; set => Vehicle.InRepair = value; }

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
