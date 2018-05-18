using MySql.Data.MySqlClient;
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
    /// 

    public partial class Characters : Page
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        #endregion

        #region Properties
        #endregion

        #region Constructors
        public Characters()
        {
            InitializeComponent();
            new CharactersViewModel(this);
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        
        #endregion

        #region Events
        #endregion
    }
}