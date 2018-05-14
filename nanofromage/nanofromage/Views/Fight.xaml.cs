using nanofromage.ViewModels;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
using WebService;
using System.Timers;
using System.Windows.Threading;

namespace nanofromage.Views
{
    /// <summary>
    /// Logique d'interaction pour Fight.xaml
    /// </summary>
    public partial class Fight : Page, INotifyPropertyChanged
    {
        

        public Fight()
        {
            InitializeComponent();
            CallWebService();
            new FightViewModel(this);
        }

     
            
        private async void CallWebService()
        {

            
            Webservice ws = new Webservice("https://getbridgeapp.co/api/nanofromage");
            //List<User> users = new List<User>();
            //foreach (var usersItem in await ws.HttpClientCaller<List<User>>(User.PATH, users))
            //{

            //}
            //Donjon donjon = new Donjon();
            List<Donjon> donjon = new List<Donjon>();
            donjon = await ws.HttpClientCaller <List<Donjon>>(Donjon.PATH, donjon);
            foreach (var donjonItem in await ws.HttpClientCaller<List<Donjon>>(Donjon.PATH, donjon))
            {
                SetUpView<List<Donjon>>(donjon);
            }

            //user.Posts = await ws.HttpClientCaller<List<Post>>(Post.BY_USER + user.id, user.Posts);

            //user.Comments = await ws.HttpClientCaller<List<Comment>>(Comment.BY_USER + user.id, user.Comments);

            //user.Todos = await ws.HttpClientCaller<List<Todo>>(Todo.BY_USER + user.id, user.Todos);

            //user.Albums = await ws.HttpClientCaller<List<Album>>(Album.BY_USER + user.id, user.Albums);

            /*foreach (var item in user.Albums)
            {
                item.Photos = await ws.HttpClientCaller<List<Photo>>(Photo.BY_ALBUM + item.id, item.Photos);
            }*/

            //SetUpView<Donjon>(donjon);
        }

        private void SetUpView<T>(T item)
        {
            String output = JsonConvert.SerializeObject(item);
            JObject jObject = JsonConvert.DeserializeObject(output) as JObject;
            Console.WriteLine(jObject);
            this.MainGrid.Children.Add(BuildElement(jObject));
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
    }
}
