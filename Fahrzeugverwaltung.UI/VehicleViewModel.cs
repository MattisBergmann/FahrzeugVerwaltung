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
    public class VehicleViewModel : ViewModelBase
    {
        private Vehicle vehicle;

        public VehicleViewModel(Vehicle vehicle)
        {
            RandomCommand = new RelayCommand(Random);
            this.vehicle = (Vehicle)vehicle.Clone();
        }

        /// <summary>
        /// Binding for the Random Button
        /// </summary> 
        private void Random()
        {
            Vehicle = VehicleList.RandomVehicle();
        }

        public Vehicle Vehicle
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
        /// Gets or sets a model of a <see cref="UI.vehicle"/>.
        /// </summary>
        public string Brand { get => Vehicle.Brand; set => Vehicle.Brand = value; }

        /// <summary>
        /// Gets or sets a model of a <see cref="UI.Vehicle"/>.
        /// </summary>
        public string Model { get => Vehicle.Model; set => Vehicle.Model = value; }

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
