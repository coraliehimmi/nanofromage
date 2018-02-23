using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanofromageLibrairy.Models
{
    public class Usable : Items
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private int quantityUsable;
        #endregion

        #region Properties
        public int QuantityUsable { get => quantityUsable; set => quantityUsable = value; }
        #endregion

        #region Constructors
        public Usable (string name, int quantity, double price, string description, int quantityUsable) : base(name, quantity, price, description, quantityUsable)
        {
            this.QuantityUsable = quantityUsable;
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
