using Database.MySql;
using nanofromage.Views;
using NanofromageLibrairy.Models;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using nanofromage.UserControls;

namespace nanofromage.ViewModels
{
    public class FirstConnexionViewModel
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        private String connectionString = "Server=localhost;Port=3306;Database=nanofromage;Uid=root;Pwd=";
        private String result = "";
        private String message = "";
        private MySqlConnection connection;
        private String name;
        private String password;
        #endregion

        #region Attributs
        public FirstConnexion page { get; private set; }
        #endregion

        #region Properties
        #endregion

        #region Constructors
        public FirstConnexionViewModel(FirstConnexion page)
        {
            this.page = page;
            Events();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        private String SelectLogin(String name) /// recherche si le login saisi par l'urilisateur est présent en BDD
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT login FROM User WHERE login = @login";
            cmd.Parameters.AddWithValue("@login", name); 
            using (MySqlDataReader dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    result = dataReader["Login"].ToString();
                }
            }
            connection.Close();
            return result;
        }

        private String SelectMdp(String name, String mdp) /// recherche si le mdp saisi par l'utilisateur correspond à celui de son login
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT mdp FROM User WHERE login = @login";
            cmd.Parameters.AddWithValue("Login", name);
            using (MySqlDataReader dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    result = dataReader["Mdp"].ToString();
                }
            }
            connection.Close();
            return result;
        }
        #endregion

        #region Events
        private void Events()
        {
            this.page.XAMLConfirmUserControl.confirm.Click += Confirm_Click;
            this.page.XAMLInscriptionUserControl.inscription.Click += Inscription_Click;
            ///this.page.XAMLLoginUserControl.name
        }

        private void Confirm_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            name = SelectLogin(LoginUserControl.currentUser.Login); /// Prend la valeur du résultat de la requête de sélection
            password = SelectMdp(LoginUserControl.currentUser.Login, LoginUserControl.currentUser.Password); /// Prend la valeur du résultat de la requête de sélection
            if (name == LoginUserControl.currentUser.Login && password == LoginUserControl.currentUser.Password)
            {
                Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Characters();
            }
            else
            {
                message = "L'utilisateur est inconnu ou le mot de passe est erroné"; /// AFFICHER MESSAGE !!!!
            }
        }

        private void Inscription_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Inscription();
        }
        #endregion
    }
}
