using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace FahrzeugVerwaltung.UI
{
    /// <summary>
    /// ViewModel for a <see cref="UI.Vehicle"/>
    /// </summary>
    public class VehicleViewModel : ObservableRecipient
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
                OnPropertyChanged(nameof(Type));
                OnPropertyChanged(nameof(Brand));
                OnPropertyChanged(nameof(Model));
                OnPropertyChanged(nameof(InRepair));
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
                OnPropertyChanged(nameof(Check));
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
