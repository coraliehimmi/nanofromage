using Database.MySql;
using NanofromageLibrairy.Models;
using System;
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

namespace nanofromage.UserControls
{
    /// <summary>
    /// Logique d'interaction pour InventaireUserControl.xaml
    /// Création des différentes catégories d'items
    /// Création des listes d'items de chaque catégorie
    /// Création d'une liste de catégories pour la sauvegarde en BDD
    /// </summary>
    public partial class InventaireUserControl : UserControl, INotifyPropertyChanged
    {
        #region StaticVariables
        public static List<Items> listItems;
        public static List<Categories> listCategories;
        #endregion

        #region Constants
        private String CHAPEAUX = "Chapeaux";
        private String GANTS = "Gants";
        private String LUNETTES = "Lunettes";
        private String PANTALON = "Pantalon";
        private String TUNIQUE = "Tunique";
        private String CHAUSSURES = "Chaussures";
        private String ARME = "Arme";
        private String ARMURE = "Armure";
        private String POTION = "Potion";
        #endregion

        #region Variables
        private Items item1;
        private Items item2;
        private Items item3;
        private Items item4;
        private Items item5;
        private Items item6;
        private Items item7;
        private Items item8;
        private Items item9;
        private Items item10;
        private Items item11;
        private Items item12;
        private Categories categorie1;
        private Categories categorie2;
        private Categories categorie3;
        private Categories categorie4;
        private Categories categorie5;
        private Categories categorie6;
        private Categories categorie7;
        private Categories categorie8;
        private Categories categorie9;
        private Database<Categories> DbCat = new Database<Categories>();
        private List<Items> listChapeaux;
        private List<Items> listGants;
        private List<Items> listLunettes;
        private List<Items> listPantalon;
        private List<Items> listTuniques;
        private List<Items> listChaussures;
        private List<Items> listArmes;
        private List<Items> listarmures;
        private List<Items> listPotion;
        ///private ListView myListView;
        #endregion

        #region Attributs
        private List<String> listNameChapeauxUC;
        private List<String> listNameGants;
        private List<String> listNameLunettes;
        private List<String> listNamePantalon;
        private List<String> listNameTuniques;
        private List<String> listNameChaussures;
        private List<String> listNameArmes;
        private List<String> listNameArmures;
        private List<String> listNamePotions;
        #endregion

        #region Properties
        public List<Items> ListChapeaux
        {
            get { return listChapeaux; }
            set
            {
                listChapeaux = value;
                OnPropertyChanged("ListChapeaux");
            }
        }


        public List<String> ListNameChapeauxUC
        {
            get { return listNameChapeauxUC; }
            set
            {
                listNameChapeauxUC = value;
                OnPropertyChanged("ListNameChapeauxUC");
            }
        }
        
        public List<String> ListNameGants
        {
            get { return listNameGants; }
            set
            {
                listNameGants = value;
                OnPropertyChanged("listNameGants");
            }
        }

        public List<String> ListNameLunettes
        {
            get { return listNameLunettes; }
            set
            {
                listNameLunettes = value;
                OnPropertyChanged("ListNameLunettes");
            }
        }

        public List<String> ListNamePantalon
        {
            get { return listNamePantalon; }
            set
            {
                listNamePantalon = value;
                OnPropertyChanged("ListNamePantalon");
            }
        }
        
        public List<String> ListNameTuniques
        {
            get { return listNameTuniques; }
            set
            {
                listNameTuniques = value;
                OnPropertyChanged("ListNameTuniques");
            }
        }

        public List<String> ListNameChaussures
        {
            get { return listNameChaussures; }
            set {
                listNameChaussures = value;
                OnPropertyChanged("ListNameChaussures");
            }
        }

        public List<String> ListNameArmes
        {
            get { return listNameArmes; }
            set
            {
                listNameArmes = value;
                OnPropertyChanged("ListNameArmes");
            }
        }
        
        public List<String> ListNameArmures
        {
            get { return listNameArmures; }
            set
            {
                listNameArmures = value;
                OnPropertyChanged("ListNameArmures");
            }
        }

        public List<String> ListNamePotions
        {
            get { return listNamePotions; }
            set
            {
                listNamePotions = value;
                OnPropertyChanged("ListNamePotions");
            }
        }
        #endregion

        #region Constructors
        public InventaireUserControl()
        {
            InitializeComponent();
            DataContext = this;
            InitItems();
            InitCatgories();
            SaveInBdd();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        private void InitItems()
        {
            item1 = new Items("Casque en fer", 6, "Casque en fer brut", CHAPEAUX);
            item2 = new Items("Tunique d'entraînement", 2, "Tunique d'aventurier débutant", TUNIQUE);
            item3 = new Items("Botte d'entraînement", 1, "Botte pour aventurier débutant", CHAUSSURES);
            item4 = new Items("Pantalon d'entraînement", 3, "Pantalon pour aventurier débutant", PANTALON);
            item5 = new Items("Potion de vie", 5, "Permet de récupérer 5 PV", POTION);
            item6 = new Items("Potion de mana", 5, " Permet de récupérer 5 PM", POTION);
            item7 = new Items("Gants d'armure", 2, "Permet de ne pas se blesser", GANTS);
            item8 = new Items("Les yeux de Dieu", 15, "Permet de gagner en attaque", LUNETTES);
            item9 = new Items("Les yeux de Lynx", 4, "Avoir une bonne vision", LUNETTES);
            item10 = new Items("Bouclier de héro", 5 , "Te protège des attaques", ARMURE);
            item11 = new Items("Le marteau de Thor", 3, "Te rend invincible", ARME);
            item12 = new Items("Les escarpins magiques", 8 , "Ecrase tes adversaires avec", CHAUSSURES);

            listItems = new List<Items>();
            listItems.Add(item1);
            listItems.Add(item2);
            listItems.Add(item3);
            listItems.Add(item4);
            listItems.Add(item5);
            listItems.Add(item6);
            listItems.Add(item7);
            listItems.Add(item8);
            listItems.Add(item9);
            listItems.Add(item10);
            listItems.Add(item11);
            listItems.Add(item12);

            listChapeaux = new List<Items>();
            listGants = new List<Items>();
            listLunettes = new List<Items>();
            listPantalon = new List<Items>();
            listTuniques = new List<Items>();
            listChaussures = new List<Items>();
            listArmes = new List<Items>();
            listarmures = new List<Items>();
            listPotion = new List<Items>();

            listNameChapeauxUC = new List<String>();
            listNameGants = new List<String>();
            listNameLunettes = new List<String>();
            listNamePantalon = new List<String>();
            listNameTuniques = new List<String>();
            listNameChaussures = new List<String>();
            listNameArmes = new List<String>();
            listNameArmures = new List<String>();
            listNamePotions = new List<String>();


            foreach (var item in listItems)
            {
                ///testlv.Items.Add(item.Name).ToString();

                switch (item.CategorieName)
                {
                    case "Chapeaux":
                        listChapeaux.Add(item);
                        listNameChapeauxUC.Add(item.Name);
                        lblChapeau.Content = item.Name;
                        break;
                    case "Gants":
                        listGants.Add(item);
                        listNameGants.Add(item.Name);
                        lblGant.Content = item.Name;
                        break;
                    case "Lunettes":
                        listLunettes.Add(item);
                        listNameLunettes.Add(item.Name);
                        lblLunettes.Content = item.Name;
                        break;
                    case "Pantalon":
                        listPantalon.Add(item);
                        listNamePantalon.Add(item.Name);
                        lblPantalon.Content = item.Name;
                        break;
                    case "Tunique":
                        listTuniques.Add(item);
                        listNameTuniques.Add(item.Name);
                        lblTunique.Content = item.Name;
                        break;
                    case "Chaussures":
                        listChaussures.Add(item);
                        listNameChaussures.Add(item.Name);
                        lblChaussures.Content = item.Name;
                        break;
                    case "Arme":
                        listArmes.Add(item);
                        listNameArmes.Add(item.Name);
                        lblArme.Content = item.Name;
                        break;
                    case "Armure":
                        listarmures.Add(item);
                        listNameArmures.Add(item.Name);
                        lblArmure.Content = item.Name;
                        break;
                    case "Potion":
                        listPotion.Add(item);
                        listNamePotions.Add(item.Name);
                        lblPotion.Content = item.Name;
                        break;
                    default:
                        MessageBox.Show("ERROR : Aucune Catégorie n'existe pour cet Item.");
                        break;
                }
            }
        }

        private void InitCatgories()
        {
            categorie1 = new Categories(CHAPEAUX, listChapeaux);
            buttonChapeau.Content = categorie1.CategorieName;
            categorie2 = new Categories(GANTS, listGants);
            buttonGant.Content = categorie2.CategorieName;
            categorie3 = new Categories(LUNETTES, listLunettes);
            buttonLunettes.Content = categorie3.CategorieName;
            categorie4 = new Categories(PANTALON, listPantalon);
            buttonPantalon.Content = categorie4.CategorieName;
            categorie5 = new Categories(TUNIQUE, listTuniques);
            buttonTunique.Content = categorie5.CategorieName;
            categorie6 = new Categories(CHAUSSURES, listChaussures);
            buttonChaussures.Content = categorie6.CategorieName;
            categorie7 = new Categories(ARME, listArmes);
            buttonArme.Content = categorie7.CategorieName;
            categorie8 = new Categories(ARMURE, listarmures);
            buttonArmure.Content = categorie8.CategorieName;
            categorie9 = new Categories(POTION, listPotion);

            listCategories = new List<Categories>();
            listCategories.Add(categorie1);
            listCategories.Add(categorie2);
            listCategories.Add(categorie3);
            listCategories.Add(categorie4);
            listCategories.Add(categorie5);
            listCategories.Add(categorie6);
            listCategories.Add(categorie7);
            listCategories.Add(categorie8);
            listCategories.Add(categorie9);

            foreach (var item in listCategories)
            {
                ///testcat.Items.Add(item.CategorieName).ToString();
            }
        }

        private void SaveInBdd()
        {
            DbCat = new Database<Categories>();
            if (DbCat.Get(1).Result is null)
            {
                DbCat.Insert(listCategories);
            }
        }
        ///
        /// Pas besoin de sauvegarder la liste d'items car elle se sauvegarde automatiquement avec la gestion de
        /// clé étrangère en BDD
        /// 
        /*
        private ListView BuildListView()
        {
            myListView = new ListView();
            Grid content = new Grid();

            content.RowDefinitions.Add(new RowDefinition());
            Grid.SetRow(myListView, 1);
            Grid.SetColumn(myListView, 1);
            Grid.SetRowSpan(myListView, 5);

            List<List<Items>> newList = new List<List<Items>>();
            newList.Add(listChapeaux);
            newList.Add(listGants);
            newList.Add(listLunettes);
            newList.Add(listPantalon);
            newList.Add(listTuniques);
            newList.Add(listChaussures);
            newList.Add(listArmes);
            newList.Add(listarmures);
            newList.Add(listPotion);

            int i = 0;

            foreach (var item in newList)
            {
                ListView myDoubleListView = new ListView();
                myDoubleListView.ItemsSource = item.ToString();
                Grid.SetColumn(myDoubleListView, 3);
                Grid.SetRow(myDoubleListView, i);
                myListView.Items.Add(myDoubleListView);
                i++;
                ///content.Children.Add(myDoubleListView);
            }
            myListView.ItemsSource = myListView.ToString();
            ///myListView.ItemsSource = content.ToString();

            return myListView;
        }*/
        #endregion

        #region Events
        #endregion

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