using MySql.Data.Entity;
using NanofromageLibrairy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.MySql
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MaDatabase<T> : DbContext where T : Character
    {
        public MaDatabase(String connectionString = null) :
            base(connectionString == null ?
            "Server=localhost;Port=3306;Database=nanofromage;Uid=root;Pwd=" : connectionString);
            }
    }
}
