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

        /// <summary>
        /// Invoked when an item in the ListBox is double clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            viewModel.Edit(vehiclesListBox.SelectedIndex);
        }

        /// <summary>
        /// Invoked when the New item in the Context Menu is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemNew_Click(object sender, RoutedEventArgs e)
        {
            viewModel.New();
        }

        /// <summary>
        /// Invoked when the Edit item in the Context Menu is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemEdit_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Edit(vehiclesListBox.SelectedIndex);
        }

        /// <summary>
        /// Invoked when the Delete item in the Context Menu is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            var index = vehiclesListBox.SelectedIndex;
            viewModel.Delete(index);
            vehiclesListBox.SelectedIndex = index;
        }

        /// <summary>
        /// Invoked when the Information item in the Context Menu is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemInformation_Click(object sender, RoutedEventArgs e)
        {
            viewModel.EditInformation(vehiclesListBox.SelectedIndex);
        }
    }
}
