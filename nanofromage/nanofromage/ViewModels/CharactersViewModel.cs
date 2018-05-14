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
        private String result;
        private int rslt;
        private String currentNameClan;
        private String connectionString = "Server=localhost;Port=3306;Database=nanofromage;Uid=root;Pwd=";
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
            currentNameClan = FirstConnexionViewModel.currentName;
            Events();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        /*public String GetName(int nb)
        {
            cmd.CommandText = "SELECT name FROM clans WHERE id =" + nb;
            return name;
        }

        public String GetDescription(int nb)
        {
            cmd.CommandText = "SELECT description FROM clans WHERE id =" + nb;
            return description;
        }*/
        private void SaveCharacter()
        {
            currentCharacter = new Character();
            test = SexUserControl.SexChoice();
            currentCharacter.IdClan = RecupIdClan(currentNameClan);
            currentCharacter.Name = NameUserControl.nameUC;
            currentCharacter.Level = 1;
            currentCharacter.Money = 0;
            currentCharacter.Power = 5;
            currentCharacter.Rage = 0;
        }
        private int RecupIdClan(String valeur)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT NameClan FROM clans WHERE NameClan = @NameClan";
            cmd.Parameters.AddWithValue("NameClan", valeur);
            ///cmd.ExecuteScalar();
            using (MySqlDataReader dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    rslt = int.Parse(dataReader["NameClan"].ToString());
                    //test.Text = result;
                }
            }
            connection.Close();
            return rslt;
        }
        #endregion

        #region Events
        private void Events()
        {
            this.page.XAMLConfirmUserControl.confirm.Click += Confirm_Click;
        }

        //public BitmapImage GetMyImage => new BitmapImage(new Uri("/Image/1.png" + UriKind.Absolute));
        

        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        //this.page.XAMLCharacterUserControl.character.Source = new BitmapImage(new Uri("pack://aplication:,,,/Image/1.jpg"));
        //}

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            SaveCharacter();
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Home();
        }
        #endregion

        //this.page.XAMLCharacterUserControl.character.Source = new BitmapImage(new Uri("pack://aplication:,,,/Image/1.jpg"));
        //this.page.XAMLNameUserControl.male.Checked += Male_Checked;

        //this.page.XAMLCharacterUserControl.female.Che
        /*BitmapImage b = new BitmapImage();
        b.BeginInit();
        b.UriSource = new Uri("pack://aplication:,,,/Image/1.jpg");
        b.EndInit();*/
    }
}
