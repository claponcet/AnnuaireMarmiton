using Modele;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Logique d'interaction pour Recherche.xaml
    /// </summary>
    public partial class Recherche : Window
    {
        public Manager manager => (App.Current as App).manager;
        Ingredient ingredient1 = null;
        Ingredient ingredient2 = null;
        Categorie? categorie = null;

        public Recherche()
        {
            InitializeComponent();
            DataContext = manager;
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            manager.RecetteCourante = null;
            manager.SauvegardeDonnees(manager);
            MainWindow fenetre = new MainWindow();
            fenetre.Show();
            Close();
        }

        private void Lancer_Click(object sender, RoutedEventArgs e)
        {
            manager.RecetteCourante = null;
            string texte = textBox.Text;
            if (ingredient1 == null && categorie == null && texte == "")
            {
                MessageBox.Show("Veuillez saisir des critères de recherche et réessayer.",
                    "Recherche impossible", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (ingredient1 != null)
                {
                    manager.Recherche = manager.Recettes.Where
                        (n => n.LesIngredients.Contains(ingredient1)).ToList();
                    if (ingredient2 != null)
                    {
                        manager.Recherche = manager.Recherche.Where
                            (n => n.LesIngredients.Contains(ingredient2)).ToList();
                    }
                    if (categorie != null)
                    {
                        manager.Recherche = manager.Recherche.Where
                            (n => n.Categorie == this.categorie).ToList();
                    }
                    if (texte != "")
                    {
                        manager.Recherche = manager.Recherche.Where
                            (n => n.Nom.Contains(texte)).ToList();
                    }
                }
                else
                {
                    if (categorie != null)
                    {
                        manager.Recherche = manager.Recettes.Where
                            (n => n.Categorie == this.categorie).ToList();
                        if (texte != "")
                        {
                            manager.Recherche = manager.Recherche.Where
                                (n => n.Nom.Contains(texte)).ToList();
                        }
                    }
                    else
                    {
                        manager.Recherche = manager.Recettes.Where
                                (n => n.Nom.Contains(texte)).ToList();
                    }
                }
                listBox.DataContext = null;
                listBox.DataContext = manager;
            }
        }

        private void ingre1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ingre1.SelectedItem != null)
            {
                ingredient1 = e.AddedItems[0] as Ingredient;
            }
            else
            {
                ingredient1 = e.AddedItems as Ingredient;
            }
        }

        private void ingre2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ingre2.SelectedItem != null)
            {
                ingredient2 = e.AddedItems[0] as Ingredient;
            }
            else
            {
                ingredient2 = e.AddedItems as Ingredient;
            }
        }

        private void categorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (categorieComboBox.SelectedIndex)
            {
                case 0:
                    categorie = Categorie.Apéritif;
                    break;
                case 1:
                    categorie = Categorie.Entrée;
                    break;
                case 2:
                    categorie = Categorie.PlatViande;
                    break;
                case 3:
                    categorie = Categorie.PlatVégé;
                    break;
                case 4:
                    categorie = Categorie.Soupe;
                    break;
                case 5:
                    categorie = Categorie.Dessert;
                    break;
                case 6:
                    categorie = Categorie.DessertFruit;
                    break;
                case 7:
                    categorie = Categorie.Glace;
                    break;
                case 8:
                    categorie = Categorie.Boisson;
                    break;
                case 9:
                    categorie = Categorie.Autre;
                    break;
                default: 
                    categorie = Categorie.Autre;
                    break;
            }
        }

        private void Reinit_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = "";
            ingre1.SelectedItem = null;
            ingre2.SelectedItem = null;
            categorieComboBox.SelectedItem = null;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                manager.RecetteCourante = e.AddedItems[0] as Recette;
            }
        }

        private void Suppression_Click(object sender, RoutedEventArgs e)
        {
            Suppression fenetre = new Suppression();
            fenetre.ShowDialog();
        }
    }
}
