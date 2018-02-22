using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanofromageLibrairy.Models
{
    public class Equipment : Items
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private String name;
        private String description;


        #endregion

        #region Properties
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        #endregion

        #region Constructors
        public Equipment(string name, string description)
        {
            this.Name = name;
            this.Description = description;
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
