using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FahrzeugVerwaltung.UI
{
    public class VehicleInformationViewModel : ViewModelBase
    {

        private bool saved;
        private readonly string oldText;
        private IClosable window;

        public VehicleInformationViewModel(string text, IClosable window)
        {
            if (text == null)
            {
                Text = "";
            }
            else
            {
                Text = text;
            }
            oldText = text;
            this.window = window;
            SaveCommand = new RelayCommand(Save);
        }

        /// <summary>
        /// Binding for the Save Button
        /// </summary>
        private void Save()
        {
            saved = true;
            window.Close();
        }

        public string Return { get => saved ? Text : oldText; }

        public string Text { get; set; }

        public ICommand SaveCommand { get; set; }
    }
}
