using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Modele
{
    [DataContract]
    public enum Categorie
    {
        [EnumMember(Value = "Apéritif")]
        Apéritif,
        [EnumMember(Value = "Entrée")]
        Entrée,
        [EnumMember(Value = "PlatViande")]
        PlatViande,
        [EnumMember(Value = "PlatVégé")]
        PlatVégé,
        [EnumMember(Value = "Soupe")]
        Soupe,
        [EnumMember(Value = "Dessert")]
        Dessert,
        [EnumMember(Value = "DessertFruit")]
        DessertFruit,
        [EnumMember(Value = "Glace")]
        Glace,
        [EnumMember(Value = "Boisson")]
        Boisson,
        [EnumMember(Value = "Autre")]
        Autre
    }
}
