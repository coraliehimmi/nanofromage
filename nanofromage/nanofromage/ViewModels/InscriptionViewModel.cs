using nanofromage.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace nanofromage.ViewModels
{
    public class InscriptionViewModel
    {
        private Inscription page;

        public Inscription Page { get => page; set => page = value; }

        public InscriptionViewModel(Inscription page)
        {
            this.page = page;
            Enregistrement();
        }

        private void Enregistrement()
        {
            this.page.XAMLConfirmUserControl.confirm.Click += Confirm_Click;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if ()
            {

            } else if ()
            {

            } else
            {

            }
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Characters();
        }
    }
}
