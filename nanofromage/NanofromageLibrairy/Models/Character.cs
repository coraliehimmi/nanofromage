using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NanofromageLibrairy.Models
{
    public class Character : ModelBase
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private String name;
        private String sex;
        private int level;
        private int money;
        private int ptLife;
        private int ptAttack;
        private int xp;
        private int idClan;
        private int hitPoint;
        private int magicPoint;
        private Equipment equipment;
        #endregion

        #region Properties
        public String Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public String Sex
        {
            get { return sex; }
            set
            {
                sex = value;
                OnPropertyChanged("Sex");
            }
        }

        public int Level
        {
            get { return level; }
            set
            {
                level = value;
                OnPropertyChanged("Level");
            }
        }

        public int Money
        {
            get { return money; }
            set
            {
                money = value;
                OnPropertyChanged("Money");
            }
        }

        public int IdClan
        {
            get { return idClan; }
            set
            {
                idClan = value;
                OnPropertyChanged("IdClan");
            }
        }

        public int PtLife
        {
            get { return ptLife; }
            set
            {
                ptLife = value;
                OnPropertyChanged("PtLife");
            }
        }

        public int PtAttack
        {
            get { return ptAttack; }
            set
            {
                ptAttack = value;
                OnPropertyChanged("PtAttack");
            }
        }


        public int Xp
        {
            get { return xp; }
            set
            {
                xp = value;
                OnPropertyChanged("Xp");
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

        public Equipment Equipment
        {
            get { return equipment; }
            set
            {
                equipment = value;
                ///OnPropertyChanged("Equipment");
            }
        }

        #endregion

        #region Constructors
        public Character()
        {
            // contructeur vide par défaut
        }
        public Character(string name, string sex, int level, int money, int ptLife, int ptAttack, int xp, int idClan, int hitPoint, int magicPoint)
        {
            this.name = name;
            this.sex = sex;
            this.level = level;
            this.money = money;
            this.ptLife = ptLife;
            this.ptAttack = ptAttack;
            this.xp = xp;
            this.idClan = idClan;
            this.hitPoint = hitPoint;
            this.magicPoint = magicPoint;
        }

        public Character(string name, string sex, int level, int money, int ptLife, int ptAttack, int xp, int idClan, int hitPoint, int magicPoint, Equipment equipment)
        {
            this.name = name;
            this.sex = sex;
            this.level = level;
            this.money = money;
            this.ptLife = ptLife;
            this.ptAttack = ptAttack;
            this.xp = xp;
            this.idClan = idClan;
            this.hitPoint = hitPoint;
            this.magicPoint = magicPoint;
            this.equipment = equipment;
        }
        /// <summary>
        /// Constructeur à utiliser pour faire l'update de l'id de l'équipement mais n'a pas pu etre fait
        /// </summary>

        public void Attaque()
        {
            throw new NotImplementedException();
        }

        public void AttaqueSpe()
        {
            throw new NotImplementedException();
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
