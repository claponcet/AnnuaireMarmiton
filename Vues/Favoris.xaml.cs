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
    /// Logique d'interaction pour Favoris.xaml
    /// </summary>
    public partial class Favoris : Window
    {
        public Manager manager => (App.Current as App).manager;

        public Favoris()
        {
            InitializeComponent();
            DataContext = manager;
        }

        private void Recherche_Click(object sender, RoutedEventArgs e)
        {
            manager.RecetteCourante = null;
            Recherche recherche = new Recherche();
            recherche.Show();
            Close();
        }

        private void Tout_Click(object sender, RoutedEventArgs e)
        {
            manager.RecetteCourante = null;
            MainWindow fenetre = new MainWindow();
            fenetre.Show();
            Close();
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            manager.RecetteCourante = null;
            Ajout fenetre = new Ajout();
            fenetre.Show();
            Close();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            manager.RecetteCourante = e.AddedItems[0] as Recette;
        }

        private void Suppression_Click(object sender, RoutedEventArgs e)
        {
            Suppression fenetre = new Suppression();
            fenetre.ShowDialog();
        }
    }
}
