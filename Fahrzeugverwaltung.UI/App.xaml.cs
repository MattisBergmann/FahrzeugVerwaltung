using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FahrzeugVerwaltung.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ShutdownMode = ShutdownMode.OnExplicitShutdown;
        }

        public new int Run()
        {
            string path = "C:/dev/user.json";
            User user;
            try
            {
                user = JsonSerializer.Deserialize<User>(File.ReadAllText(path));
            }
            catch
            {
                user = new User();
            }
            if (!user.Created)
            {
                MessageBox.Show("User not Created. Create a new one?");
            }
            bool? accepted;
            if (!user.Keep)
            {
                var login = new LoginWindow(user);
                accepted = login.ShowDialog();
            } else
            {
                accepted = true;
            }
            if (!user.Created)
            {
                MessageBox.Show("User was not created.");
                return -2;
            }
            if (!accepted ?? true)
            {
                MessageBox.Show("Aborted or Wrong Password");
                return -1;
            }
            File.WriteAllText(path, JsonSerializer.Serialize(user));
            var window = new MainWindow();
            window.ShowDialog();
            return 0;
        }
    }
}
