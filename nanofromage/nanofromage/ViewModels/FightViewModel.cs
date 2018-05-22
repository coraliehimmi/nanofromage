using Database.MySql;
using LoggerUtil;
using MySql.Data.MySqlClient;
using nanofromage.Views;
using NanofromageLibrairy.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using WebService;
using ToastNotifications.Messages;

namespace nanofromage.ViewModels
{
    public class FightViewModel
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        public static int idChar;
        private int idEnnemy;
        private int result;
        private int id;
        public static NanofromageLibrairy.Models.Character currentChar;
        private MySqlConnection connection;
        Character charTest = new Character();
        Enemy ennemy = new Enemy();
        Loger loger;
        Loger notifier;
        #endregion

        #region Attributs
        #endregion

        #region Properties
        public Views.Fight page { get; private set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Main function, call the view and events of this page
        /// </summary>
        /// <param name="page"></param>
        public FightViewModel(Views.Fight page)
        {
            CallWebService();
            this.page = page;
            Init();
            Events();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        /// <summary>
        /// Call the webservice for 1 dungeons
        /// </summary>
        private async void CallWebService()
        {
            Webservice ws = new Webservice("https://bridge.buddyweb.fr/api/nanofromage");
            Donjon donjon = new Donjon();
            
            donjon = await ws.HttpClientCaller<Donjon>(Donjon.BY_DONJON + "1", donjon);
            SetUpView<Donjon>(donjon);
        }

        /// <summary>
        /// Get a list of dungeon
        /// </summary>
        private async void ListDonjons()
        {
            Webservice ws = new Webservice(" https://bridge.buddyweb.fr/api/nanofromage");

            List<Donjon> donjon = new List<Donjon>();
            donjon = await ws.HttpClientCaller<List<Donjon>>(Donjon.PATH + "/", donjon);
            Console.WriteLine(donjon);
            string res = donjon[0].description;
            foreach (var item in donjon)
            {
                SetUpView<Donjon>(item);
            }
        }
        
        /// <summary>
        /// Make the fight view
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        private void SetUpView<T>(T item)
        {
            String output = JsonConvert.SerializeObject(item);
            JObject jObject = JsonConvert.DeserializeObject(output) as JObject;
            Console.WriteLine(jObject);
            this.page.dongonName.Content = Convert.ToString(jObject["name"]);
        }

        /// <summary>
        /// Get the current user id
        /// </summary>
        /// <param name="valeur"></param>
        /// <returns></returns>
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
                cmd.Parameters.AddWithValue(champ, valeur);
                using (MySqlDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        result = int.Parse(dataReader["IdCharacter"].ToString());
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


        /// <summary>
        /// Get the ennemy id
        /// </summary>
        /// <param name="valeur"></param>
        /// <returns></returns>
        private int RecupEnnemy(int valeur)
        {
            try
            {
                String table = "enemies";
                String champ = "Id";
                connection = new MySqlConnection(ModelBase.CONNECTIONSTRING);
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT Id FROM " + table + " WHERE " + champ + " = " + valeur;
                cmd.Parameters.AddWithValue(champ, valeur);
                using (MySqlDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        result = int.Parse(dataReader["Id"].ToString());
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


        /// <summary>
        /// Initialize all information
        /// </summary>
        private void Init()
        {
            int monEnnemy = new Random().Next(1,3);
            Console.WriteLine(monEnnemy);
            Database<Enemy> DbEnemy = new Database<Enemy>();
            Database<Character> DbChar = new Database<Character>();
            idChar = RecupId(FirstConnexionViewModel.currentName);
            idEnnemy = RecupEnnemy(monEnnemy);
            ennemy = DbEnemy.Get(idEnnemy).Result;
            charTest = DbChar.Get(idChar).Result;

            if(monEnnemy == 1)
            {
                this.page.XAMLImageUserControlEnnemy.imgCombat.Source = new BitmapImage(new Uri("/Resources/1.jpg", UriKind.Relative));
            }
            else if(monEnnemy == 2)
            {
                this.page.XAMLImageUserControlEnnemy.imgCombat.Source = new BitmapImage(new Uri("/Resources/4.png", UriKind.Relative));
            }

            if (charTest.Sex == "M")
            {
                this.page.XAMLImageUserControl.imgCombat.Source = new BitmapImage(new Uri("/Resources/persohomme.jpg", UriKind.Relative));
            }
            else if (charTest.Sex == "F")
            {
                this.page.XAMLImageUserControl.imgCombat.Source = new BitmapImage(new Uri("/Resources/persofemme.png", UriKind.Relative));
            }

            this.page.XAMLStatUserControl.myLife.Content = "PV : " + charTest.PtLife;
            this.page.XAMLStatUserControl.myAttaque.Content = "PA : " + charTest.PtAttack;
            this.page.XAMLStatUserControlEnnemy.myLife.Content = "PV : " + ennemy.PtLife;
            this.page.XAMLStatUserControlEnnemy.myAttaque.Content = "PA : " + ennemy.PtAttack;
        }

        /// <summary>
        /// Make an attack
        /// </summary>
        private void Attaque()
        {
            ennemy.PtLife = ennemy.PtLife - charTest.PtAttack;

            if (ennemy.PtLife == 0)
            {
                this.page.XAMLStatUserControlEnnemy.myLife.Content = "PV : " + ennemy.PtLife;
                loger = new Loger(new List<Alert> { Alert.MESSAGE_BOX }, new List<Mode> { Mode.NONE });
                loger.Log("L'ennemi est mort, vous avez gagner "+ ennemy.Xp +" xp et "+ ennemy.Money +" or");
                charTest.Xp = charTest.Xp + ennemy.Xp;
                charTest.Money = charTest.Money + ennemy.Money;
                SaveInfo(charTest.Xp, charTest.Money);
            }
            else
            {
                loger = new Loger(new List<Alert> { Alert.TOAST }, new List<Mode> { Mode.NONE });
                loger.ShowSuccess("Vous infligez " + charTest.PtAttack + " dégats à l'aversaire");
                this.page.XAMLStatUserControlEnnemy.myLife.Content = "PV : " + ennemy.PtLife;
                EnnemyAttaque();
            }
        }

        /// <summary>
        /// Make an attack by the ennemy
        /// </summary>
        private void EnnemyAttaque()
        {
            charTest.PtLife = charTest.PtLife - ennemy.PtAttack;

            if (charTest.PtLife == 0)
            {
                loger = new Loger(new List<Alert> { Alert.TOAST }, new List<Mode> { Mode.NONE });
                loger.OnUnloaded();
                this.page.XAMLStatUserControl.myLife.Content = "PV : " + charTest.PtLife;
                loger = new Loger(new List<Alert> { Alert.MESSAGE_BOX }, new List<Mode> { Mode.NONE });
                loger.Log("Vous avez perdus!");
                Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Home();

            }
            else
            {
                loger = new Loger(new List<Alert> { Alert.TOAST }, new List<Mode> { Mode.NONE });
                loger.ShowError("Vous avez perdus " + ennemy.PtAttack + " PV");
                this.page.XAMLStatUserControl.myLife.Content = "PV : " + charTest.PtLife;
            }
        }

        /// <summary>
        /// Update request basic informations
        /// </summary>
        /// <param name="myWhereClause"></param>
        /// <param name="myTable"></param>
        private void SetParameters(String myWhereClause, String myTable)
        {
            String champ = myWhereClause;
            String table = myTable;
        }

        /// <summary>
        /// Update characters data according to the reward
        /// </summary>
        /// <param name="xp"></param>
        /// <param name="money"></param>
        public void SaveInfo(int xp, int money)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(ModelBase.CONNECTIONSTRING);
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE characters SET Money = @Money, Xp = @Xp WHERE Id = @Id";
                SetParameters("Name", "characters");
                cmd.Parameters.AddWithValue("Money", money);
                cmd.Parameters.AddWithValue("Xp", xp);
                cmd.Parameters.AddWithValue("Id", result);
                cmd.ExecuteNonQuery();
                Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Home();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            this.page.attaque.Click += Attaque_Click;
        }

        /// <summary>
        /// Action put in the attack button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Attaque_Click(object sender, RoutedEventArgs e)
        {
            if(charTest.PtLife != 0 && ennemy.PtLife != 0)
            {
                Attaque();
            }
            else
            {
                loger = new Loger(new List<Alert> { Alert.MESSAGE_BOX }, new List<Mode> { Mode.NONE });
                loger.Log("Vous devez quitter la page ou la recharger pour retenter votre chance");
            }
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
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Views.Quest();
        }

        /// <summary>
        /// Shop redirection function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Shop_Click(object sender, RoutedEventArgs e)
        {
            
            if (charTest.Level == 1)
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
