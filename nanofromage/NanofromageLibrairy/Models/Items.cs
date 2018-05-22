using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanofromageLibrairy.Models
{
    public class Items : ModelBase
    {
        /// <summary>
        /// Inventaires de tous les objets existants
        /// </summary>
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private String name;
        private double price;
        private String description;
        private List<Equipment> myListEquipments;
        private List<Usable> myListUsables;
        private String categorieName;
        ////// <summary>
        /// Les listes d'equipements sont faites pour permettre la gestions des clés étrangères en bdd
        /// on a une liste d'quipement et une liste d'utilisables pour sauvegarder les items
        /// présents dans chaques listes. Dans les equipements et les usables on retrouve la meme
        /// chose pour permettre de créer plusieurs listes d'equipemets ou d'usables utilisant
        /// les mêmes items
        /// </summary>
        #endregion

        #region Properties
        public String Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public String Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        public List<Equipment> MyListEquipments { get; private set; }

        public List<Usable> MyListUsables { get; private set; }

        public String CategorieName
        {
            get { return categorieName; }
            set
            {
                categorieName = value;
                OnPropertyChanged("CategorieName");
            }
        }
        #endregion

        #region Constructors
        public Items()
        {
                
        }

        public Items(string name, double price, string description, string categorieName)
        {
            this.name = name;
            this.price = price;
            this.description = description;
            this.categorieName = categorieName;
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        #endregion

        #region Events
        #endregion
    }
}
