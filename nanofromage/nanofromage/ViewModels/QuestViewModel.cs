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
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using WebService;

namespace nanofromage.ViewModels
{
    public class QuestViewModel
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        private int questEnd;
        #endregion

        #region Attributs
        private DispatcherTimer timer;
        private int result;
        private int exp;
        private int monney;
        private int idChar;
        Character charTest = new Character();
        Database<Character> DbChar = new Database<Character>();
        #endregion

        #region Properties
        public Views.Quest page { get; private set; }
        public MySqlConnection connection { get; private set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="page"></param>
        public QuestViewModel(Views.Quest page)
        {
            this.page = page;
            CallWebService();
            Events();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        /// <summary>
        /// Call the webservice
        /// </summary>
        private async void CallWebService()
        {
            Webservice ws = new Webservice(" https://bridge.buddyweb.fr/api/nanofromage");
            //List<User> users = new List<User>();
            //foreach (var usersItem in await ws.HttpClientCaller<List<User>>(User.PATH, users))
            //{

            //}
            WebService.Quest quest = new WebService.Quest();
            quest = await ws.HttpClientCaller<WebService.Quest>(WebService.Quest.BY_QUEST + "1", quest);

            SetUpView<WebService.Quest>(quest);
        }

        /// <summary>
        /// Make the quest view
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        private void SetUpView<T>(T item)
        {
            String output = JsonConvert.SerializeObject(item);
            Console.WriteLine("output = " + output);

            JObject jObject = JsonConvert.DeserializeObject(output) as JObject;
            //Console.WriteLine(jObject);
            Console.WriteLine("time =" + jObject["time"]);
            questEnd = Convert.ToInt32(jObject["time"]);
            exp = Convert.ToInt32(jObject["xp"]);
            monney = Convert.ToInt32(jObject["loot"]);
            this.page.lblName.Content = Convert.ToString(jObject["name"]);
            this.page.lblXp.Content = "XP : " + exp;
            this.page.lblLoot.Content = "Loot :  " + monney;
            //this.page.MainGrid.Children.Add(BuildElement(jObject));
            
        }

        /// <summary>
        /// Initialize the timer for the countdown
        /// </summary>
        public void DispatcherTimerSample()
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            DateTime endTime = DateTime.Now.AddHours(6);
            timer.Tick += timer_Tick;
            timer.Start();

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
            DispatcherTimerSample();
        }

        /// <summary>
        /// CountDown every second
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void timer_Tick(object sender, EventArgs e)
        {
            if (questEnd != 0)
            {
                this.page.lblTime.Content = string.Format("{0}:{1}:{2}", questEnd / 3600, (questEnd / 60) % 60, questEnd % 60);
                questEnd--;
            }
            else
            {
                timer.Stop();
                MessageBox.Show("La quete est finie");
                idChar = RecupId(FirstConnexionViewModel.currentName);
                charTest = DbChar.Get(idChar).Result;
                exp = charTest.Xp + exp;
                monney = charTest.Money + monney;
                SaveInfo(exp, monney);
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
            Loger loger;
            if (charTest.Level > 1)
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
