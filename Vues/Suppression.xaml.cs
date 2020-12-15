using Modele;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Vues
{
    /// <summary>
    /// Logique d'interaction pour Suppression.xaml
    /// </summary>
    public partial class Suppression : Window
    {
        public Manager manager => (App.Current as App).manager;

        public Suppression()
        {
            InitializeComponent();
            DataContext = manager.RecetteCourante;
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            manager.Recettes.Remove(manager.RecetteCourante);
            manager.SauvegardeDonnees(manager);
            Close();
        }
    }
}
