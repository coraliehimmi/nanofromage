using NanofromageLibrairy.Models;
using Database.MySql;
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
    /// Logique d'interaction pour ButtonsUserControl.xaml
    /// </summary>
    public partial class ButtonsUserControl : UserControl, INotifyPropertyChanged
    {
        private List<Items> myEquipement;
        private List<Items> myUsables;
        private List<Categories> myListCategories;

        public List<Categories> MyListCategories
        {
            get { return myListCategories; }
            set
            {
                myListCategories = value;
                OnPropertyChanged("MyListCategories");
            }
        }

        /*private void Init()
        {
            Database<Categories> DbCat = new Database<Categories>();
            myListCategories = DbCat.Get();
            this.bouton.Content = myListCategories[0].CategorieName.ToString();
        }*/

        public ButtonsUserControl()
        {
            InitializeComponent();
            DataContext = this;
            ///Init();
        }

        private void bouton1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bouton2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bouton3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bouton4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bouton5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bouton6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bouton7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bouton8_Click(object sender, RoutedEventArgs e)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
