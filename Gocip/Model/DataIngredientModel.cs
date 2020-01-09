using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Gocip.Model
{
    class DataIngredientModel
    {
        private SqlConnection conn;
        private Model.DataRecipeModel RecipeModel;

        private string query;
        private bool result;

        public DataIngredientModel()
        {
            conn = Connection.SQLConnection.GetConn();
            RecipeModel = new DataRecipeModel();
        }

        private int id_ingredient;
        private string name;
        private string unit;
        private double price;

        public int GetIngredient_Id() { return id_ingredient; }
        public string GetIngredient_Name() { return name; }
        public string GetIngredient_Unit() { return unit; }
        public double GetIngredient_Price() { return price; }
        public void SetIngredient_ID(int id) { this.id_ingredient = id; }
        public void SetIngredient_Name(string name) { this.name = name; }
        public void SetIngredient_Unit(string unit) { this.unit = unit; }
        public void SetIngredient_Price(double price) { this.price = price; }

        //Select
        public DataSet SelectIngredient()
        {
            query = "SELECT * FROM INGREDIENT";
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, "INGREDIENT");

            conn.Close();
            return ds;
        }
        //search
        public DataSet SearchIngredient(string text)
        {
            query = "SELECT * FROM INGREDIENT WHERE name LIKE '%" + text + "%'";
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, "INGREDIENT");

            conn.Close();
            return ds;
        }
        //insert
        public bool InsertIngredient()
        {
            result = false;
            try
            {
                query = "INSERT INTO INGREDIENT VALUES ('" + name + "','" + price + "','" + unit + "')";
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
        public bool DeleteIngredient()
        {
            result = false;
            try
            {
                query = "DELETE FROM DETAIL_INGREDIENT WHERE id_ingredient = " + id_ingredient + ";DELETE FROM INGREDIENT WHERE id_ingredient = '" + id_ingredient + "'";
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
        public bool UpdateIngredient()
        {
            result = false;
            try
            {
                query = "UPDATE INGREDIENT SET name = '" + name + "', unit = '" + unit + "', price = '" + price + "' WHERE id_ingredient = '" + id_ingredient + "'";
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = query;
                command.ExecuteNonQuery();
                UpdatePrice();
                result = true;
            }
            catch (SqlException)
            {
                result = false;
            }
            conn.Close();
            return result;
        }

        //update price
        public void UpdatePrice()
        {
            try
            {
                query = "SELECT id_recipe, amount, INGREDIENT.unit, INGREDIENT.price, DETAIL_INGREDIENT.unit as tounit FROM DETAIL_INGREDIENT JOIN INGREDIENT ON DETAIL_INGREDIENT.id_ingredient = INGREDIENT.id_ingredient WHERE INGREDIENT.id_ingredient = " + id_ingredient;
                

                SqlCommand command = conn.CreateCommand();
                command.CommandText = query;
                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                sda.Fill(ds, "DETAIL_INGREDIENT");

                double conv = 0;

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    conv = RecipeModel.ConvertPrice(double.Parse(dr["price"].ToString()), dr["unit"].ToString(), dr["tounit"].ToString());
                    query = "UPDATE DETAIL_INGREDIENT SET price = " + double.Parse(dr["amount"].ToString()) * conv + "WHERE id_ingredient = " + id_ingredient + " AND id_recipe = " + Int32.Parse(dr["id_recipe"].ToString());

                    try
                    {
                        command.CommandText = query;
                        command.ExecuteNonQuery();
                    }
                    catch (Exception) { }
                }
            }
            catch (SqlException)
            {
            }
        }
    }
}
