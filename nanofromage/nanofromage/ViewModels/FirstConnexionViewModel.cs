using Database.MySql;
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
    public class FirstConnexionViewModel
    {
        Clan mage = new Clan("Mage", "A force d'étudier sans cesse, il parvient à maîtriser la magie et acquiert d'incroyables pouvoirs.", 10, 50, 30);
        Clan warrior = new Clan("Warrior", "Maître en matière d’armes et d’armures de toutes sortes, il est à la fois courageux et vaillant.", 30, 20, 10);
        Clan hunter = new Clan("Hunter", "il peut combattre aussi bien de près que de loin. C’est un tireur hors pair possédant de grandes capacités dans ce domaines. Il peut lancer plusieurs flèches en même temps et peut appeler des animaux en combat", 50, 10, 40);

        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        #endregion

        #region Attributs
        public FirstConnexion page { get; private set; }
        #endregion

        #region Properties
        #endregion

        #region Constructors
        public FirstConnexionViewModel(FirstConnexion page)
        {
            this.page = page;
            Events();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        #endregion

        #region Events
        private void Events()
        {
            this.page.XAMLConfirmUserControl.confirm.Click += Confirm_Click;
            this.page.XAMLInscriptionUserControl.inscription.Click += Inscription_Click;
        }

        private void Confirm_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Database<Clan> DbClan = new Database<Clan>();
            DbClan.Insert(mage);
            DbClan.Insert(hunter);
            DbClan.Insert(warrior);
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Characters();
        }

        private void Inscription_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Inscription();
        }
        #endregion
    }
}
