using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanofromageLibrairy.Models
{
    public class Categories : ModelBase
    {
        /// <summary>
        /// Dans les catégories se trouve une liste d'items car
        /// pour une catégorie on a plusieurs items qui correspondent
        /// Donc la clé étrangère est gèrée dans en base de données dans la
        /// table des items on retrouve l'id de la catégorie
        /// </summary>
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
                ///OnPropertyChanged("MyListItem");
            }
        }
        #endregion

        #region Constructors
        public Categories()
        {

        }
        public Categories(String categorieName, List<Items> myListItem)
        {
            this.CategorieName = categorieName;
            this.myListItem = myListItem;
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
