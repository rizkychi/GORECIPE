using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gocip
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller.LoginControl ControlLogin;
        private Controller.DataPollingControl PollControl;

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            WindowState = WindowState.Maximized;
            txtUsername.Focus();
            ControlLogin = new Controller.LoginControl(this);
            PollControl = new Controller.DataPollingControl(this);
        }

        private void btnLogin_Click_1(object sender, RoutedEventArgs e)
        {
            if (ControlLogin.LoginAdmin())
            {
                View.AdmMainPage MyView = new View.AdmMainPage();
                MyView.Show();
                MyView.lblUser.Content = ControlLogin.GetUser();
                this.Close();
            }
            else
            {
                MessageBox.Show("Maaf username/password salah");
                txtUsername.Text = passwordBox.Password = "";
                txtUsername.Focus();
            }
        }

        private void btnLogin2_Click(object sender, RoutedEventArgs e)
        {
            if (ControlLogin.LoginCustomer())
            {
                View.CustMainPage MyView = new View.CustMainPage();
                PollControl.SetPoll_Username(txtUsername2.Text);
                MyView.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Maaf username/password salah");
                txtUsername2.Text = passwordBox2.Password = "";
                txtUsername2.Focus();
            }
        }
    }
}
