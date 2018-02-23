using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanofromageLibrairy.Models
{
    public class User : ModelBase
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private String login;
        private String password;
        #endregion

        #region Properties
        #endregion

        #region Constructors
        public User()
        {
        }
        public User(String login, String password)
        {
            this.Login = login;
            this.Password = password;
        }

        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public void Connexion()
        {

        }
        #endregion

        #region Events
        #endregion
    }
}
