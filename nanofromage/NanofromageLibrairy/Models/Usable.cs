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
        private Character myChar;
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

        public Character MyChar
        {
            get { return myChar; }
            set { myChar = value; }
        }
        #endregion

        #region Constructors
        public Usable()
        {

        }
        public Usable(List<Items> myUsables, Character myChar)
        {
            this.myUsables = myUsables;
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
