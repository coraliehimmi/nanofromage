using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanofromageLibrairy.Models
{
    public abstract class Warrior : Character
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
        public override void Classes(string name, string description)
        {
            this.Description = "Maître en matière d’armes et d’armures de toutes sortes, il est à la fois courageux et vaillant.";
            this.Name = "Warrior";
        }

        public Warrior(string name, string description, bool sex, int level, int hitpoint, int money, int puissance, int rage) : base(name, description, sex, level, hitpoint, money)
        {
            this.Power = power;
            this.Rage = rage;
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
