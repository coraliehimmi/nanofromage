using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database.MySql
{
    public class Ajouts
    {
        /// <summary>
        /// 
        /// </summary>
        #region StaticVariables
        public static MySqlConnection connection;
        public static MySqlCommand cmd;
        public static int result;
        #endregion

        #region Constants
        public static String CONNECTIONSTRING = "Server=localhost;Port=3306;Database=nanofromage;Uid=root;Pwd=";
        #endregion

        #region Variables
        
        #endregion

        #region Attributs
        #endregion

        #region Properties
        #endregion

        #region Constructors
        #endregion

        #region StaticFunctions
        public static void UpdateItems(int catgorie_id, String categorieName)
        {
            try
            {
                connection = new MySqlConnection(CONNECTIONSTRING);
                connection.Open();
                cmd = connection.CreateCommand();
                ///cmd.CommandText = "UPDATE items SET Categorie_Id = 1 WHERE CategorieName = @";
                cmd.CommandText = "UPDATE items SET Categories_Id = @Categorie_Id WHERE CategorieName = @CategorieName";
                cmd.Parameters.AddWithValue("Categories_Id", catgorie_id);
                cmd.Parameters.AddWithValue("CategorieName", categorieName);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            connection.Close();
        }
        #endregion

        #region Functions
        #endregion

        #region Events
        #endregion
    }
}
