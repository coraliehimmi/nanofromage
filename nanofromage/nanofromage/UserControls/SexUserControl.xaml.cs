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
    /// Logique d'interaction pour SexUserControl.xaml
    /// Permet de gérer le choix homme / femme du joueur
    /// </summary>
    public partial class SexUserControl : UserControl, INotifyPropertyChanged
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        public event PropertyChangedEventHandler PropertyChanged;
        public static String result;
        public static String sexe;
        #endregion

        #region Attributs
        #endregion

        #region Properties
        #endregion

        #region Constructors
        public SexUserControl()
        {
            InitializeComponent();
            DataContext = this;
            Events();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        /// <summary>
        /// Selon le chois on obtient un F pour femelle et M pour male
        /// </summary>
        private void SexChoice()
        {
            try
            {
                if (femaleUC.IsChecked == true)
                {
                    sexe = "F";
                }
                else if (maleUC.IsChecked == true)
                {
                    sexe = "M";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion

        #region Events
        private void Events()
        {
            maleUC.Checked += MaleUC_Checked;
            femaleUC.Checked += FemaleUC_Checked;
        }

        private void FemaleUC_Checked(object sender, RoutedEventArgs e)
        {
            femaleUC.IsChecked = true;
            maleUC.IsChecked = false;
            SexChoice();
            /// Si on coche femelle, male est automatiquement décoché et vice versa
        }

        private void MaleUC_Checked(object sender, RoutedEventArgs e)
        {
            maleUC.IsChecked = true;
            femaleUC.IsChecked = false;
            SexChoice();
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
