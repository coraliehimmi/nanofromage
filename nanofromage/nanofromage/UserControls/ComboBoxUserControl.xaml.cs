﻿using Database.MySql;
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
    /// Logique d'interaction pour ComboBoxUserControl.xaml
    /// </summary>
    public partial class ComboBoxUserControl : UserControl, INotifyPropertyChanged
    {
        #region StaticVariables
        #endregion

        #region Constants
        #endregion

        #region Variables
        public Clan mage = new Clan("Mage", "A force d'étudier sans cesse, il parvient à maîtriser la magie et acquiert d'incroyables pouvoirs.", 10, 50, 30);
        public Clan warrior = new Clan("Warrior", "Maître en matière d’armes et d’armures de toutes sortes, il est à la fois courageux et vaillant.", 30, 20, 10);
        public Clan hunter = new Clan("Hunter", "il peut combattre aussi bien de près que de loin. C’est un tireur hors pair possédant de grandes capacités dans ce domaines. Il peut lancer plusieurs flèches en même temps et peut appeler des animaux en combat", 50, 10, 40);
        public List<String> listClan;
        private String selectedClan;
        #endregion

        #region Attributs

        #endregion

        #region Properties
        public List<String> ListClan { get; set; }
        #endregion

        #region Constructors
        public ComboBoxUserControl()
        {
            InitializeComponent();
            listClan = new List<String>();
            Load();
            comboBox.ItemsSource = listClan; /// en fonction des Clans dispo, on les affiche tous
            Events();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedClan = (String)comboBox.SelectedItem;
            if (selectedClan == "Mage")
            {
                XAMLdescription.Text = mage.Description;
            }
            else if (selectedClan == "Warrior")
            {
                XAMLdescription.Text = warrior.Description;
            }
            else if (selectedClan == "Hunter")
            {
                XAMLdescription.Text = hunter.Description;
            }
            else
                XAMLdescription.Text = "c'est raté...!";
        } 
        /// <summary>
        ///  Affichage de la description en fonction du clan choisi
        /// </summary>
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        public void Load() /// téléchargement de tous les clans
        {
            listClan.Add(mage.NameClan);
            listClan.Add(warrior.NameClan);
            listClan.Add(hunter.NameClan);
        }

        public void Save() /// sauvegarde en BDD des clans mais à revoir car manque des choses
        {
            Database<Clan> DbClan = new Database<Clan>();
            DbClan.Insert(mage);
            DbClan.Insert(hunter);
            DbClan.Insert(warrior);
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        private void Events()
        {
            this.comboBox.SelectionChanged += ComboBox_SelectionChanged;
        }

        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

    }
}
