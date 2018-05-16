using Database.MySql;
using LoggerUtil;
using MySql.Data.Entity;
using MySql.Data.MySqlClient;
using nanofromage.Views;
using NanofromageLibrairy.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace nanofromage
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        public const string TAG = "App";
        Loger loger;

        public App()
        {
            Window MainWindow = new Window();
            ///MainWindow.Content = new FirstConnexion();
            MainWindow.Content = new Home();
            MainWindow.Show();
            
            loger = new Loger(new List<Alert> { Alert.CONSOLE }, new List<Mode> { Mode.CONSOLE });
            loger.Log(TAG, this, "Mon test");

            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
            Database<User> DbUser = new Database<User>();
            ///MySqlConnection connection = new MySqlConnection(connectionString);
            ///DbUser.Insert(admin); /// Création du compte admin à la création de la base de données.
        }
    }
}
