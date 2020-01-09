using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Gocip.Model
{
    class DataPollingModel
    {
        private SqlConnection conn;

        private string query;
        private bool result;

        public DataPollingModel()
        {
            conn = Connection.SQLConnection.GetConn();
        }

        private static string username;
        private int id_recipe;

        public int GetRecipe_Id() { return id_recipe; }
        public string GetUsername() { return username; }
        public void SetRecipe_Id(int id) { this.id_recipe = id; }
        public void SetUsername(string user) { username = user; }

        public bool InsertFeedback()
        {
            result = false;
            try
            {
                query = "INSERT INTO POLLING VALUES (" + id_recipe + ",'" + username + "',GETDATE())";
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = query;
                command.ExecuteNonQuery();
                result = true;
            }
            catch (SqlException)
            {
                result = false;
            }
            conn.Close();
            return result;
        }
    }
}
