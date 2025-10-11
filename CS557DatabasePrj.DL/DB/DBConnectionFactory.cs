using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CS557DatabasePrj.DL.DB
{
    public static class DbConnectionFactory
    {
        private static readonly string _connString =
            "Server=localhost;Database=Name;Uid=root;Pwd=Password;";

        public static IDbConnection CreateConnection()
        {
            var conn = new MySqlConnection(_connString);
            conn.Open();
            return conn;
        }
    }
}
