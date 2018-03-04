using nanofromage.ViewModels;
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

namespace nanofromage.Views
{
    /// <summary>
    /// Logique d'interaction pour Characters.xaml
    /// </summary>
    public sealed partial class Characters : Page, INotifyPropertyChanged
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private Mage currentMage;
        #endregion

        #region Properties

        public Mage CurrentMage
        {
            get { return this.currentMage; }
            set {
                this.currentMage = value;
                OnPropertyChanged("CurrentMage");
            }
        }

        #endregion

        #region Constructors
        public Characters()
        {
            this.InitializeComponent();
            this.DataContext = this;

        }

        public Characters(Mage currentMage)
        {
            CurrentMage = currentMage;
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
