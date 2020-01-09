using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Gocip.Connection
{
    class SQLConnection
    {
        private static SqlConnection Conn;

        public static SqlConnection GetConn()
        {
            Conn = new SqlConnection();
            Conn.ConnectionString = "Data Source = RIZKY\\SQLEXPRESS;" +
                                    "Initial Catalog = GO_RECIPE_db;" +
                                    "Integrated Security = True;";

            return Conn;
        }
    }
}
