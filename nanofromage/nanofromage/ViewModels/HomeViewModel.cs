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
        private Equipment currentEquipment = new Equipment();
        private List<String> currentStringItems = new List<String>();
        private List<String> currentStringUsables = new List<String>();
        private List<Items> currentItems = new List<Items>();
        private String item1;
        private String item2;
        private String item3;
        private String item4;
        private String item5;
        private String item6;
        private String item7;
        private String item8;
        private String potion1;
        private String potion2;
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
                this.page.XAMLInventaireUC.myperso.Source = new BitmapImage(new Uri("/Resources/persohomme.jpg", UriKind.Relative));
            }
           else if (charTest.Sex == "F")
            {
                this.page.XAMLInfosPersoUC.imgsex.Source = new BitmapImage(new Uri("/Resources/femelle.png", UriKind.Relative));
                this.page.XAMLInventaireUC.myperso.Source = new BitmapImage(new Uri("/Resources/persofemme.png", UriKind.Relative));
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
            this.page.XAMLInventaireUC.listArmesUC.MouseDoubleClick += ListArmesUC_MouseDoubleClick;
            this.page.XAMLInventaireUC.listarmuresUC.MouseDoubleClick += ListarmuresUC_MouseDoubleClick;
            this.page.XAMLInventaireUC.listChapeauxUC.MouseDoubleClick += ListChapeauxUC_MouseDoubleClick;
            this.page.XAMLInventaireUC.listChaussuresUC.MouseDoubleClick += ListChaussuresUC_MouseDoubleClick;
            this.page.XAMLInventaireUC.listGantsUC.MouseDoubleClick += ListGantsUC_MouseDoubleClick;
            this.page.XAMLInventaireUC.listLunettesUC.MouseDoubleClick += ListLunettesUC_MouseDoubleClick;
            this.page.XAMLInventaireUC.listPantalonUC.MouseDoubleClick += ListPantalonUC_MouseDoubleClick;
            this.page.XAMLInventaireUC.listTuniquesUC.MouseDoubleClick += ListTuniquesUC_MouseDoubleClick;
            this.page.XAMLInventaireUC.listPotionUC.MouseDoubleClick += ListPotionUC_MouseDoubleClick;
            this.page.XAMLUsableUC.usable1.MouseDoubleClick += Usable1_MouseDoubleClick;
            this.page.XAMLUsableUC.usable2.MouseDoubleClick += Usable2_MouseDoubleClick;
            this.page.XAMLUsableUC.usable3.MouseDoubleClick += Usable3_MouseDoubleClick;
        }

        private void Usable3_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.page.XAMLUsableUC.usable3.Content = "3ème item";
        }

        private void Usable2_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.page.XAMLUsableUC.usable2.Content = "2ème item";
            currentStringUsables.Remove(potion2);
        }

        private void Usable1_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.page.XAMLUsableUC.usable1.Content = "1er item";
            currentStringUsables.Remove(potion1);
        }

        private void ListPotionUC_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            switch (this.page.XAMLInventaireUC.listPotionUC.SelectedValue)
            {
                case "Potion de vie":
                    this.page.XAMLUsableUC.usable1.Content = this.page.XAMLInventaireUC.listPotionUC.SelectedValue;
                    this.page.XAMLUsableUC.imgPotion1.Source = new BitmapImage(new Uri("/Resources/potion1.png", UriKind.Relative));
                    potion1 = this.page.XAMLInventaireUC.listPotionUC.SelectedValue.ToString();
                    break;
                case "Potion de mana":
                    this.page.XAMLUsableUC.usable2.Content = this.page.XAMLInventaireUC.listPotionUC.SelectedValue;
                    this.page.XAMLUsableUC.imgPotion2.Source = new BitmapImage(new Uri("/Resources/potion2.png", UriKind.Relative));
                    potion2 = this.page.XAMLInventaireUC.listPotionUC.SelectedValue.ToString();
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Dans l'évènement des choses pourraient être changées, on récupère seulement une chaine de caratères
        /// alors que si on récupérais directement l'item, cala faciliterait les choses
        /// AMELIORATION à prévoir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ListTuniquesUC_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.page.XAMLInventaireUC.buttonTunique.Content = this.page.XAMLInventaireUC.listTuniquesUC.SelectedValue;
            item1 = this.page.XAMLInventaireUC.listTuniquesUC.SelectedValue.ToString();
        }

        private void ListPantalonUC_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.page.XAMLInventaireUC.buttonPantalon.Content = this.page.XAMLInventaireUC.listPantalonUC.SelectedValue;
            item2 = this.page.XAMLInventaireUC.listPantalonUC.SelectedValue.ToString();
        }

        private void ListLunettesUC_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.page.XAMLInventaireUC.buttonLunettes.Content = this.page.XAMLInventaireUC.listLunettesUC.SelectedValue;
            item3 = this.page.XAMLInventaireUC.listLunettesUC.SelectedValue.ToString();
        }

        private void ListGantsUC_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.page.XAMLInventaireUC.buttonGant.Content = this.page.XAMLInventaireUC.listGantsUC.SelectedValue;
            item4 = this.page.XAMLInventaireUC.listGantsUC.SelectedValue.ToString();
        }

        private void ListChaussuresUC_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.page.XAMLInventaireUC.buttonChaussures.Content = this.page.XAMLInventaireUC.listChaussuresUC.SelectedValue;
            item5 = this.page.XAMLInventaireUC.listChaussuresUC.SelectedValue.ToString();
        }

        private void ListChapeauxUC_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.page.XAMLInventaireUC.buttonChapeau.Content = this.page.XAMLInventaireUC.listChapeauxUC.SelectedValue;
            item6 = this.page.XAMLInventaireUC.listChapeauxUC.SelectedValue.ToString();
        }

        private void ListarmuresUC_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.page.XAMLInventaireUC.buttonArmure.Content = this.page.XAMLInventaireUC.listarmuresUC.SelectedValue;
            item7 = this.page.XAMLInventaireUC.listarmuresUC.SelectedValue.ToString();
        }

        private void ListArmesUC_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.page.XAMLInventaireUC.buttonArme.Content = this.page.XAMLInventaireUC.listArmesUC.SelectedValue;
            item8 = this.page.XAMLInventaireUC.listArmesUC.SelectedValue.ToString();
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
            currentStringItems.Add(item1);
            currentStringItems.Add(item2);
            currentStringItems.Add(item3);
            currentStringItems.Add(item4);
            currentStringItems.Add(item5);
            currentStringItems.Add(item6);
            currentStringItems.Add(item7);
            currentStringItems.Add(item8);

            currentStringUsables.Add(potion1);
            currentStringUsables.Add(potion2);

            if (currentStringItems.Count != 8)
            {
                MessageBox.Show("Vous devez choisir tous vos équipements !");
            }
            else if (currentStringUsables.Count < 1)
            {
                MessageBox.Show("Vous devez prendre au moins une potion !");
            }
            else
            {
                Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Views.Fight();
            }
            //// Revoir le passage à Home
           
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
