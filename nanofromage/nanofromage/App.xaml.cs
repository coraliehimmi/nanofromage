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
            MainWindow.Show();
            

            Database<Character> Db = new Database<Character>();
            //Db.Insert(new Character());
            //Database<Character> Db = new Database<Character>();
            //sDb.Insert(new Character());
            //Db.Insert(new Character());
           /* Mage c1 = new Mage();
            c1.Name = "mage";
            c1.Level = 1;
            c1.MagicPoint = 50;
            c1.HitPoint = 10;*/

   
        }
    }
}
