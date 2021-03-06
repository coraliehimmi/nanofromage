﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanofromageLibrairy.Models
{
    public class ModelBase : INotifyPropertyChanged

    {
        #region StaticVariables
        public static MySqlConnection connection;
        #endregion

        #region Constants
        public static String CONNECTIONSTRING = "Server=localhost;Port=3306;Database=nanofromage;Uid=root;Pwd=";
        #endregion

        #region Variables
        #endregion

        #region Attributs
        private int id;
        #endregion

        #region Properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ModelBase()
        {

        }
        #endregion

        #region StaticFunctions
        #endregion

        #region Functions
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

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