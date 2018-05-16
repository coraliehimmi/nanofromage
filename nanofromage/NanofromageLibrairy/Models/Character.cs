using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanofromageLibrairy.Models
{
    public class Character : ModelBase, ActionsCharacter
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private String name;
        private String sex; /// M ou F
        private int level; /// 1
        private int money; /// 0
        private int ptLife;
        private int xp;
        private int idClan;
        private int hitPoint;
        private int magicPoint;
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
        #endregion

        #region Constructors
        public Character()
        {
            // contructeur vide par défaut
        }
        public Character(string name, string sex, int level, int money, int ptLife, int xp, int idClan, int hitPoint, int magicPoint)
        {
            this.name = name;
            this.sex = sex;
            this.level = level;
            this.money = money;
            this.ptLife = ptLife;
            this.xp = xp;
            this.idClan = idClan;
            this.hitPoint = hitPoint;
            this.magicPoint = magicPoint;
            ///base.PrecisionPoint = PrecisionPoint;

        }
        
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
