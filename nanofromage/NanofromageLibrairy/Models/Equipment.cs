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
        private List<Items> myEquipment;
        private Character myChar;
        #endregion

        #region Properties
        public Character MyChar
        {
            get { return myChar; }
            set { myChar = value; }
        }

        public List<Items> MyEquipment
        {
            get { return myEquipment; }
            set
            {
                myEquipment = value;
                OnPropertyChanged("MyEquipment");
            }
        }
        #endregion

        #region Constructors
        public Equipment()
        {

        }
        public Equipment(List<Items> myEquipment, Character myChar)
        {
            this.myEquipment = myEquipment;
            this.myChar = myChar;
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
