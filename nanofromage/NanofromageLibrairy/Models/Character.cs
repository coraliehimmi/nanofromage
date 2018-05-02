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
        private Boolean sex;
        private int level;
        private int money;
        private int power;
        private int rage;
        
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
        public Boolean Sex
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

        public int Power
        {
            get { return power; }
            set
            {
                power = value;
                OnPropertyChanged("Power");
            }
        }
        public int Rage
        {
            get { return rage; }
            set
            {
                rage = value;
                OnPropertyChanged("Rage");
            }
        }
        #endregion

        #region Constructors
        public Character()
        {
            // contructeur vide par défaut
        }
        public Character(string name, bool sex, int level, int money, int power, int rage)
        {
            this.name = name;
            this.sex = sex;
            this.level = level;
            this.money = money;
            this.power = power;
            this.rage = rage;
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
