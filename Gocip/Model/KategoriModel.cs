using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Gocip.Model
{
    class KategoriModel
    {
        private SqlConnection conn;

        private string query;
        private bool result;

        public KategoriModel()
        {
            conn = Connection.SQLConnection.GetConn();
        }

        private int id_category;
        private string name;
        private string main_category;

        public int GetCategory_Id() { return id_category; }
        public string GetCategory_Name() { return name; }
        public string GetCategory_Main() { return main_category; }
        public void SetCategory_ID(int id) { this.id_category = id; }
        public void SetCategory_Name(string name) { this.name = name; }
        public void SetCategory_Main(string main) { this.main_category = main; }

        //Select
        public DataSet SelectCategory()
        {
            query = "SELECT * FROM CATEGORY";
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, "CATEGORY");

            conn.Close();
            return ds;
        }
        //search
        public DataSet SearchCategory(string text)
        {
            query = "SELECT * FROM CATEGORY WHERE name LIKE '%" + text + "%' OR main_category LIKE '%" + text + "%'";
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, "CATEGORY");

            conn.Close();
            return ds;
        }
        //insert
        public bool InsertCategory()
        {
            result = false;
            try
            {
                query = "INSERT INTO CATEGORY VALUES ('" + name + "','" + main_category + "')";
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
        //delete
        public bool DeleteCategory()
        {
            result = false;
            try
            {
                query = "DELETE FROM DETAIL_CATEGORY WHERE id_category = " + id_category + ";DELETE FROM CATEGORY WHERE id_category = " + id_category;
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
        //update
        public bool UpdateCategory()
        {
            result = false;
            try
            {
                query = "UPDATE CATEGORY SET name = '" + name + "', main_category = '" + main_category + "' WHERE id_category = '" + id_category + "'";
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
