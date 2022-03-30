using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace FahrzeugVerwaltung.UI
{
    /// <summary>
    /// ViewModel for a <see cref="UI.Vehicle"/>
    /// </summary>
    public class VehicleViewModel : ViewModelBase
    {
        private Vehicle vehicle;
        private bool check;

        /// <summary>
        /// Constructor of the <see cref="VehicleViewModel"/>
        /// </summary>
        /// <param name="vehicle"></param>
        public VehicleViewModel(Vehicle vehicle)
        {
            Vehicle = vehicle;
            Check = false;
        }

        /// <summary>
        /// Gets or sets a <see cref="UI.Vehicle"/>
        /// <br>triggers event PropertyChanged when modified</br>
        /// </summary>
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
                RaisePropertyChanged(nameof(InRepair));
            }
        }

        /// <summary>
        /// Represents if this item was selected
        /// <br>triggers event PropertyChanged when modified</br>
        /// </summary>
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

        /// <summary>
        /// Gets or sets the type of a <see cref="UI.Vehicle"/>.
        /// </summary>
        public string Type { get => Vehicle.Type; set => Vehicle.Type = value; }

        /// <summary>
        /// Gets or sets the brand of a <see cref="UI.Vehicle"/>.
        /// </summary>
        public string Brand { get => Vehicle.Brand; set => Vehicle.Brand = value; }

        /// <summary>
        /// Gets or sets the model of a <see cref="UI.Vehicle"/>.
        /// </summary>
        public string Model { get => Vehicle.Model; set => Vehicle.Model = value; }

        /// <summary>
        /// Gets or sets the repair state of a <see cref="UI.Vehicle"/>.
        /// </summary>
        public bool InRepair { get => Vehicle.InRepair; set => Vehicle.InRepair = value; }
    }
}
