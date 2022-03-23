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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FahrzeugVerwaltung.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            viewModel.Edit(vehiclesListBox.SelectedIndex);
        }

        private void MenuItemNew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemEdit_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Edit(vehiclesListBox.SelectedIndex);
        }

        private void MenuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            int index = vehiclesListBox.SelectedIndex;
            viewModel.Delete(index);
            vehiclesListBox.SelectedIndex = index;
        }
    }
}
