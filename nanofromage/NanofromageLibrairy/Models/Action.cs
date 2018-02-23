using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanofromageLibrairy.Models
{
    public class Action : ModelBase
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private String name;
        private int damages;
        private int bonus;
        #endregion

        #region Properties
        public string Name { get => name; set => name = value; }
        public int Damages { get => damages; set => damages = value; }
        public int Bonus { get => bonus; set => bonus = value; }
        #endregion

        #region Constructors
        public Action(string name, int damages, int bonus)
        {
            this.name = name;
            this.damages = damages;
            this.bonus = bonus;
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
