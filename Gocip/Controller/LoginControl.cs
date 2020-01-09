using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Gocip.Controller
{
    class LoginControl
    {
        private Model.LoginModel ModelLogin;
        private MainWindow ViewLogin;

        public LoginControl(MainWindow ViewLogin)
        {
            ModelLogin = new Model.LoginModel();
            this.ViewLogin = ViewLogin;
        }

        public bool LoginAdmin()
        {
            return ModelLogin.Login(ViewLogin.txtUsername.Text, ViewLogin.passwordBox.Password,1);
            //return ModelLogin.Login("admin", "gocip2018",1);
        }
        public bool LoginCustomer()
        {
            return ModelLogin.Login(ViewLogin.txtUsername2.Text, ViewLogin.passwordBox2.Password,2);
        }
        public string GetUser()
        {
            return ModelLogin.GetUser();
        }
    }
}
