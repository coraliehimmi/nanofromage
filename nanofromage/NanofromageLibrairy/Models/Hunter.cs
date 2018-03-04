using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanofromageLibrairy.Models
{
    public abstract class Hunter : Character
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private int precision;

        private String description;

        public String Description
        {
            get { return description; }
            set { description = value; }
        }

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

        public override void Classes(string name, string description)
        {
            this.Description = "il peut combattre aussi bien de près que de loin. C’est un tireur hors pair possédant de grandes capacités dans ce domaines. Il peut lancer plusieurs flèches en même temps et peut appeler des animaux en combat";
            this.Name = "Hunter";
        }

        public Hunter(string name, string description, bool sex, int level, int hitpoint, int money, int precision) : base(name, description, sex, level, hitpoint, money)
        {
           
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string description)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(description));
            }
        }
        #endregion

    }
}
