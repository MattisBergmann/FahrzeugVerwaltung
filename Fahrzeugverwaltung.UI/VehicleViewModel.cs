using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace FahrzeugVerwaltung.UI
{
    public class VehicleViewModel : ViewModelBase
    {
        private Vehicle vehicle;
        private bool check;

        public VehicleViewModel(Vehicle vehicle)
        {
            this.Vehicle = vehicle;
            Check = false;
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

        public bool Check
        {
            get
            {
                return check;
            }
            set
            {
                check = value;
                RaisePropertyChanged(nameof(Check));
            }
        }

        public string Type { get => Vehicle.Type; set => Vehicle.Type = value; }

        public string Brand { get => Vehicle.Brand; set => Vehicle.Brand = value; }

        public string Model { get => Vehicle.Model; set => Vehicle.Model = value; }
    }
}
