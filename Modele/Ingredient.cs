using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Modele
{
    [DataContract(IsReference = true)]
    public class Ingredient : IComparable, IEquatable<Ingredient>
    {
        [DataMember]
        public string Nom { get; set; }

        public Ingredient(string nom)
        {
            Nom = nom;
        }

        public int CompareTo(object obj)
        {
            return Nom.CompareTo(((Ingredient)obj).Nom);
        }

        public bool Equals(Ingredient other)
        {
            return Nom.Equals(other.Nom);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as Ingredient);
        }

        public override int GetHashCode()
        {
            return Nom.GetHashCode();
        }
    }

}
