using Database.MySql;
using LoggerUtil;
using MySql.Data.MySqlClient;
using nanofromage.UserControls;
using nanofromage.Views;
using NanofromageLibrairy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace nanofromage.ViewModels
{
    public class HomeViewModel
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        private int idChar;
        private int result;
        private String table;
        private String champ;
        private int id;
        private MySqlConnection connection;
        private String msg;
        private Equipment currentEquipment;
        private Usable currentUsable;
        private List<String> currentStringItems;
        private List<String> currentStringUsables;
        private List<Items> currentItems = new List<Items>();
        private String item1;
        private String item2;
        private String item3;
        private String item4;
        private String item5;
        private String item6;
        private String item7;
        private String item8;
        private String potion1;
        private String potion2;
        private Items currentItem;
        //public static NanofromageLibrairy.Models.Character currentCharacter;
        Character currentCharacter = new Character();
        //private Character currentCharacter;
        #endregion

        #region Attributs
        private Home page;
        #endregion

        #region Properties
        public Home Page { get; private set; }
        #endregion

        #region Constructors
        public HomeViewModel(Home page)
        {
            this.page = page;
            Init();
            Events();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        /// <summary>
        /// Dans la fonction d'Init on récupère d'abord les informations de l'utilisateur qui s'est loggé et on instancie un
        /// nouveau character courant.
        /// Suivant s'il est un Homme ou Femme, différentes choses changent (logo, image perso et couleur du login)
        /// Enfin, les inforamtions sur le niveau du joueur et ses stat s'affichent.
        /// Et enfin, on initialise les items avec des " "
        /// </summary>
        private void Init()
        {
            table = "users";
            champ = "Login";
            //currentCharacter = new Character();
            Database<Character> DbChar = new Database<Character>();
            idChar = RecupId(FirstConnexionViewModel.currentName, table, champ);
            currentCharacter = DbChar.Get(idChar).Result;

            if (currentCharacter.Sex == "M")
            {
                this.page.XAMLInfosPersoUC.imgsex.Source = new BitmapImage(new Uri("/Resources/male.png", UriKind.Relative));
                this.page.XAMLInventaireUC.myperso.Source = new BitmapImage(new Uri("/Resources/persohomme.jpg", UriKind.Relative));
                this.page.XAMLInfosPersoUC.nameCharacter.Foreground = new SolidColorBrush(Color.FromRgb(66, 149, 247));
            }
            else if (currentCharacter.Sex == "F")
            {
                this.page.XAMLInfosPersoUC.imgsex.Source = new BitmapImage(new Uri("/Resources/femelle.png", UriKind.Relative));
                this.page.XAMLInventaireUC.myperso.Source = new BitmapImage(new Uri("/Resources/persofemme.png", UriKind.Relative));
                this.page.XAMLInfosPersoUC.nameCharacter.Foreground = new SolidColorBrush(Color.FromRgb(247, 66, 222));
            }
            this.page.XAMLInfosPersoUC.CurrentCharacter = currentCharacter;
            this.page.XAMLInfoLevelUC.CurrentCharacter = currentCharacter;
            ///Récupération des informations du joueur actif

            item1 = " ";
            item2 = " ";
            item3 = " ";
            item4 = " ";
            item5 = " ";
            item6 = " ";
            item7 = " ";
            item8 = " ";
            potion1 = " ";
            potion2 = " ";
    }

        /// <summary>
        /// Fonction qui récupère l'Id de n'importe quelle table et pour n'importe quel champ, ils entrent en paramètre
        /// de la fonction avec la valeur qu'on recherche.
        /// </summary>
        private int RecupId(String valeur, String table, String champ)
        {
            try
            {
                connection = new MySqlConnection(ModelBase.CONNECTIONSTRING);
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT Id FROM " + table +" WHERE " + champ + " = @" + champ;
                cmd.Parameters.AddWithValue(champ, valeur);
                using (MySqlDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        result = int.Parse(dataReader["Id"].ToString());
                    }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            connection.Close();
            return result;
        }
        #endregion

        #region Events
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
            this.page.XAMLInventaireUC.listArmesUC.MouseDoubleClick += ListArmesUC_MouseDoubleClick;
            this.page.XAMLInventaireUC.listarmuresUC.MouseDoubleClick += ListarmuresUC_MouseDoubleClick;
            this.page.XAMLInventaireUC.listChapeauxUC.MouseDoubleClick += ListChapeauxUC_MouseDoubleClick;
            this.page.XAMLInventaireUC.listChaussuresUC.MouseDoubleClick += ListChaussuresUC_MouseDoubleClick;
            this.page.XAMLInventaireUC.listGantsUC.MouseDoubleClick += ListGantsUC_MouseDoubleClick;
            this.page.XAMLInventaireUC.listLunettesUC.MouseDoubleClick += ListLunettesUC_MouseDoubleClick;
            this.page.XAMLInventaireUC.listPantalonUC.MouseDoubleClick += ListPantalonUC_MouseDoubleClick;
            this.page.XAMLInventaireUC.listTuniquesUC.MouseDoubleClick += ListTuniquesUC_MouseDoubleClick;
            this.page.XAMLInventaireUC.listPotionUC.MouseDoubleClick += ListPotionUC_MouseDoubleClick;
            this.page.XAMLUsableUC.usable1.MouseDoubleClick += Usable1_MouseDoubleClick;
            this.page.XAMLUsableUC.usable2.MouseDoubleClick += Usable2_MouseDoubleClick;
            this.page.XAMLUsableUC.usable3.MouseDoubleClick += Usable3_MouseDoubleClick;
            msg = "Attention, merci de bien choisir un objet qui fait partie de la sélection.";
        }

        private void Usable3_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.page.XAMLUsableUC.usable3.Content = "3ème item";
            /// Valeur du bouton des items
        }

        private void Usable2_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.page.XAMLUsableUC.usable2.Content = "2ème item";
            this.page.XAMLUsableUC.imgPotion2.Source = null;
           potion2 = " ";
            /// Quand on double clique sur un bouton on supprime de la liste l'item précédemment ajouté
        }

        private void Usable1_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.page.XAMLUsableUC.usable1.Content = "1er item";
            this.page.XAMLUsableUC.imgPotion1.Source = null;
           potion1 = " ";
        }

        /// <summary>
        /// Pour chaque clic sur une liste d'items on a des actions différentes
        /// Pour les potions, on alimente la ceinture du joueur
        /// Pour les autres, on alimente l'équipement du personnage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListPotionUC_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            switch (this.page.XAMLInventaireUC.listPotionUC.SelectedValue)
            {
                case "Potion de vie":
                    this.page.XAMLUsableUC.usable1.Content = this.page.XAMLInventaireUC.listPotionUC.SelectedValue;
                    this.page.XAMLUsableUC.imgPotion1.Source = new BitmapImage(new Uri("/Resources/potion1.png", UriKind.Relative));
                    potion1 = this.page.XAMLInventaireUC.listPotionUC.SelectedValue.ToString();
                    break;
                case "Potion de mana":
                    this.page.XAMLUsableUC.usable2.Content = this.page.XAMLInventaireUC.listPotionUC.SelectedValue;
                    this.page.XAMLUsableUC.imgPotion2.Source = new BitmapImage(new Uri("/Resources/potion2.png", UriKind.Relative));
                    potion2 = this.page.XAMLInventaireUC.listPotionUC.SelectedValue.ToString();
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Dans l'évènement des choses pourraient être changées, on récupère seulement une chaine de caratères
        /// alors que si on récupérais directement l'item, cala faciliterait les choses
        /// AMELIORATION à prévoir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ListTuniquesUC_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                this.page.XAMLInventaireUC.buttonTunique.Content = this.page.XAMLInventaireUC.listTuniquesUC.SelectedValue;
                this.page.XAMLInventaireUC.buttonTunique.Foreground = new SolidColorBrush(Color.FromRgb(243, 0, 55));
                item1 = this.page.XAMLInventaireUC.listTuniquesUC.SelectedValue.ToString();
                /// Quand on sélectionne un objet de la liste on met à jour le bouton des noms des catégories des
                /// items englobant le personnage du joueur avec le nom de l'objet choisi
                /// On change la couleur pour plus de visibilité et on met à jour un nouvel item pour pouvoir l'ajouter
                /// ensuite dans une liste de noms d'items
            }
            catch (Exception except)
            {
                MessageBox.Show(msg);
                /// Le message survient quand on clic en dehors de la liste
            }
        }

        private void ListPantalonUC_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                this.page.XAMLInventaireUC.buttonPantalon.Content = this.page.XAMLInventaireUC.listPantalonUC.SelectedValue;
                this.page.XAMLInventaireUC.buttonPantalon.Foreground = new SolidColorBrush(Color.FromRgb(243, 0, 55));
                item2 = this.page.XAMLInventaireUC.listPantalonUC.SelectedValue.ToString();
            }
            catch (Exception except)
            {
                MessageBox.Show(msg);
            }
        }

        private void ListLunettesUC_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                this.page.XAMLInventaireUC.buttonLunettes.Content = this.page.XAMLInventaireUC.listLunettesUC.SelectedValue;
                this.page.XAMLInventaireUC.buttonLunettes.Foreground = new SolidColorBrush(Color.FromRgb(243, 0, 55));
                item3 = this.page.XAMLInventaireUC.listLunettesUC.SelectedValue.ToString();
            }
            catch (Exception except)
            {
                MessageBox.Show(msg);
            }
            
        }

        private void ListGantsUC_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                this.page.XAMLInventaireUC.buttonGant.Content = this.page.XAMLInventaireUC.listGantsUC.SelectedValue;
                this.page.XAMLInventaireUC.buttonGant.Foreground = new SolidColorBrush(Color.FromRgb(243, 0, 55));
                item4 = this.page.XAMLInventaireUC.listGantsUC.SelectedValue.ToString();
            }
            catch (Exception except)
            {
                MessageBox.Show(msg);
            }
        }

        private void ListChaussuresUC_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                this.page.XAMLInventaireUC.buttonChaussures.Content = this.page.XAMLInventaireUC.listChaussuresUC.SelectedValue;
                this.page.XAMLInventaireUC.buttonChaussures.Foreground = new SolidColorBrush(Color.FromRgb(243, 0, 55));
                item5 = this.page.XAMLInventaireUC.listChaussuresUC.SelectedValue.ToString();
            }
            catch (Exception except)
            {
                MessageBox.Show(msg);
            }
        }

        private void ListChapeauxUC_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                this.page.XAMLInventaireUC.buttonChapeau.Content = this.page.XAMLInventaireUC.listChapeauxUC.SelectedValue;
                this.page.XAMLInventaireUC.buttonChapeau.Foreground = new SolidColorBrush(Color.FromRgb(243, 0, 55));
                item6 = this.page.XAMLInventaireUC.listChapeauxUC.SelectedValue.ToString();
            }
            catch (Exception except)
            {
                MessageBox.Show(msg);
            }
        }

        private void ListarmuresUC_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                this.page.XAMLInventaireUC.buttonArmure.Content = this.page.XAMLInventaireUC.listarmuresUC.SelectedValue;
                this.page.XAMLInventaireUC.buttonArmure.Foreground = new SolidColorBrush(Color.FromRgb(243, 0, 55));
                item7 = this.page.XAMLInventaireUC.listarmuresUC.SelectedValue.ToString();
            }
            catch (Exception except)
            {
                MessageBox.Show(msg);
            }
        }

        private void ListArmesUC_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                this.page.XAMLInventaireUC.buttonArme.Content = this.page.XAMLInventaireUC.listArmesUC.SelectedValue;
                this.page.XAMLInventaireUC.buttonArme.Foreground = new SolidColorBrush(Color.FromRgb(243, 0, 55));
                item8 = this.page.XAMLInventaireUC.listArmesUC.SelectedValue.ToString();
            }
            catch (Exception except)
            {
                MessageBox.Show(msg);
            }
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
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Quest();
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
            if (level > 1)
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
        /// Pour chaque Item choisi on récupère son ID en BDD puis en fonctuion de l'id on récupère l'objet
        /// associé à l'item en question pour ensuite l'ajouter à une liste d'items et créer l'équipement, puis
        /// la ceinture du joueur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Fight_Click(object sender, RoutedEventArgs e)
        {
            currentStringItems = new List<String>();
            currentStringItems.Add(item1);
            currentStringItems.Add(item2);
            currentStringItems.Add(item3);
            currentStringItems.Add(item4);
            currentStringItems.Add(item5);
            currentStringItems.Add(item6);
            currentStringItems.Add(item7);
            currentStringItems.Add(item8);

            currentStringUsables = new List<String>();
            currentStringUsables.Add(potion1);
            currentStringUsables.Add(potion2);

            int countItems = 0;
            foreach (var item in currentStringItems)
            {
                if (item == " ")
                {
                    countItems++;
                }
            }
            /// On compte le nombre d'items vides de la liste
            int countUsables = 0;
            foreach (var item in currentStringUsables)
            {
                if (item != " ")
                {
                    countUsables++;
                }
            }
            /// On compte le nombre d'items vides de la liste
            if (countItems > 0)
            {
                MessageBox.Show("Vous devez choisir tous vos équipements !");
                /// Si on a des items vides on ne peut pas continuer, obligation de choisir un equipement entier
            }
            else if (countUsables == 0)
            {
                MessageBox.Show("Vous devez prendre au moins une potion !");
                /// Obligation de choisir au moins une potion
            }
            else
            {
                table = "items";
                champ = "Name";
                foreach (var item in currentStringItems)
                {
                    Database<Items> DbItems = new Database<Items>();
                    currentItem = new Items();
                    currentItem = DbItems.Get(RecupId(item, table, champ)).Result;
                    currentItems.Add(currentItem);
                    /// on récupère l'id correspondant à l'item en bdd
                    /// suivant l'id, on récupère l'objet et on ajoute l'objet obtenu
                    /// à une liste courante d'objets
                }
                String name = currentCharacter.Name + "equipment";
                currentEquipment = new Equipment(name, currentItems);
                try
                {
                    Database<Equipment> DbEquipment = new Database<Equipment>();
                    DbEquipment.Insert(currentEquipment);
                    /// On insère les équipements en BDD et on fera pareil pour la ceinture
                }
                catch (MySqlException err)
                {
                    MessageBox.Show(err.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                foreach (var item in currentStringUsables)
                {
                    Database<Items> DbItems = new Database<Items>();
                    currentItem = new Items();
                    currentItem = DbItems.Get(RecupId(item, table, champ)).Result;
                    currentItems.Add(currentItem);
                }
                currentUsable = new Usable(currentItems, currentCharacter);
                try
                {
                    Database<Usable> DbUsable = new Database<Usable>();
                    DbUsable.Insert(currentUsable);
                }
                catch (MySqlException err)
                {
                    MessageBox.Show(err.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Views.Fight();
            }
        }
        /// <summary>
        /// Home redirection function
        /// Besoin de faire un message box qui précise que si on sort de la page Home on perd les infos saisies
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Home_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Content = new Home();
        }
        #endregion
    }
}
