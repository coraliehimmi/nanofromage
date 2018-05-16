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
        private List<Items> myEquipment;
        private int idCharacter;
        #endregion

        #region Properties
        public List<Items> MyEquipment
        {
            get { return myEquipment; }
            set
            {
                myEquipment = value;
                OnPropertyChanged("MyEquipment");
            }
        }

        public int IdCharacter
        {
            get { return idCharacter; }
            set
            {
                idCharacter = value;
                OnPropertyChanged("IdCharacter");
            }
        }
        #endregion

        #region Constructors
        public Equipment(List<Items> myEquipment, int idCharacter)
        {
            this.myEquipment = myEquipment;
            this.idCharacter = idCharacter;
        }
        public Equipment()
        {

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
