using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanofromageLibrairy.Models
{
    public class Hunter : Character
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private int precision;
        
        #endregion

        #region Properties
        public int Precision { get => precision; set => precision = value; }
        #endregion

        #region Constructors
        /*public Hunter()
        {
            this.Precision = precision;
            this.Description = "il peut combattre aussi bien de près que de loin. C’est un tireur hors pair possédant de grandes capacités dans ce domaines. Il peut lancer plusieurs flèches en même temps et peut appeler des animaux en combat";
        }*/

        public Hunter()
        {
            
        }
        //contructeur vide par défaut

        public Hunter(String name, String description, Boolean sex, int level, int hitpoint, int money, int precision) : base(name, description, sex, level, hitpoint, money)
        {
            base.Description = "il peut combattre aussi bien de près que de loin. C’est un tireur hors pair possédant de grandes capacités dans ce domaines. Il peut lancer plusieurs flèches en même temps et peut appeler des animaux en combat";
            this.Precision = precision;
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
