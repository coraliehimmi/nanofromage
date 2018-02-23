using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanofromageLibrairy.Models
{
    public class Fight : ModelBase
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private TimeSpan duration;
        #endregion

        #region Properties

        public TimeSpan Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        #endregion

        #region Constructors
        public Fight()
        {
                
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public void Attak()
        {

        }

        public void ObtainAWinner()
        {

        }
        #endregion

        #region Events
        #endregion
    }
}
