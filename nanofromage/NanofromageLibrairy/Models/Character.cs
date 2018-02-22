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


        #endregion

        #region Constructors
        public Character()
        {

        }
        public Character(String name, String description, Boolean sex, int level, int hitpoint, int money)
        {
            this.name = name;
            this.description = description;
            this.sex = sex;
            this.level = level;
            this.hitPoint = hitpoint;
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
