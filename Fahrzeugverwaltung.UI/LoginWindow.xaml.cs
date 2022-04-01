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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window, IDialogResultable
    {
        private LoginViewModel viewModel;

        public LoginWindow(User user)
        {
            InitializeComponent();
            viewModel = new LoginViewModel(user, this);
            DataContext = viewModel;
        }

        /// <summary>
        /// Invoked when the password was changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            viewModel.Password = ((PasswordBox)sender).Password;
        }
    }
}
