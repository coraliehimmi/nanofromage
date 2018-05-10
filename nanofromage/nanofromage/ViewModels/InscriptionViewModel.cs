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
        /// <summary>
        /// Logique d'interaction pour InscriptionViewModel.xaml
        /// </summary>
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        private String name;
        private String msg;
        #endregion

        #region Attributs

        #endregion

        #region Properties
        public Inscription page { get; private set; }
        public string Name { get => name; set => name = value; }
        #endregion

        #region Constructors
        public InscriptionViewModel(Inscription page)
        {
            this.page = page;
            Enregistrement();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        private void Enregistrement()
        {
            this.page.XAMLConfirmUserControl.confirm.Click += Confirm_Click;
        }

        /*private String SelectName(String CurrentName)
        {
            if (CurrentName == name)
            {
                Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Inscription();
                msg = "Ce nom d'utilisateur est déjà utilisé, merci d'en saisir un nouveau";

            }
            else
            return name;
        }*/
        #endregion

        #region Events
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            /*if ()
            {

            } else if ()
            {

            } else
            {

            }*/
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Characters();
        }
        #endregion
        

        

        

        
    }
}
