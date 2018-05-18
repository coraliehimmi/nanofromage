using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanofromageLibrairy.Models
{
    public class Categories : ModelBase
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private String categorieName;
        private List<Items> myListItem;
        #endregion

        #region Properties
        public String CategorieName
        {
            get { return categorieName; }
            set
            {
                categorieName = value;
                OnPropertyChanged("CategorieName");
            }
        }

        public List<Items> MyListItem
        {
            get { return myListItem; }
            set
            {
                myListItem = value;
                OnPropertyChanged("MyListItem");
            }
        }
        #endregion

        #region Constructors
        public Categories()
        {

        }
        public Categories(String categorieName)
        {
            this.CategorieName = categorieName;
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
