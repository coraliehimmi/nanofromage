using Database.MySql;
using nanofromage.Views;
using NanofromageLibrairy.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
        public App()
        {
            Window MainWindow = new Window();
            MainWindow.Content = new FirstConnexion();
            MainWindow.MinHeight = 800;
            MainWindow.MinWidth = 1200;
            MainWindow.Show();

            Database<Character> Db = new Database<Character>();
            Db.Insert(new Character());
   
        }
    }
}
