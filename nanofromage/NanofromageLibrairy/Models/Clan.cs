﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanofromageLibrairy.Models
{
    public class Clan : ModelBase
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private String nameClan;
        private String description;
        private int hitPoint;
        private int magicPoint;
        #endregion

        #region Properties
        public String NameClan
        {
            get { return nameClan; }
            set
            {
                nameClan = value;
                OnPropertyChanged("NameClan");
            }
        }

        public String Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        public int HitPoint
        {
            get { return hitPoint; }
            set
            {
                hitPoint = value;
                OnPropertyChanged("HitPoint");
            }
        }

        public int MagicPoint
        {
            get { return magicPoint; }
            set
            {
                magicPoint = value;
                OnPropertyChanged("MagicPoint");
            }
        }
        #endregion

        #region Constructors
        public Clan()
        {
        }

        public Clan(string nameClan, string description, int hitPoint, int magicPoint)
        {
            this.nameClan = nameClan;
            this.description = description;
            this.hitPoint = hitPoint;
            this.magicPoint = magicPoint;
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
