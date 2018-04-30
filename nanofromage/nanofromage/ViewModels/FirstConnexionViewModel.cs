using nanofromage.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace nanofromage.ViewModels
{
    public class FirstConnexionViewModel
    {
        public FirstConnexionViewModel(FirstConnexion page)
        {
            this.page = page;
            Events();
        }

        private void Events()
        {
            this.page.XAMLConfirmUserControl.confirm.Click += Confirm_Click;
            this.page.XAMLInscriptionUserControl.inscription.Click += Inscription_Click;
        }

        private void Confirm_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Characters();
        }

        private void Inscription_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Inscription();
        }


        public FirstConnexion page { get; private set; }
    }
}
