using System;
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
        private int precisionPoint;
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

        public int PrecisionPoint
        {
            get { return precisionPoint; }
            set
            {
                precisionPoint = value;
                OnPropertyChanged("PrecisionPoint");
            }
        }

        public int MagicPoint
        {
            get { return magicPoint; }
            set
            {
                magicPoint = value;
                OnPropertyChanged("PrecisionPoint");
            }
        }
        #endregion

        #region Constructors
        public Clan()
        {
        }

        public Clan(string nameClan, string description, int hitPoint, int precisionPoint, int magicPoint)
        {
            this.nameClan = nameClan;
            this.description = description;
            this.hitPoint = hitPoint;
            this.precisionPoint = precisionPoint;
            this.magicPoint = magicPoint;
        }
        //contructeur vide par défaut
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        #endregion

        #region Events
        #endregion
    }
}
