using MySql.Data.MySqlClient;
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
        Clan currentClan = new Clan();
        MySqlCommand cmd = new MySqlCommand();
        private String name;
        private String description;
        private int nb;

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables

        public event PropertyChangedEventHandler PropertyChanged;
        
        #endregion

        #region Attributs
        public Characters page { get; private set; }
        #endregion

        #region Properties
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
        public String GetName(int nb)
        {
            cmd.CommandText = "SELECT name FROM clans WHERE id =" + nb;
            return name;
        }

        public String GetDescription(int nb)
        {
            cmd.CommandText = "SELECT description FROM clans WHERE id =" + nb;
            return description;
        }
        #endregion

        #region Events
        private void Events()
        {
            this.page.XAMLConfirmUserControl.confirm.Click += Confirm_Click;
            
            /*if (this.page.Mage.IsSelected)
            {
                currentClan.NameClan = GetName(1);
                currentClan.Description = GetDescription(1);
            }
            else if (this.page.Hunter.IsSelected)
            {
                currentClan.NameClan = GetName(2);
                currentClan.Description = GetDescription(2);
            }
            else if (this.page.Warrior.IsSelected)
            {
                currentClan.NameClan = GetName(3);
                currentClan.Description = GetDescription(3);
            }*/
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

        //private void Male_Checked(object sender, RoutedEventArgs e)
        //{

        //this.page.XAMLCharacterUserControl.character.Source = new BitmapImage(new Uri("pack://aplication:,,,/Image/1.jpg"));
        //}

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
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
