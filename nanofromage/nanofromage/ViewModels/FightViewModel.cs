using nanofromage.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace nanofromage.ViewModels
{
    public class FightViewModel
    {
        public FightViewModel(Fight page)
        {
            this.page = page;
            Events();
        }
<<<<<<< HEAD

=======
>>>>>>> 3b155eed77202a6f75b7d0c744af05a64f564032
        private void Events()
        {
            this.page.XAMLMenuUserControl.home.Click += Home_Click;
            this.page.XAMLMenuUserControl.fight.Click += Fight_Click;
            this.page.XAMLMenuUserControl.logout.Click += Logout_Click;

        }
<<<<<<< HEAD

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new FirstConnexion();
        }

        private void Fight_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Fight();
        }

        private void Home_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Home();
=======
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new FirstConnexion();
>>>>>>> 3b155eed77202a6f75b7d0c744af05a64f564032
        }

        private void Fight_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Fight();
        }

        private void Home_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Home();
        }
        public Fight page { get; private set; }
    }
}
