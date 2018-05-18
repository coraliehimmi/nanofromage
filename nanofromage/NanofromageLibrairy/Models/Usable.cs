using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanofromageLibrairy.Models
{
    public class Usable : ModelBase
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private List<Items> myUsables;
        private int idCharacter;
        #endregion

        #region Properties
        public List<Items> MyUsables
        {
            get { return myUsables; }
            set
            {
                myUsables = value;
                OnPropertyChanged("MyUsables");
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
        public Usable()
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
