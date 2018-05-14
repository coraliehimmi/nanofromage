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
    /// </summary>
    public partial class SexUserControl : UserControl, INotifyPropertyChanged
    {

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        public static Char result;
        public static Char sexe;
        private RadioButton rdb = new RadioButton();
        #endregion

        #region Attributs
        public static Char test;
        //private Character currentCharacter;
        #endregion

        #region Properties

        public Char Test
        {
            get { return test; }
            set
            {
                test = value;
                OnPropertyChanged("Test");
            }
        }
        #endregion

        #region Constructors
        public SexUserControl()
        {
            InitializeComponent();
            DataContext = this;
            Events();
            test = SexChoice();
            ///Events();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        #endregion

        #region Events
        private void Events()
        {
            rdb.CheckedChanged += new System.EventHandler(RadioButtonCheckedChanged);
            this.maleUC.changed
        }

        public static Char SexChoice()
        {
            try
            {
                if (femaleUC.IsChecked == true)
                {
                    result = 'F';
                }
                else if (maleUC.IsChecked == true)
                {
                    result = 'M';
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return result;
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
        #endregion
    }
}
