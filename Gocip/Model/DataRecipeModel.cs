using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Gocip.Model
{
    class DataRecipeModel
    {
        private SqlConnection conn;

        private string query;
        private static DataSet DetailCategory;
        private static DataSet DetailIngredient;
        private bool result;

        public DataRecipeModel()
        {
            conn = Connection.SQLConnection.GetConn();
            CreateDataSet();
        }

        private int id_recipe;
        private string name;
        private string description;
        private double cost;
        private string method;
        private string picture;
        private string video;
        private int polling;

        public DataSet GetDetailCategory() { return DetailCategory; }
        public DataSet GetDetailIngredient() { return DetailIngredient; }
        public int GetRecipe_Id() { return id_recipe; }
        public string GetRecipe_Name() { return name; }
        public string GetRecipe_Description() { return description; }
        public double GetRecipe_Cost() { return cost; }
        public string GetRecipe_Method() { return method; }
        public string GetRecipe_Picture() { return picture; }
        public string GetRecipe_Video() { return video; }
        public int GetRecipe_Polling() { return polling; }
        public void SetDetailCategory(DataSet ds) { DetailCategory = ds; }
        public void SetDetailIngredient(DataSet ds) { DetailIngredient = ds; }
        public void SetRecipe_ID(int id) { this.id_recipe = id; }
        public void SetRecipe_Name(string name) { this.name = name; }
        public void SetRecipe_Description(string desc) { this.description = desc; }
        public void SetRecipe_Cost(double cost) { this.cost = cost; }
        public void SetRecipe_Method(string method) { this.method = method; }
        public void SetRecipe_Picture(string pict) { this.picture = pict; }
        public void SetRecipe_Video(string vid) { this.video = vid; }
        public void SetRecipe_Polling(int polling) { this.polling = polling; }



        //Select
        public DataSet SelectRecipe()
        {
            query = "SELECT * FROM RECIPE";
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, "RECIPE");

            conn.Close();
            return ds;
        }
        //search
        public DataSet SearchRecipe(string text)
        {
            query = "SELECT * FROM RECIPE WHERE name LIKE '%" + text + "%'";
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, "RECIPE");

            conn.Close();
            return ds;
        }

        public void ShowDetail(int id)
        {
            conn.Open();

            query = "SELECT DETAIL_CATEGORY.id_category, name, main_category FROM DETAIL_CATEGORY JOIN CATEGORY ON DETAIL_CATEGORY.id_category = CATEGORY.id_category WHERE id_recipe = " + id;
            
            SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, "DETAIL_CATEGORY");

            DetailCategory = ds;

            query = "SELECT di.id_ingredient, name, amount, di.unit, di.price FROM DETAIL_INGREDIENT di JOIN INGREDIENT i ON di.id_ingredient = i.id_ingredient WHERE id_recipe = " + id;

            command.CommandText = query;
            sda = new SqlDataAdapter(command);
            ds = new DataSet();
            sda.Fill(ds, "DETAIL_INGREDIENT");

            DetailIngredient = ds;

            conn.Close();
        }

        //insert
        public bool InsertRecipe()
        {
            int it = 0;
            result = false;
            
            if (name.Length > 45)
            {
                name = name.Substring(0, 45);
            }
            if (description.Length > 300)
            {
                description = description.Substring(0, 300);
            }

            try
            {
                //insert to recipe
                query = "INSERT INTO RECIPE VALUES ('" + name + "','" + description + "','" + method + "','" + picture + "','" + video + "');"
                    +"SELECT CAST(scope_identity() AS int) AS IDRecipe";
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = query;
                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                sda.Fill(ds, "RECIPE");

                SetRecipe_ID(Int32.Parse(ds.Tables[0].Rows[0][0].ToString()));

                //insert to detail category
                query = "INSERT INTO DETAIL_CATEGORY VALUES ";

                it = 0;
                foreach (DataRow dr in DetailCategory.Tables[0].Rows)
                {
                    if (it == 0)
                    {
                        query += "(" + GetRecipe_Id() + "," + dr["id_category"] + ")";
                    }
                    else
                    {
                        query += ",(" + GetRecipe_Id() + "," + dr["id_category"] + ")";
                    }
                    it++;
                }

                command.CommandText = query;
                command.ExecuteNonQuery();

                //insert to detail ingredient
                query = "INSERT INTO DETAIL_INGREDIENT VALUES ";

                it = 0;
                foreach (DataRow dr in DetailIngredient.Tables[0].Rows)
                {
                    if (it == 0)
                    {
                        query += "(" + GetRecipe_Id() + "," + dr["id_ingredient"] + "," + dr["amount"] + ",'" + dr["unit"] + "'," + dr["price"] + ")";
                    }
                    else
                    {
                        query += ",(" + GetRecipe_Id() + "," + dr["id_ingredient"] + "," + dr["amount"] + ",'" + dr["unit"] + "'," + dr["price"] + ")";
                    }
                    it++;
                }

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
        public bool DeleteRecipe()
        {
            result = false;
            try
            {
                query = "DELETE FROM DETAIL_CATEGORY WHERE id_recipe = " + id_recipe;
                query += ";DELETE FROM DETAIL_INGREDIENT WHERE id_recipe = " + id_recipe;
                query += ";DELETE FROM RECIPE WHERE id_recipe = " + id_recipe;
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
        public bool UpdateRecipe(int id)
        {
            int it = 0;
            result = false;

            if (name.Length > 45)
            {
                name = name.Substring(0, 45);
            }
            if (description.Length > 300)
            {
                description = description.Substring(0, 300);
            }

            try
            {
                //insert to recipe
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                query = "UPDATE RECIPE SET name = '" + name + "', description = '" + description + "', method = '" + method + "', picture = '" + picture + "', video = '" + video + "' WHERE id_recipe = " + id;

                command.CommandText = query;
                command.ExecuteNonQuery();

                //delete existing data on detail table
                query = "DELETE FROM DETAIL_CATEGORY WHERE id_recipe = " + id + ";INSERT INTO DETAIL_CATEGORY VALUES ";

                it = 0;
                foreach (DataRow dr in DetailCategory.Tables[0].Rows)
                {
                    if (it == 0)
                    {
                        query += "(" + id + "," + dr["id_category"] + ")";
                    }
                    else
                    {
                        query += ",(" + id + "," + dr["id_category"] + ")";
                    }
                    it++;
                }

                command.CommandText = query;
                command.ExecuteNonQuery();

                //delete existing data on detail table
                query = "DELETE FROM DETAIL_INGREDIENT WHERE id_recipe = " + id +";INSERT INTO DETAIL_INGREDIENT VALUES ";

                it = 0;
                foreach (DataRow dr in DetailIngredient.Tables[0].Rows)
                {
                    if (it == 0)
                    {
                        query += "(" + id + "," + dr["id_ingredient"] + "," + double.Parse(dr["amount"].ToString()) + ",'" + dr["unit"] + "'," + dr["price"] + ")";
                    }
                    else
                    {
                        query += ",(" + id + "," + dr["id_ingredient"] + "," + double.Parse(dr["amount"].ToString()) + ",'" + dr["unit"] + "'," + dr["price"] + ")";
                    }
                    it++;
                }

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

        // Insert Recipe
        // Dataset
        public void CreateDataSet()
        {
            DetailCategory = new DataSet();
            DetailCategory.Tables.Add(new DataTable());
            DetailCategory.Tables[0].Columns.Add("id_category", typeof(int));
            DetailCategory.Tables[0].Columns.Add("name", typeof(string));
            DetailCategory.Tables[0].Columns.Add("main_category", typeof(string));

            DetailIngredient = new DataSet();
            DetailIngredient.Tables.Add(new DataTable());
            DetailIngredient.Tables[0].Columns.Add("id_ingredient", typeof(int));
            DetailIngredient.Tables[0].Columns.Add("name", typeof(string));
            DetailIngredient.Tables[0].Columns.Add("amount", typeof(double));
            DetailIngredient.Tables[0].Columns.Add("unit", typeof(string));
            DetailIngredient.Tables[0].Columns.Add("price", typeof(double));
        }

        // Category
        public bool InsertCategory(int id, string name, string main)
        {
            bool exist = false;
            foreach (DataRow dr in DetailCategory.Tables[0].Rows)
            {
                if (dr["name"].ToString() == name)
                {
                    exist = true;
                    break;
                }
            }
            
            if (exist == false)
            {
                try
                {
                    DetailCategory.Tables[0].Rows.Add(id, name, main);
                    result = true;
                }
                catch (SyntaxErrorException)
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }
            
            return result;
        }

        public bool DeleteCategory(int index)
        {
            try
            {
                DetailCategory.Tables[0].Rows.RemoveAt(index);
                result = true;
            }
            catch (SyntaxErrorException)
            {
                result = false;
            }

            return result;
        }

        //Ingredient
        public bool InsertIngredient(int id, string name, string tounit, double amount, double price, string unit)
        {
            bool exist = false;
            foreach (DataRow dr in DetailIngredient.Tables[0].Rows)
            {
                if (dr["name"].ToString() == name)
                {
                    exist = true;
                    break;
                }
            }

            if (exist == false)
            {
                try
                {
                    DetailIngredient.Tables[0].Rows.Add(id, name, amount, tounit, amount*ConvertPrice(price,unit,tounit));
                    result = true;
                }
                catch (SyntaxErrorException)
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        public bool DeleteIngredient(int index)
        {
            try
            {
                DetailIngredient.Tables[0].Rows.RemoveAt(index);
                result = true;
            }
            catch (SyntaxErrorException)
            {
                result = false;
            }

            return result;
        }

        //Convert
        public double ConvertPrice(double price, string unit, string tounit)
        {
            double result = 0;
            if (unit == "kilogram")
            {
                if (tounit == "kg") { result = price; } 
                else if (tounit == "ons") { result = price / 10; }
                //else if (tounit == "cup") { result = price; }
                else if (tounit == "sdt") { result = price / 1000 * 4; }
                else if (tounit == "sdm") { result = price / 1000 * 12; }
                //else if (tounit == "ml") { result = price / 1000; }
                //else if (tounit == "liter") { result = price; }
                //else if (tounit == "pcs") { result = price; }
                else if (tounit == "btr") { result = price / 15; }
                else if (tounit == "gram") { result = price / 1000; }
                //else if (tounit == "bks") { result = price; }
                //else if (tounit == "btg") { result = price; }
                else if (tounit == "secukupnya") { result = 0; }
            }
            else if (unit == "liter")
            {
                //if (tounit == "kg") { result = price; }
                //else if (tounit == "ons") { result = price; }
                if (tounit == "cup") { result = price / 1000 * 250; }
                else if (tounit == "sdt") { result = price / 1000 * 5; }
                else if (tounit == "sdm") { result = price / 1000 * 15; }
                else if (tounit == "ml") { result = price / 1000; }
                else if (tounit == "liter") { result = price; }
                //else if (tounit == "pcs") { result = price; }
                //else if (tounit == "btr") { result = price; }
                //else if (tounit == "gram") { result = price; }
                //else if (tounit == "bks") { result = price; }
                //else if (tounit == "btg") { result = price; }
                else if (tounit == "secukupnya") { result = 0; }
            }
            else if (unit == "pcs")
            {
                //if (tounit == "kg") { result = price; }
                //else if (tounit == "ons") { result = price; }
                //else if (tounit == "cup") { result = price / 1000 * 250; }
                //else if (tounit == "sdt") { result = price / 1000 * 5; }
                //else if (tounit == "sdm") { result = price / 1000 * 15; }
                //else if (tounit == "ml") { result = price / 1000; }
                //else if (tounit == "liter") { result = price; }
                if (tounit == "pcs") { result = price; }
                else if (tounit == "btr") { result = price; }
                //else if (tounit == "gram") { result = price; }
                else if (tounit == "bks") { result = price; }
                else if (tounit == "btg") { result = price; }
                else if (tounit == "secukupnya") { result = 0; }
            }
            else
            {
                result = 0;
            }

            return result;
        }

        // DETAIL RECIPE
        public DataSet SelectDetailRecipe(int id)
        {
            query = "SELECT * FROM RECIPE WHERE id_recipe = " + id;
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, "RECIPE");

            conn.Close();
            return ds;
        }

        public DataSet SelectDetailRecipe_Cat(int id)
        {
            query = "SELECT name FROM DETAIL_CATEGORY JOIN CATEGORY ON DETAIL_CATEGORY.id_category = CATEGORY.id_category WHERE id_recipe = " + id;
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, "DETAIL_CATEGORY");

            conn.Close();
            return ds;
        }

        public DataSet SelectDetailRecipe_Ing(int id)
        {
            query = "SELECT name, amount, DETAIL_INGREDIENT.unit, DETAIL_INGREDIENT.price FROM DETAIL_INGREDIENT JOIN INGREDIENT ON DETAIL_INGREDIENT.id_ingredient = INGREDIENT.id_ingredient WHERE id_recipe = " + id;
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, "DETAIL_INGREDIENT");

            conn.Close();
            return ds;
        }

        public DataSet ShowLatestRecipe()
        {
            query = "SELECT TOP 10 * FROM RECIPE ORDER BY id_recipe DESC";
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, "RECIPE");

            conn.Close();
            return ds;
        }

        public DataSet ShowPopularRecipe()
        {
            query = "SELECT TOP 20 * FROM RECIPE ORDER BY polling DESC";
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, "RECIPE");

            conn.Close();
            return ds;
        }

        public DataSet ShowSearchRecipe(string text)
        {
            query = "SELECT * FROM RECIPE WHERE name LIKE '%" + text + "%'";
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, "RECIPE");

            conn.Close();
            return ds;
        }

        public DataSet ShowRecipeOfTheDay()
        {
            query = "SELECT TOP 2 RECIPE_OTD.id_recipe, name, picture FROM RECIPE_OTD JOIN RECIPE ON RECIPE_OTD.id_recipe = RECIPE.id_recipe WHERE (SELECT CONVERT(date, otd_date)) = (SELECT CONVERT(date, getdate()))";
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, "RECIPE_OTD");

            conn.Close();
            return ds;
        }

        public DataSet ShowCategoryRecipe(int id)
        {
            query = "SELECT * FROM RECIPE JOIN DETAIL_CATEGORY ON RECIPE.id_recipe = DETAIL_CATEGORY.id_recipe WHERE id_category = " + id;
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, "RECIPE");

            conn.Close();
            return ds;
        }
    }
}
