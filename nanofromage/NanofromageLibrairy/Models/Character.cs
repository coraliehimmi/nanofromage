using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        public bool Sex { get; private set; }
        public int Level { get => level; set => level = value; }
        public int Money { get => money; set => money = value; }
        public int HitPoint { get => hitPoint; set => hitPoint = value; }


        #endregion

        #region Constructors
        public Character()
        {

        }
        public Character(String name, String description, Boolean sex, int level, int hitPoint, int money)
        {
            this.name = name;
            this.description = description;
            this.sex = sex;
            this.level = level;
            this.hitPoint = hitPoint;
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
