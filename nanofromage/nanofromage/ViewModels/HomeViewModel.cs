using Database.MySql;
using LoggerUtil;
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
using System.Windows.Media.Imaging;

namespace nanofromage.ViewModels
{
    public class HomeViewModel
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        private int idChar;
        private int result;
        private int id;
        private MySqlConnection connection;
        private String msg;
        #endregion

        #region Attributs
        private Home page;
        #endregion

        #region Properties
        public Home Page { get; private set; }
        #endregion

        #region Constructors
        public HomeViewModel(Home page)
        {
            this.page = page;
            Init();
            SaveInBdd();
            Events();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        private void Init()
        {
            Character charTest = new Character();
            Database<Character> DbChar = new Database<Character>();
            idChar = RecupId(FirstConnexionViewModel.currentName);
            charTest = DbChar.Get(idChar).Result;
           if (charTest.Sex == "M")
            {
                this.page.XAMLInfosPersoUC.imgsex.Source  = new BitmapImage(new Uri("/Resources/male.png", UriKind.Relative));
                this.page.XAMLButtonsUserControl.myperso.Source = new BitmapImage(new Uri("/Resources/persohomme.jpg", UriKind.Relative));
            }
           else if (charTest.Sex == "F")
            {
                this.page.XAMLInfosPersoUC.imgsex.Source = new BitmapImage(new Uri("/Resources/femelle.png", UriKind.Relative));
                this.page.XAMLButtonsUserControl.myperso.Source = new BitmapImage(new Uri("/Resources/persofemme.png", UriKind.Relative));
            }
            /*charTest.Level = 1;
            charTest.Money = 10;
            charTest.Xp = 10;
            charTest.Name = "Coralie";
            charTest.PtLife = 15;
            charTest.MagicPoint = 10;*/
            this.page.XAMLInfosPersoUC.CurrentCharacter = charTest;
            this.page.XAMLInfoLevelUC.CurrentCharacter = charTest;
        }
        /// <summary>
        /// Casque en fer / 6 / Casque en fer brut
        /// Tunique d'entraînement / 2 / Tunique d'aventurier débutant
        /// Botte d'entraînement / 1 / Botte pour aventurier débutant
        /// pantalon d'entraînement / 3 / Pantalon pour aventurier débutant
        /// Potion de vie / 5 / Permet de récupérer 5 PV
        /// Potion de mana / 5 / Permet de récupérer 5 PM
        /// </summary>

            

        private int RecupId(String valeur)
        {
            try
            {
                String table = "users";
                String champ = "Login";
                connection = new MySqlConnection(ModelBase.CONNECTIONSTRING);
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT IdCharacter FROM " + table + " WHERE " + champ + " = @" + champ;
                ///cmd.CommandText = "SELECT " + champ1 + " FROM " + table + " WHERE " + champ2 + " = @" + champ2;
                cmd.Parameters.AddWithValue(champ, valeur);
                ///cmd.ExecuteScalar();
                using (MySqlDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        result = int.Parse(dataReader["IdCharacter"].ToString());
                        //test.Text = result;
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }

            connection.Close();
            return result;
        }
        #endregion

        #region Events
        /// <summary>
        /// Manage all the event of the page
        /// </summary>
        private void Events()
        {
            this.page.XAMLMenuUserControl.home.Click += Home_Click;
            this.page.XAMLMenuUserControl.fight.Click += Fight_Click;
            this.page.XAMLMenuUserControl.logout.Click += Logout_Click;
            this.page.XAMLMenuUserControl.quest.Click += Quest_Click;
            this.page.XAMLMenuUserControl.shop.Click += Shop_Click;
            this.page.XAMLInventaireUC.MouseDoubleClick += XAMLInventaireUC_MouseDoubleClick;
        }

        private void SaveInBdd()
        {
            Database<Items> DbItems = new Database<Items>();
            if (DbItems.Get(1).Result is null)
            {
                DbItems.Insert(InventaireUserControl.listItems);
            }
            Database<Categories> DbCat = new Database<Categories>();
            if  (DbCat.Get(1).Result is null)
            {
                DbCat.Insert(InventaireUserControl.listCategories);
            }
        }

        private void XAMLInventaireUC_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            msg = "ça marche";
            this.page.ceinture.Content = msg;
            ////throw new NotImplementedException();
            //// quand on double clique sur un élément, ça le met à l'endroit prévu à cet effet
        }

        /// <summary>
        /// Logout redirection function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new FirstConnexion();
        }
        /// <summary>
        /// Quest redirection funtion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Quest_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Quest();
        }

        /// <summary>
        /// Shop redirection function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Shop_Click(object sender, RoutedEventArgs e)
        {
            Loger loger;
            int level = 0;
            if (level > 1)
            {
                Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Shop();
            }
            else
            {
                loger = new Loger(new List<Alert> { Alert.MESSAGE_BOX }, new List<Mode> { Mode.NONE });
                loger.Log("Vous devez être niveau 2");
            }
        }

        /// <summary>
        /// Fight redirection function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Fight_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Views.Fight();
        }

        /// <summary>
        /// Home redirection function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Home_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Home();
        }
        #endregion
    }
}
