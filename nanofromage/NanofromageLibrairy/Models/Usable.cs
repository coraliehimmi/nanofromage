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
        #endregion

        #region Properties
        public List<Items> MyUsables
        {
            get { return myUsables; }
        }
        #endregion

        #region Constructors
        public Usable()
        {

        }
        public Usable(List<Items> myUsables, Character myChar)
        {
            this.myUsables = myUsables;
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
