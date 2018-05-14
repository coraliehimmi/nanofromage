using Database.MySql;
using MySql.Data.MySqlClient;
using nanofromage.UserControls;
using nanofromage.Views;
using NanofromageLibrairy.Models;
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
        private String msg;
        private String selectName;
        private String currentName;
        private String currentPassword;
        #endregion

        #region Attributs
        public Inscription page { get; private set; }
        #endregion

        #region Properties

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
        #endregion

        #region Events
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            int nb = 6;
            LoginUserControl.currentName = LoginUserControl.currentUser.Login; /// Ici la valeur du CurrentName prend la valeur de la saisie de l'utilisateur
            this.currentName = LoginUserControl.currentName; /// pour une visibilité plus claire, je mets cette variable dans une autre varaible pour la réutiliser
            selectName = LoginUserControl.SelectName(this.currentName); /// je recherche si le nom existe en BDD
            if ((this.currentName is null) || (currentName.Length <= nb))
            {
                msg = "Votre Login doit contenir au moins " + nb + " caractères.";
                MessageBox.Show(msg);
                Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Inscription();
            }
            else if (selectName != this.currentName)
            {
                this.currentPassword = LoginUserControl.currentUser.Password;
                if (this.currentPassword.Length <= nb)
                {
                    msg = "Votre mot de passe doit contenir plus de " + nb + " caractères.";
                    MessageBox.Show(msg);
                    Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Inscription();
                }
                else
                {
                    LoginUserControl.SaveNewUser(this.currentName, this.currentPassword);
                    Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Characters();
                }
            }
            /// Si le nom d'utilisateur n'exite pas, je récupère la valeur du password, je sauvegarde et j'arrive sur la page des Characters.
            else
            {
                msg = "Ce nom d'utilisateur est déjà utilisé, merci d'en saisir un nouveau";
                MessageBox.Show(msg);
                Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Inscription();
            }
            /// Si l'utilisateur existe, message d'erreur, et je réinitialise ma page.
        }


        #endregion
    }
}
       
