using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanofromageLibrairy.Models
{
    public class Adventure : ModelBase
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private String name;
        private TimeSpan duration;
        private int reward;
        #endregion

        #region Properties
        public string Name { get => name; set => name = value; }
        public TimeSpan Duration { get => duration; set => duration = value; }
        public int Reward { get => reward; set => reward = value; }
        #endregion

        #region Constructors
        public Adventure(string name, TimeSpan duration, int reward)
        {
            this.name = name;
            this.duration = duration;
            this.reward = reward;
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
