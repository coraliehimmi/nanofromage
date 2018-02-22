using nanofromage.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Home();
        }

        public Characters page { get; private set; }
    }
}
