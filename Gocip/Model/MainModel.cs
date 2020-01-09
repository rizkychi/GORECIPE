using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Gocip.Model
{
    class MainModel
    {
        private SqlConnection conn;

        private string query;
        private bool result;

        public MainModel()
        {
            conn = Connection.SQLConnection.GetConn();
        }

        public int TotalView()
        {
            query = "SELECT COUNT (id_recipe) AS total FROM POLLING";
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, "POLLING");

            int count = (int)ds.Tables[0].Rows[0]["total"];

            conn.Close();
            return count;
        }

        public int TotalFeed()
        {
            query = "SELECT COUNT (id_feedback) AS total FROM FEEDBACK";
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, "FEEDBACK");

            int count = (int)ds.Tables[0].Rows[0]["total"];

            conn.Close();
            return count;
        }

        public int TotalUser()
        {
            query = "SELECT COUNT (username) AS total FROM ADMINISTRATOR";
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, "ADMINISTRATOR");

            int count = (int)ds.Tables[0].Rows[0]["total"];

            query = "SELECT COUNT (username) AS total FROM CUSTOMER";

            command = conn.CreateCommand();
            command.CommandText = query;
            sda = new SqlDataAdapter(command);
            ds = new DataSet();
            sda.Fill(ds, "CUSTOMER");

            count += (int)ds.Tables[0].Rows[0]["total"];

            conn.Close();
            return count;
        }

        public int TotalRecipe()
        {
            query = "SELECT COUNT (id_recipe) AS total FROM RECIPE";
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, "RECIPE");

            int count = (int)ds.Tables[0].Rows[0]["total"];

            conn.Close();
            return count;
        }

        public int TotalIngredient()
        {
            query = "SELECT COUNT (id_ingredient) AS total FROM INGREDIENT";
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, "INGREDIENT");

            int count = (int)ds.Tables[0].Rows[0]["total"];

            conn.Close();
            return count;
        }

        public int TotalCategory()
        {
            query = "SELECT COUNT (id_category) AS total FROM CATEGORY";
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, "CATEGORY");

            int count = (int)ds.Tables[0].Rows[0]["total"];

            conn.Close();
            return count;
        }

        public DataSet SelectExpensiveRecipe()
        {
            query = "SELECT TOP 1 name, cost FROM RECIPE ORDER BY cost DESC";
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, "RECIPE");

            conn.Close();
            return ds;
        }

        public DataSet SelectFavRecipe()
        {
            query = "SELECT TOP 1 name, polling FROM RECIPE ORDER BY polling DESC";
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, "RECIPE");

            conn.Close();
            return ds;
        }

        public DataSet SelectROTD()
        {
            query = "SELECT TOP 2 * FROM RECIPE_OTD JOIN RECIPE ON RECIPE_OTD.id_recipe = RECIPE.id_recipe WHERE (SELECT CONVERT(date, otd_date)) = (SELECT CONVERT(date, getdate()))";
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, "RECIPE_OTD");

            conn.Close();
            return ds;
        }

        public bool InsertROTD(int id)
        {
            result = false;
            try
            {
                query = "INSERT INTO RECIPE_OTD VALUES (" + id + ",GETDATE())";
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

        public bool DeleteROTD(int id)
        {
            result = false;
            try
            {
                query = "DELETE FROM RECIPE_OTD WHERE id_recipe = " + id + " AND (SELECT CONVERT(date, otd_date)) = (SELECT CONVERT(date, getdate()))";
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
