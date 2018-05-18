using LoggerUtil;
using nanofromage.Views;
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
        private int questEnd = 0;
        public QuestViewModel(Views.Quest page)
        {
            this.page = page;
            CallWebService();
            Events();
        }

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

        private void SetUpView<T>(T item)
        {
            String output = JsonConvert.SerializeObject(item);
            Console.WriteLine("output = "+output);
            
            JObject jObject = JsonConvert.DeserializeObject(output) as JObject;
            //Console.WriteLine(jObject);
            Console.WriteLine("time =" +jObject["time"]);
            questEnd = Convert.ToInt32(jObject["time"]);
            this.page.lblName.Content = Convert.ToString(jObject["name"]);
            this.page.lblXp.Content = "XP :" + Convert.ToInt32(jObject["xp"]);
            this.page.lblLoot.Content = "Loot :  " + Convert.ToInt32(jObject["loot"]);
            //this.page.MainGrid.Children.Add(BuildElement(jObject));
           
        }

        private ScrollViewer BuildElement(JObject jObject)
        {
            ScrollViewer scrollViewer = new ScrollViewer();
            Grid content = new Grid();

            if (jObject.Count > 0)
            {
                /*content.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = GridLength.Auto
                });
                content.ColumnDefinitions.Add(new ColumnDefinition());*/
                int currentRow = 0;
                foreach (var x in jObject)
                {
                    string name = x.Key;
                    JToken value = x.Value;

                    if (value != null)
                    {
                        content.RowDefinitions.Add(new RowDefinition());

                        Label lbl = new Label();
                        lbl.Content = name;
                        Grid.SetRow(lbl, currentRow);
                        Grid.SetColumn(lbl, 3);
                        content.Children.Add(lbl);

                        if (value.Type == JTokenType.Array)
                        {
                            ScrollViewer subScrollViewer = new ScrollViewer();
                            subScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;

                            StackPanel subGrid = new StackPanel();
                            subGrid.Orientation = Orientation.Horizontal;

                            foreach (var item in value)
                            {
                                subGrid.Children.Add(BuildElement(item.Value<JObject>()));
                            }

                            subScrollViewer.Content = subGrid;

                            Grid.SetRow(subScrollViewer, currentRow);
                            Grid.SetColumn(subScrollViewer, 3);
                            content.Children.Add(subScrollViewer);
                        }
                        else if (value.Type == JTokenType.Object)
                        {
                            ScrollViewer subGrid = BuildElement(value.Value<JObject>());
                            Grid.SetRow(subGrid, currentRow);
                            Grid.SetColumn(subGrid, 1);
                            content.Children.Add(subGrid);
                        }
                        else if (value.ToString().EndsWith(".png") || value.ToString().EndsWith(".jpg"))
                        {
                            Image image = new Image();
                            image.MaxHeight = 120;
                            image.MaxWidth = 120;
                            BitmapImage bmi = new BitmapImage(new Uri(value.ToString()));
                            image.Source = bmi;
                            Grid.SetRow(image, currentRow);
                            Grid.SetColumn(image, 1);
                            content.Children.Add(image);
                        }
                        else
                        {
                            TextBox txtBox = new TextBox();
                            Thickness border = new Thickness(0);
                            txtBox.BorderThickness = border;
                            txtBox.TextWrapping = TextWrapping.Wrap;
                            txtBox.IsReadOnly = true;
                            txtBox.Text = value.ToString();
                            Grid.SetRow(txtBox, currentRow);
                            Grid.SetColumn(txtBox, 5);
                            Console.WriteLine(txtBox);
                            content.Children.Add(txtBox);
                        }
                    }

                    currentRow++;
                }
            }

            scrollViewer.Content = content;
            return scrollViewer;
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



        
        private DispatcherTimer timer;
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
        /// CountDown every second
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer_Tick(object sender, EventArgs e)
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
            }
        }



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
            int level = 0;
            if(level > 1)
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
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Fight();
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

        public Views.Quest page { get; private set; }
    }

    
}
