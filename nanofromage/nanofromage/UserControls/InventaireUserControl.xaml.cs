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
    /// </summary>
    public partial class InventaireUserControl : UserControl
    {
        #region StaticVariables
        public static List<Items> listItems;
        public static List<Categories> listCategories;
        #endregion

        #region Constants
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
        public event PropertyChangedEventHandler PropertyChanged;
        private DependencyProperty dp;
        #endregion

        #region Attributs
        #endregion

        #region Properties
        /*public List<Items> ListItems
        {
            get { return listItems; }
            set
            {
                listItems = value;
                OnPropertyChanged("ListItems");
            }
        }

        public List<Categories> ListCategories
        {
            get { return listCategories; }
            set
            {
                listCategories = value;
                OnPropertyChanged("ListCategories");
            }
        }*/
        #endregion

        #region Constructors
        public InventaireUserControl()
        {
            InitializeComponent();
            DataContext = this;
            InitCatgories();
            InitItems();
            ///InitAffCat();
            ///InitAffItems();
        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        private void InitItems()
        {
            item1 = new Items("Casque en fer", 6, "Casque en fer brut");
            item2 = new Items("Tunique d'entraînement", 2, "Tunique d'aventurier débutant");
            item3 = new Items("Botte d'entraînement", 1, "Botte pour aventurier débutant");
            item4 = new Items("Pantalon d'entraînement", 3, "Pantalon pour aventurier débutant");
            item5 = new Items("Potion de vie", 5, "Permet de récupérer 5 PV");
            item6 = new Items("Potion de mana", 5, " Permet de récupérer 5 PM");
            item7 = new Items("Gants d'armure", 2, "Permet de ne pas se blesser");
            item8 = new Items("Les yeux de Dieu", 15, "Permet de gagner en attaque");
            item9 = new Items("Les yeux de Lynx", 4, "Avoir une bonne vision");
            item10 = new Items("Bouclier de héro", 5 , "Te protège des attaques");
            item11 = new Items("Le marteau de Thor", 3, "Te rend invincible");
            item12 = new Items("Les escarpins magiques", 8 , "Ecrase tes adversaires avec");

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

            foreach (var item in listItems)
            {
                testlv.Items.Add(item.Name).ToString();
            }
        }

        private void InitCatgories()
        {
            categorie1 = new Categories("Chapeaux");   /// 0
            categorie2 = new Categories("Gants");   /// 1
            categorie3 = new Categories("Lunettes");   /// 2
            categorie4 = new Categories("Pantalon");   /// 3
            categorie5 = new Categories("Tunique");   /// 4
            categorie6 = new Categories("Chaussures");   /// 5
            categorie7 = new Categories("Arme");   /// 6
            categorie8 = new Categories("Armure");   /// 7
            categorie9 = new Categories("Potion");   /// 8

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
                testcat.Items.Add(item.CategorieName).ToString();
            }
            /*listCategories.Add(categorie1);
            testcat.Items.Add(categorie1.CategorieName).ToString();
            listCategories.Add(categorie2);
            testcat.Items.Add(categorie2.CategorieName).ToString();
            listCategories.Add(categorie3);
            testcat.Items.Add(categorie3.CategorieName).ToString();
            listCategories.Add(categorie4);
            testcat.Items.Add(categorie4.CategorieName).ToString();
            listCategories.Add(categorie5);
            testcat.Items.Add(categorie5.CategorieName).ToString();
            listCategories.Add(categorie6);
            testcat.Items.Add(categorie6.CategorieName).ToString();
            listCategories.Add(categorie7);
            testcat.Items.Add(categorie7.CategorieName).ToString();
            listCategories.Add(categorie8);
            testcat.Items.Add(categorie8.CategorieName).ToString();
            listCategories.Add(categorie9);
            testcat.Items.Add(categorie9.CategorieName).ToString();*/
        }
        #endregion

        #region Events
        #endregion

    }
}