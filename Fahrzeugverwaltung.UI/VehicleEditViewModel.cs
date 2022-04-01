using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FahrzeugVerwaltung.UI
{
    public class VehicleEditViewModel : ObservableRecipient
    {
        private bool saved = false;
        private readonly Vehicle[] vehicles;
        private int index = 0;
        private Vehicle vehicle;
        private IClosable window;

        private VehicleEditViewModel(IClosable window)
        {
            this.window = window;
            RandomCommand = new RelayCommand(Random);
            SaveCommand = new RelayCommand(Save);
            PreviousCommand = new RelayCommand(Previous);
            NextCommand = new RelayCommand(Next);
        }

        /// <summary>
        /// Constructor that takes an array of <see cref="UI.Vehicle"/>
        /// </summary>
        /// <param name="vehicles"></param>
        /// <param name="window"></param>
        public VehicleEditViewModel(Vehicle[] vehicles, IClosable window) : this(window)
        {
            this.vehicles = vehicles;
            vehicle = vehicles[0];
        }

        /// <summary>
        /// Constructor that takes only one <see cref="UI.Vehicle"/>
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="window"></param>
        public VehicleEditViewModel(Vehicle vehicle, IClosable window) : this(window)
        {
            Vehicle = vehicle;
        }

        /// <summary>
        /// Binding for the Left Arrow
        /// </summary>
        private void Previous()
        {
            if (HasPrevious)
            {
                Index--;
                Vehicle = vehicles[Index];
            }
        }

        /// <summary>
        /// Binding for the Right Arrow
        /// </summary>
        private void Next()
        {
            if (HasNext)
            {
                Index++;
                Vehicle = vehicles[Index];
            }
        }

        /// <summary>
        /// Binding for the Save Button
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
            vehicles[Index] = Vehicle;
        }

        /// <summary>
        /// Gets or sets a <see cref="UI.Vehicle"/>
        /// <br>triggers event PropertyChanged when modified</br>
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
                OnPropertyChanged(nameof(Type));
                OnPropertyChanged(nameof(Brand));
                OnPropertyChanged(nameof(Model));
                OnPropertyChanged(nameof(InRepair));
            }
        }


        /// <summary>
        /// Zero based index of current selected Dataset
        /// </summary>
        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                if(value >= 0 && value < Count)
                {
                    index = value;
                    OnPropertyChanged(nameof(DatasetNumber));
                    OnPropertyChanged(nameof(HasPrevious));
                    OnPropertyChanged(nameof(HasNext));
                }
            }
        }

        /// <summary>
        /// One based index of current selected Dataset (for Binding)
        /// </summary>
        public int DatasetNumber
        {
            get
            {
                return Index + 1;
            }
        }

        /// <summary>
        /// Number of items in <see cref="vehicles"/>
        /// </summary>
        public int Count { get { return vehicles?.Length ?? 1; } }

        /// <summary>
        /// Returns the edited <see cref="UI.Vehicle"/> if it was saved
        /// </summary>
        public Vehicle ReturnVehicle { get => saved ? vehicle : null; }

        /// <summary>
        /// Returns the edited list of <see cref="UI.Vehicle"/> if it was saved
        /// </summary>
        public Vehicle[] ReturnVehicles { get => saved ? vehicles : null; }

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

        /// <summary>
        /// Gets or sets a previous command
        /// </summary>
        public ICommand PreviousCommand { get; set; }

        /// <summary>
        /// Gets or sets a next command
        /// </summary>
        public ICommand NextCommand { get; set; }

        /// <summary>
        /// Indicates wether there are items in the list behind the selected
        /// </summary>
        public bool HasNext { get => vehicles?.Length - 1 > Index; }

        /// <summary>
        /// Indicates wether there are items in the list before the selected
        /// </summary>
        public bool HasPrevious { get => Index > 0; }

    }
}
