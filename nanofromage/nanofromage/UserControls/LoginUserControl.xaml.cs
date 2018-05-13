using Database.MySql;
using MySql.Data.MySqlClient;
using NanofromageLibrairy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace nanofromage.UserControls
{
    /// <summary>
    /// Logique d'interaction pour LoginUserControl.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl, INotifyPropertyChanged
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        public static String connectionString = "Server=localhost;Port=3306;Database=nanofromage;Uid=root;Pwd=";
        public static MySqlConnection connection;
        private String msg;
        public static String result;
        public static User currentUser;
        public static String currentName;
        public static String currentPassword;
        #endregion

        #region Attributs
        #endregion

        #region Properties
        public User CurrentUser
        {
            get { return currentUser; }
            set
            {
                currentUser = value;
                OnPropertyChanged("CurrentUser");
            }
        }
        #endregion

        #region Constructors
        public LoginUserControl()
        {
            this.InitializeComponent();
            this.DataContext = this;
            currentUser = new User();
            //currentName = currentUser.Login;
            //currentPassword = currentUser.Password;
            //textboxName.Text = currentUser.Login;
            //textboxPsw.Text = currentUser.Password;
            //currentName = textboxName.Text;
            //currentPassword = textboxPsw.Text;
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public static String SelectName(String currentName)
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT login FROM users WHERE login = @login";
                cmd.Parameters.AddWithValue("@login", currentName);
                using (MySqlDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        result = dataReader["Login"].ToString();
                    }
                }

            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            connection.Close();
            return result;
        }

        public static String SelectMdp(String currentName, String currentPassword) /// recherche si le mdp saisi par l'utilisateur correspond à celui de son login
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT password FROM users WHERE login = @login";
                cmd.Parameters.AddWithValue("Login", currentName);
                using (MySqlDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        result = dataReader["Password"].ToString();
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }

            connection.Close();
            return result;
        }

        public static void SaveNewUser(String currentName, String currentPassword)
        {
            Database<User> DbUser = new Database<User>();
            currentUser.Login = currentName.ToString();
            currentUser.Password = currentPassword.ToString();
            DbUser.Insert(currentUser);
        }

        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
        
        /*private void XAMLCharacterUserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }*/

       
    }
}
