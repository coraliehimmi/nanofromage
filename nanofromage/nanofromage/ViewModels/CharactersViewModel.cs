using Database.MySql;
using MySql.Data.MySqlClient;
using nanofromage.UserControls;
using nanofromage.Views;
using NanofromageLibrairy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace nanofromage.ViewModels
{
    public class CharactersViewModel : INotifyPropertyChanged
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        private Char test;
        private String champ;
        private String table;
        private String result;
        private String msg;
        private MySqlConnection connection;
        private int rslt;
        private String currentNameClan;
        ///private String connectionString = "Server=localhost;Port=3306;Database=nanofromage;Uid=root;Pwd=";
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Attributs
        public static Character currentCharacter;
        public Characters page { get; private set; }
        #endregion

        #region Properties
        public Character CurrentCharacter
        {
            get { return currentCharacter; }
            set
            {
                currentCharacter = value;
                OnPropertyChanged("CurrentCharacter");
            }
        }

        #endregion

        #region Constructors
        public CharactersViewModel(Characters page)
        {
            this.page = page;
            Events();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        private void SaveCharacter()
        {
            currentCharacter = new Character();
            currentNameClan = ComboBoxUserControl.selectedClan;
            currentCharacter.Sex = SexUserControl.sexe;
            SetParameters("NameClan", "clans");
            currentCharacter.IdClan = RecupId(currentNameClan);
            currentCharacter.Name = NameUserControl.nameUC;
            currentCharacter.Level = 1;
            currentCharacter.Money = 0;
            currentCharacter.PtLife = 15;
            currentCharacter.Xp = 0;
            currentCharacter.HitPoint = ComboBoxUserControl.currentClan.HitPoint;
            currentCharacter.MagicPoint = ComboBoxUserControl.currentClan.MagicPoint;
        }

        private void SaveInBdd()
        {
            try
            {
                Database<Character> DbCharacter = new Database<Character>();
                DbCharacter.Insert(currentCharacter);
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void SetParameters(String myWhereClause, String myTable)
        {
            champ = myWhereClause;
            table = myTable;
        }

        private int RecupId(String valeur)
        {
            try
            {
                connection = new MySqlConnection(ModelBase.CONNECTIONSTRING);
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT Id FROM " + table + " WHERE " + champ + " = @" + champ;
                ///cmd.CommandText = "SELECT " + champ1 + " FROM " + table + " WHERE " + champ2 + " = @" + champ2;
                cmd.Parameters.AddWithValue(champ, valeur);
                ///cmd.ExecuteScalar();
                using (MySqlDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        rslt = int.Parse(dataReader["Id"].ToString());
                        //test.Text = result;
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }

            connection.Close();
            return rslt;
        }

        private void UpdateUser()
        {
            try
            {
                int id;
                MySqlConnection connection = new MySqlConnection(ModelBase.CONNECTIONSTRING);
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE users SET IdCharacter = @IdCharacter WHERE Login = @Login";
                SetParameters("Name","characters");
                id = RecupId(currentCharacter.Name);
                cmd.Parameters.AddWithValue("IdCharacter", id);
                cmd.Parameters.AddWithValue("Login", FirstConnexionViewModel.currentName);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Events
        private void Events()
        {
            this.page.XAMLConfirmUserControl.confirm.Click += Confirm_Click;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            SaveCharacter();
            if (currentCharacter.Name is null || currentCharacter.Sex is null || currentCharacter.IdClan == 0)
            {
                msg = "Vous devez compléter toutes les informations";
                MessageBox.Show(msg);
            }
            /// Si un champ n'est pas complété on ne peut pas continuer.
            else
            {
                try
                {
                    SaveInBdd();
                    UpdateUser();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
                Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Home();
            }
            /// Sinon, on valide la sauvegarde en BDD et on arrive sur la page d'accueil.
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}
