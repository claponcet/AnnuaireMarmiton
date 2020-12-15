using Data;
using Modele;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;

namespace Vues
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Manager manager = new Manager();

        public App()
        {
            InitializeComponent();
            manager = manager.ChargementDonnees();
        }
    }
}
