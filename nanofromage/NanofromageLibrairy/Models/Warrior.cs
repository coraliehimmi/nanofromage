using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanofromageLibrairy.Models
{
    public class Warrior : Character
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private int power;
        private int rage;
        #endregion

        #region Properties
        public int Power { get => power; set => power = value; }
        public int Rage { get => rage; set => rage = value; }
        #endregion

        #region Constructors
        public Warrior()
        {
            this.Power = power;
            this.Rage = rage;
            this.Description = "Maître en matière d’armes et d’armures de toutes sortes, il est à la fois courageux et vaillant.";
        }

        public Warrior(string name, string description, bool sex, int level, int hitpoint, int money, int puissance, int rage) : base(name, description, sex, level, hitpoint, money)
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
