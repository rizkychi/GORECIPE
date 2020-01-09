using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Gocip.Model
{
    class LoginModel
    {
        private SqlConnection Conn;

        private string query;
        private bool result;

        public LoginModel()
        {
            Conn = Connection.SQLConnection.GetConn();
        }

        private string user;
        private string pass;

        public string GetUser()
        {
            return user;
        }

        public void SetUser(string user)
        {
            this.user = user;
        }

        public string GetPassword()
        {
            return pass;
        }

        public void SetPassword(string pass)
        {
            this.pass = pass;
        }

        public bool Login(string user, string pass, int type)
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

            query = "SELECT * FROM " + LoginAs + " WHERE username = '" + user + "' AND password = '" + pass + "'";
            Conn.Open();

            SqlCommand command = Conn.CreateCommand();
            command.CommandText = query;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if ((reader.GetString(0).ToString()) == user && (reader.GetString(1).ToString() == pass))
                {
                    result = true;
                    SetUser(reader.GetString(0));
                }
                else
                {
                    result = false;
                }
            }

            Conn.Close();
            return result;
        }
    }
}