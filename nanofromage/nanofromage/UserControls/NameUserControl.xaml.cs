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
    /// Logique d'interaction pour NameUserControl.xaml
    /// Permet d'afficher le nom du personnage courant sur la page d'accueil
    /// </summary>
    public partial class NameUserControl : UserControl, INotifyPropertyChanged
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        public static String nameUC;
        #endregion

        #region Properties
        public String NameUC
        {
            get { return nameUC; }
            set
            {
                nameUC = value;
                OnPropertyChanged("NameUC");
            }
        }
        #endregion

        #region Constructors
        public NameUserControl()
        {
            InitializeComponent();
            DataContext = this;
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

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
