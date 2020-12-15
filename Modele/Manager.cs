using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace Modele
{
    [DataContract]
    public class Manager : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        [DataMember]
        public List<Recette> Recettes { get; set; } = new List<Recette>();

        public List<Recette> Favoris
        {
            get
            {
                return Recettes.Where(n => n.Favoris).OrderBy(n => n.Nom).ToList();
            }
        }

        [DataMember]
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public List<Recette> Recherche { get; set; }

        public Recette RecetteCourante 
        { 
            get
            {
                return recette;
            }  
            set
            {
                recette = value;
                OnPropertyChanged("RecetteCourante");
            }
        }

        private Recette recette;

        public string CheminFichier 
        { 
            get
            {
                return Path.Combine(Directory.GetCurrentDirectory(), "..//XML");
            } 
        } 

        [DataMember]
        public string NomFichier { get; set; } = "annuairemarmiton.xml";

        public Manager ChargementDonnees()
        {
            Manager manager;
            if (!File.Exists(Path.Combine(CheminFichier, NomFichier)))
            {
                throw new FileNotFoundException("Le fichier n'existe pas.");
            }
            else
            {
                var serializer = new DataContractSerializer(typeof(Manager));
                using (Stream s = File.OpenRead(Path.Combine(CheminFichier, NomFichier)))
                {
                    manager = serializer.ReadObject(s) as Manager;
                }
                return manager;
            }
        }

        public void SauvegardeDonnees(Manager manager)
        {
            var serializer = new DataContractSerializer(typeof(Manager));
            if (!Directory.Exists(CheminFichier))
            {
                Directory.CreateDirectory(CheminFichier);
            }
            var settings = new XmlWriterSettings() { Indent = true };
            using (TextWriter tw = File.CreateText(Path.Combine(CheminFichier, NomFichier)))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, settings))
                {
                    serializer.WriteObject(writer, manager);
                }
            }
        }
    }
}
