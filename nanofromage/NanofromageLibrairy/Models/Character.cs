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
        private List<Mage> listMages;
        private List<Hunter> listHunters;
        private List<Warrior> listWarriors;
        #endregion

        #region Attributs
        private String name;
        private String description;
        private Boolean sex;
        private int level;
        private int hitPoint;
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
        
        #endregion

        #region Constructors
        public Character()
        {

        }
        // contructeur vide par défaut
        public Character(string description)
        {
            this.description = description;
        }

        public new void Attaque()
        {
            //throw new NotImplementedException();
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
