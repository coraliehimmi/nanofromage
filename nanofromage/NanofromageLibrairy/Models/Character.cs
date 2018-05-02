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





<<<<<<< HEAD
=======
        public string Description
        {
            set => description = value;
            get => description;
        }

        public bool Sex { get => sex; set => sex = value; }
        public int Level { get => level; set => level = value; }
        public int Money { get => money; set => money = value; }
        public int HitPoint { get => hitPoint; set => hitPoint = value; }
        public List<Mage> ListMages { get => listMages; set => listMages = value; }
        public List<Hunter> ListHunters { get => listHunters; set => listHunters = value; }
        public List<Warrior> ListWarriors { get => listWarriors; set => listWarriors = value; }
        
>>>>>>> c73a337624843ace3b2b47be0dc8dec157ed70c0
        #endregion

        #region Constructors
        public Character()
        {

        }
<<<<<<< HEAD

        public Character(string name, bool sex, int level, int money, int power, int rage)
        {
            this.name = name;
            this.sex = sex;
            this.level = level;
            this.money = money;
            this.power = power;
            this.rage = rage;
=======
        // contructeur vide par défaut
        public Character(string description)
        {
            this.description = description;
>>>>>>> c73a337624843ace3b2b47be0dc8dec157ed70c0
        }

        // contructeur vide par défaut

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
