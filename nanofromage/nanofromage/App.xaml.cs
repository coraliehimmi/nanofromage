using Database.MySql;
using LoggerUtil;
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
        public const string TAG = "App";
        Loger loger;

        public App()
        {
            Window MainWindow = new Window();
            MainWindow.Content = new Home();
            MainWindow.Show();
            
            loger = new Loger(new List<Alert> { Alert.CONSOLE }, new List<Mode> { Mode.CONSOLE });
            loger.Log(TAG, this, "Mon test");

            Database<Character> Db = new Database<Character>();
            Mage mage1 = new Mage();
            mage1.Sex = true;
            mage1.Money = 100;
            mage1.MagicPoint = 10;
            mage1.Level = 1;
            mage1.HitPoint = 10;
            Database<Mage> Dbmage = new Database<Mage>();
            Hunter hunter1 = new Hunter();
            hunter1.Money = 200;
            hunter1.Level = 1;
            hunter1.HitPoint = 50;
            hunter1.Precision = 20;
           
            Database<Hunter> Dbhunter = new Database<Hunter>();
            Dbhunter.Insert(hunter1);

            //Dbmage.Insert(mage1);
            //Dbmage.Insert(mage2);
            //Dbmage.Insert(mage3);

            //Db.Insert(new Character());
            //Database<Character> Db = new Database<Character>();
            //Db.Insert(new Character());
            //Db.Insert(new Character());
            /* Mage c1 = new Mage();
             c1.Name = "mage";
             c1.Level = 1;
             c1.MagicPoint = 50;
             c1.HitPoint = 10;*/


        }
    }
}
