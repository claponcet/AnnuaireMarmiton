using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Modele
{
    [DataContract (IsReference = true)]
    public class Recette : IComparable
    {
        [DataMember]
        public string Nom { get; set; }

        [DataMember]
        public bool Favoris { get; set; } = false;

        [DataMember]
        public List<Ingredient> LesIngredients { get; private set; } = new List<Ingredient>();

        public String IngredientsToString
        {
            get
            {
                var message="";
                foreach (Ingredient i in LesIngredients)
                {
                    if (message != "")
                    {
                        message += "\n";
                    }
                    message = message + i.Nom;
                }
                return message;
            }
        }

        [DataMember]
        public int NumeroMagazine { get; set; }

        [DataMember]
        public Categorie Categorie { get; set; }

        public Recette(string nom, int numero, Categorie categorie)
        {
            this.Nom = nom;
            NumeroMagazine = numero;
            this.Categorie = categorie;
        }

        public int CompareTo(object obj)
        {
            return Nom.CompareTo(((Recette)obj).Nom);
        }
    }
}
