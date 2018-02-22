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
        #endregion

        #region Properties
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public bool Sex { get => sex; set => sex = value; }
        public int Level { get => level; set => level = value; }
        public int HitPoint { get => hitPoint; set => hitPoint = value; }
        #endregion

        #region Constructors
        public Character()
        {

        }
        public Character(String name, String description, Boolean sex, int level, int hitpoint)
        {
            this.name = name;
            this.description = description;
            this.sex = sex;
            this.level = level;
            this.hitPoint = hitpoint;
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
