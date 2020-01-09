using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Gocip.Controller
{
    class DataUserControl
    {
        private Model.DataUserModel ModelDataUser;
        private View.DataUserPage ViewDataUser;

        public DataUserControl(View.DataUserPage ViewDataUser)
        {
            this.ViewDataUser = ViewDataUser;
            ModelDataUser = new Model.DataUserModel();
        }

        public void SetOldUserAdmin()
        {
            DataRow dr = ((System.Data.DataRowView)(ViewDataUser.dgAdmin.SelectedValue)).Row;
            ModelDataUser.SetOldUser(dr[0].ToString());
        }
        public void SetOldUserCust()
        {
            DataRow dr = ((System.Data.DataRowView)(ViewDataUser.dgCust.SelectedValue)).Row;
            ModelDataUser.SetOldUser(dr[0].ToString());
        }

        public void SelectAdmin()
        {
            DataSet data = ModelDataUser.SelectUser(1);
            ViewDataUser.dgAdmin.ItemsSource = data.Tables[0].DefaultView;
        }

        public bool InsertAdmin()
        {
            ModelDataUser.SetUser(ViewDataUser.txtUsernameAdmin.Text);
            ModelDataUser.SetPassword(ViewDataUser.txtPasswordAdmin.Text);

            bool hasil = ModelDataUser.InsertUser(1);
            return hasil;
        }
        public bool UpdateAdmin()
        {
            ModelDataUser.SetUser(ViewDataUser.txtUsernameAdmin.Text);
            ModelDataUser.SetPassword(ViewDataUser.txtPasswordAdmin.Text);
            return ModelDataUser.UpdateUser(1);
        }
        public bool DeleteAdmin()
        {
            ModelDataUser.SetUser(ViewDataUser.txtUsernameAdmin.Text);

            bool hasil = ModelDataUser.DeleteUser(1);
            return hasil;
        }
        public void SearchAdmin()
        {
            DataSet ds = ModelDataUser.SearchUser(1, ViewDataUser.txtSearchAdmin.Text);
            ViewDataUser.dgAdmin.ItemsSource = ds.Tables[0].DefaultView;
        }

        public void SelectCustomer()
        {
            DataSet data = ModelDataUser.SelectUser(2);
            ViewDataUser.dgCust.ItemsSource = data.Tables[0].DefaultView;
        }

        public bool InsertCustomer()
        {
            ModelDataUser.SetUser(ViewDataUser.txtUsernameCust.Text);
            ModelDataUser.SetPassword(ViewDataUser.txtPasswordCust.Text);

            bool hasil = ModelDataUser.InsertUser(2);
            return hasil;
        }
        public bool UpdateCustomer()
        {
            ModelDataUser.SetUser(ViewDataUser.txtUsernameCust.Text);
            ModelDataUser.SetPassword(ViewDataUser.txtPasswordCust.Text);
            return ModelDataUser.UpdateUser(2);
        }
        public bool DeleteCustomer()
        {
            ModelDataUser.SetUser(ViewDataUser.txtUsernameCust.Text);

            bool hasil = ModelDataUser.DeleteUser(2);
            return hasil;
        }
        public void SearchCustomer()
        {
            DataSet ds = ModelDataUser.SearchUser(2,ViewDataUser.txtSearchCust.Text);
            ViewDataUser.dgCust.ItemsSource = ds.Tables[0].DefaultView;
        }
    }
}
