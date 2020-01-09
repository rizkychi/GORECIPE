using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Gocip.Model
{
    class DataFeedbackModel
    {
        private SqlConnection conn;

        private string query;
        private bool result;

        public DataFeedbackModel()
        {
            conn = Connection.SQLConnection.GetConn();
        }

        private int id;
        private string name;
        private string phone;
        private string message;

        public int GetFeedback_Id() { return id; }
        public string GetFeedback_Name() { return name; }
        public string GetFeedback_Phone() { return phone; }
        public string GetFeedback_Message() { return message; }
        public void SetFeedback_Id(int id) { this.id = id; }
        public void SetFeedback_Name(string name) { this.name = name; }
        public void SetFeedback_Phone(string phone) { this.phone = phone; }
        public void SetFeedback_Message(string message) { this.message = message; }

        public DataSet SelectFeedback()
        {
            query = "SELECT * FROM FEEDBACK ORDER BY feedback_date DESC";
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, "FEEDBACK");

            conn.Close();
            return ds;
        }

        public DataSet SearchFeedback(string text)
        {
            query = "SELECT * FROM FEEDBACK WHERE name LIKE '%" + text + "%' OR phone LIKE '%" + text + "%' OR feedback LIKE '%" + text + "%' ORDER BY feedback_date DESC";
            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = query;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sda.Fill(ds, "FEEDBACK");

            conn.Close();
            return ds;
        }

        public bool InsertFeedback()
        {
            if (name.Length > 30)
            {
                name = name.Substring(0, 30);
            }
            if(phone.Length > 13)
            {
                phone = phone.Substring(0, 13);
            }

            result = false;
            try
            {
                query = "INSERT INTO FEEDBACK VALUES ('" + name + "','" + phone + "','" + message + "',GETDATE())";
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

        public bool DeleteFeedback()
        {
            result = false;
            try
            {
                query = "DELETE FROM FEEDBACK WHERE id_feedback = '" + id + "'";
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
