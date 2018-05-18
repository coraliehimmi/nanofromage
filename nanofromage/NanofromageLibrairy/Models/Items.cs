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
        private List<Categories> myList;
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
        public List<Categories> MyList
        {
            get { return myList; }
            set
            {
                myList = value;
                OnPropertyChanged("MyList");
            }
        }


        #endregion

        #region Constructors
        public Items()
        {
                
        }

        public Items(string name, double price, string description)
        {
            this.name = name;
            this.price = price;
            this.description = description;
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
