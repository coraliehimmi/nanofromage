﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanofromageLibrairy.Models
{
    public abstract class Mage : Character
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private int magicPoint;
        #endregion

        #region Properties
        public int MagicPoint { get => magicPoint; set => magicPoint = value; }
        #endregion

        #region Constructors
        public override void Classes(string name, string description)
        {
            this.Description = "à force d'étudier sans cesse, il parvient à maîtriser la magie et acquiert d'incroyables pouvoirs.";
            this.Name = "Mage";
        }

        public Mage(string name, string description, bool sex, int level, int hitpoint, int money, int magicPoint) : base(name, description, sex, level, hitpoint, money)
        {
            this.MagicPoint = magicPoint;
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
