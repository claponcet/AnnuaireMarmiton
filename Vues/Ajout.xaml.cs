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
    /// Logique d'interaction pour Ajout.xaml
    /// </summary>
    public partial class Ajout : Window
    {
        public Manager manager => (App.Current as App).manager;
        Categorie categorie;
        Recette recette;

        public Ajout()
        {
            InitializeComponent();
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            MainWindow fenetre = new MainWindow();
            fenetre.Show();
            Close();
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

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            recette = new Recette(textBoxNom.Text, Int32.Parse(textBoxNumero.Text), categorie);
            List<Ingredient> ingredients = new List<Ingredient>();
            if (textBox1.Text != "") ingredients.Add(new Ingredient(textBox1.Text));
            if (textBox2.Text != "") ingredients.Add(new Ingredient(textBox2.Text));
            if (textBox3.Text != "") ingredients.Add(new Ingredient(textBox3.Text));
            if (textBox4.Text != "") ingredients.Add(new Ingredient(textBox4.Text));
            if (textBox5.Text != "") ingredients.Add(new Ingredient(textBox5.Text));
            foreach (Ingredient i in ingredients)
            {
                if (manager.Ingredients.Contains(i))
                {
                    int n=manager.Ingredients.IndexOf(i);
                    recette.LesIngredients.Add(manager.Ingredients[n]);
                }
                else
                {
                    manager.Ingredients.Add(i);
                    int n = manager.Ingredients.IndexOf(i);
                    recette.LesIngredients.Add(manager.Ingredients[n]);
                }
            }
            recette.Favoris = (bool)checkBox.IsChecked;
            manager.Recettes.Add(recette);
            manager.Recettes.Sort();
            manager.Ingredients.Sort();
            manager.SauvegardeDonnees(manager);
            MainWindow fenetre = new MainWindow();
            fenetre.Show();
            Close();
        }
    }
}
