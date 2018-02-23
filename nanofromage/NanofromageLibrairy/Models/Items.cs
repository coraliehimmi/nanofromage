using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanofromageLibrairy.Models
{
    public class Items : ModelBase
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private String name;
        private int quantity;
        private double price;
        private String description;
        #endregion

        #region Properties
        public string Name { get => name; set => name = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Price { get => price; set => price = value; }
        public string Description { get => description; set => description = value; }
        #endregion

        #region Constructors
        public Items()
        {
                
        }

        public Items(string name, int quantity, double price, string description)
        {
            this.name = name;
            this.quantity = quantity;
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
