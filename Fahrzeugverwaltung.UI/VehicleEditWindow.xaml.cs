using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FahrzeugVerwaltung.UI
{
    /// <summary>
    /// Interaction logic for VehicleWindow.xaml
    /// </summary>
    public partial class VehicleEditWindow : Window, IClosable
    {
        public readonly VehicleEditViewModel viewModel;
        public VehicleEditWindow(Vehicle vehicle)
        {
            InitializeComponent();
            viewModel = new VehicleEditViewModel(vehicle, this);
            DataContext = viewModel;
        }
    }
}
