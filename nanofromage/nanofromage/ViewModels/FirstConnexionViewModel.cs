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
        private String message;
        private String selectName;
        private String selectPassword;
        public static String currentName;
        private String currentPassword;
        private MySqlConnection connection;
        private User admin = new User("admin", "admin");
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
            Init();
            Events();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        private bool OpenConnection()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("C'est une première ouverture de l'application");
                return false;
            }
        } /// Teste la connection à la base de données

        private void Init()
        {
            if (OpenConnection() == false)
            {
                Database<User> DbUser = new Database<User>();
                DbUser.Insert(admin);
            }
        } /// Fonction qui insère l'utilisateur admin seulement si c'est la première ouverture de l'appli
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
            LoginUserControl.currentName = LoginUserControl.currentUser.Login; /// Ici la valeur du CurrentName prend la valeur de la saisie de l'utilisateur
            currentName = LoginUserControl.currentName; /// pour une visibilité plus claire, je mets cette variable dans une autre varaible pour la réutiliser
            LoginUserControl.currentPassword = LoginUserControl.currentUser.Password;
            this.currentPassword = LoginUserControl.currentPassword;
            selectName = LoginUserControl.SelectName(currentName);
            selectPassword = LoginUserControl.SelectMdp(currentName, this.currentPassword);
            if (currentName is null)
            {
                message = "Aucun nom d'utilisateur n'a été saisi.";
                MessageBox.Show(message);
                Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new FirstConnexion();
            }
            else if (currentName == selectName && currentPassword == selectPassword)
            {
                Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Characters();
            }
            else
            {
                message = "L'utilisateur est inconnu ou le mot de passe est erroné.";
                MessageBox.Show(message);
                Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new FirstConnexion();
            }
        }

        private void Inscription_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Inscription();
        }
        #endregion
    }
}
