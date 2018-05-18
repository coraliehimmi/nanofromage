using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanofromageLibrairy.Models
{
    public class Enemy : ModelBase
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion
        
        #region Attributs
        private String name;
        private int ptAttack;
        private int ptLife;
        private int xp;
        private int money;
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

        public int PtAttack
        {
            get { return ptAttack; }
            set
            {
                ptAttack = value;
                OnPropertyChanged("PtAttack");
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

        public int Money
        {
            get { return money; }
            set
            {
                money = value;
                OnPropertyChanged("Money");
            }
        }
        #endregion

        #region Constructors
        public Enemy()
        {

        }
        public Enemy(String name, int ptAttack, int ptLife, int xp, int money)
        {
            this.name = name;
            this.ptAttack = ptAttack;
            this.ptLife = ptLife;
            this.xp = xp;
            this.money = money;

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
