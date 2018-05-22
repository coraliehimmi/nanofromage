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
        public static String currentName;
        public static Enemy enemy1;
        public static Enemy enemy2;
        #endregion

        #region Constants
        #endregion

        #region Variables
        private String connectionString = "Server=localhost;Port=3306;Database=nanofromage;Uid=root;Pwd=";
        private int idCharacter;
        private String message;
        private String selectName;
        private String selectPassword;
        
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
            enemy1 = new Enemy("Enemy1", 5, 30, 10, 10);
            enemy2 = new Enemy("Enemy2", 5, 30, 10, 10);
            if (OpenConnection() == false)
            {
                Database<User> DbUser = new Database<User>();
                DbUser.Insert(admin);
                Database<Enemy> DbEnemy = new Database<Enemy>();
                DbEnemy.Insert(enemy1);
                DbEnemy.Insert(enemy2);
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

        private void SelectIdChar()
        {
            try
            {
                connection = new MySqlConnection(ModelBase.CONNECTIONSTRING);
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT IdCharacter FROM users WHERE Login = @Login ";
                cmd.Parameters.AddWithValue("Login", currentName);
                using (MySqlDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        idCharacter = int.Parse(dataReader["IdCharacter"].ToString());
                        //test.Text = result;
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }

            connection.Close();

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
                SelectIdChar();
                if (idCharacter == 0)
                {
                    Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Characters();
                }
                /// Ici l'utilkisateur n'a jamais créé de personnage
                else
                {
                    Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Home();
                }
                /// Si l'utilisateur a déjà créé un personnage il arrivera directement sur la page d'accueil
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
