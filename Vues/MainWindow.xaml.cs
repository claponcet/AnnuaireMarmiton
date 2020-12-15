using Modele;
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

namespace Vues
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Manager manager => (App.Current as App).manager;

        public MainWindow()
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

        private void Favoris_Click(object sender, RoutedEventArgs e)
        {
            manager.RecetteCourante = null;
            Favoris fenetre = new Favoris();
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

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
