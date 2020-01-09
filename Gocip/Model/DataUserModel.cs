using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Gocip.Model
{
    class DataUserModel
    {
        private SqlConnection Conn;

        private string query;
        private bool result;

        public DataUserModel()
        {
            Conn = Connection.SQLConnection.GetConn();
        }

        private string user;
        private string old_user;
        private string pass;

        public string GetUser()
        {
            return user;
        }

        public string GetOldUser()
        {
            return old_user;
        }

        public void SetUser(string user)
        {
            this.user = user;
        }

        public void SetOldUser(string user)
        {
            this.old_user = user;
        }

        public string GetPassword()
        {
            return pass;
        }

        public void SetPassword(string pass)
        {
            this.pass = pass;
        }

        //Select User
        public DataSet SelectUser(int type)
        {
            string LoginAs;
            if (type == 1)
            {
                LoginAs = "ADMINISTRATOR";
            }
            else
            {
                LoginAs = "CUSTOMER";
            }

            query = "SELECT * FROM " + LoginAs;
            Conn.Open();

            SqlCommand command = Conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, LoginAs);

            Conn.Close();
            return ds;
        }

        //Insert User
        public Boolean InsertUser(int type)
        {
            string LoginAs;
            if (type == 1)
            {
                LoginAs = "ADMINISTRATOR";
            }
            else
            {
                LoginAs = "CUSTOMER";
            }
            result = false;
            try
            {
                query = "INSERT INTO " + LoginAs + " VALUES ('" + user + "','" + pass + "')";
                Conn.Open();

                SqlCommand command = Conn.CreateCommand();
                command.CommandText = query;
                command.ExecuteNonQuery();
                result = true;
            }
            catch (SqlException)
            {
                result = false;
            }
            Conn.Close();
            return result;
        }

        //Delete User
        public Boolean DeleteUser(int type)
        {
            string LoginAs;
            if (type == 1)
            {
                LoginAs = "ADMINISTRATOR";
            }
            else
            {
                LoginAs = "CUSTOMER";
            }
            result = false;
            try
            {
                query = "DELETE FROM " + LoginAs + " WHERE username = '" + user + "'";
                Conn.Open();

                SqlCommand command = Conn.CreateCommand();
                command.CommandText = query;
                command.ExecuteNonQuery();
                result = true;
            }
            catch (SqlException)
            {
                result = false;
            }
            Conn.Close();
            return result;
        }

        //search user
        public DataSet SearchUser(int type, string text)
        {
            string LoginAs;
            if (type == 1)
            {
                LoginAs = "ADMINISTRATOR";
            }
            else
            {
                LoginAs = "CUSTOMER";
            }

            query = "SELECT * FROM " + LoginAs + " WHERE username LIKE '%" + text + "%'";
            Conn.Open();

            SqlCommand command = Conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, LoginAs);

            Conn.Close();
            return ds;
        }

        //update
        public bool UpdateUser(int type)
        {
            string LoginAs;
            if (type == 1)
            {
                LoginAs = "ADMINISTRATOR";
            }
            else
            {
                LoginAs = "CUSTOMER";
            }
            result = false;
            try
            {
                query = "UPDATE "+LoginAs+" SET username = '" + user + "', password = '" + pass + "' WHERE username = '" + old_user + "'";
                Conn.Open();

                SqlCommand command = Conn.CreateCommand();
                command.CommandText = query;
                command.ExecuteNonQuery();
                result = true;
            }
            catch (SqlException)
            {
                result = false;
            }
            Conn.Close();
            return result;
        }
    }
}
