﻿using System;
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

namespace Fahrzeugverwaltung.UI
{
    /// <summary>
    /// Interaction logic for VehicleManagerView.xaml
    /// </summary>
    public partial class NewVehicleView : Window
    {
        public NewVehicleView(object DataContext)
        {
            InitializeComponent();
            this.DataContext = DataContext;
        }
    }
}
