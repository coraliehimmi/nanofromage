using MySql.Data.MySqlClient;
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
        private String password;
        private String login;
        private int idCharacter;
        #endregion

        #region Properties
        public String Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        public String Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public int IdCharacter
        {
            get { return idCharacter; }
            set { idCharacter = value; }
        }

        #endregion

        #region Constructors
        public User()
        {
        }
        public User(String login, String password)
        {
            this.login = login;
            this.password = password;
        }
        public User(String login, String password, int idCharacter)
        {
            this.login = login;
            this.password = password;
            this.idCharacter = idCharacter;
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
