using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanofromageLibrairy.Models
{
    public class Equipment : ModelBase
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private String name;
        private List<Items> myEquipment;
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

        public List<Items> MyEquipment
        {
            get { return myEquipment; }
        }
        #endregion

        #region Constructors
        public Equipment()
        {

        }
        public Equipment(String name, List<Items> myEquipment)
        {
            this.name = name;
            this.myEquipment = myEquipment;
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
