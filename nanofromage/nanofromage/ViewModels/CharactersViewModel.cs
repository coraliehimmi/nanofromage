using nanofromage.Views;
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
    public class CharactersViewModel
    {
        public CharactersViewModel(Characters page)
        {
            this.page = page;
            Events();
        }

        private void Events()
        {
            this.page.XAMLConfirmUserControl.confirm.Click += Confirm_Click;
            //this.page.XAMLCharacterUserControl.character.Source = new BitmapImage(new Uri("pack://aplication:,,,/Image/1.jpg"));
            //this.page.XAMLNameUserControl.male.Checked += Male_Checked;

            //this.page.XAMLCharacterUserControl.female.Che
            /*BitmapImage b = new BitmapImage();
            b.BeginInit();
            b.UriSource = new Uri("pack://aplication:,,,/Image/1.jpg");
            b.EndInit();*/
        }

        //public BitmapImage GetMyImage => new BitmapImage(new Uri("/Image/1.png" + UriKind.Absolute));
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        //private void Male_Checked(object sender, RoutedEventArgs e)
        //{
            
            //this.page.XAMLCharacterUserControl.character.Source = new BitmapImage(new Uri("pack://aplication:,,,/Image/1.jpg"));
        //}

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Home();
        }

        public Characters page { get; private set; }
    }
}
