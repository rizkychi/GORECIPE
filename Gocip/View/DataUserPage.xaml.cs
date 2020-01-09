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
using System.Windows.Shapes;

namespace Gocip.View
{
    /// <summary>
    /// Interaction logic for DataUserPage.xaml
    /// </summary>
    public partial class DataUserPage : Page
    {
        private Controller.DataUserControl control;
        private bool update;

        public DataUserPage()
        {
            InitializeComponent();
            control = new Controller.DataUserControl(this);
            control.SelectAdmin();
            control.SelectCustomer();
            aturInput();
        }

        private void aturInput()
        {
            txtUsernameAdmin.IsEnabled = false;
            txtPasswordAdmin.IsEnabled = false;
            txtUsernameCust.IsEnabled = false;
            txtPasswordCust.IsEnabled = false;
            btnCancelAdmin.Visibility = Visibility.Hidden;
            btnSimpanAdmin.Visibility = Visibility.Hidden;
            btnCancelCust.Visibility = Visibility.Hidden;
            btnSimpanCust.Visibility = Visibility.Hidden;
            btnHapusAdmin.IsEnabled = true;
            btnTambahAdmin.IsEnabled = true;
            btnUbahAdmin.IsEnabled = true;
            btnHapusCust.IsEnabled = true;
            btnTambahCust.IsEnabled = true;
            btnUbahCust.IsEnabled = true;
            control.SelectAdmin();
            control.SelectCustomer();
            dgAdmin.SelectedIndex = 0;
            dgCust.SelectedIndex = 0;
        }

        private void dgAdmin_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void dgCust_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void txtSearchAdmin_OnKeyDown(object sender, KeyEventArgs e)
        {
            control.SearchAdmin();
            dgAdmin.SelectedIndex = 0;
        }

        private void txtSearchCust_OnKeyDown(object sender, KeyEventArgs e)
        {
            control.SearchCustomer();
            dgCust.SelectedIndex = 0;
        }

        private void txtSearchAdmin_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearchAdmin.Text == "Cari")
            {
                txtSearchAdmin.Text = "";
            }
        }
        private void txtSearchCust_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearchCust.Text == "Cari")
            {
                txtSearchCust.Text = "";
            }
        }

        private void btnTambahAdmin_Click(object sender, RoutedEventArgs e)
        {
            dgAdmin.SelectedIndex = -1;
            txtUsernameAdmin.IsEnabled = true;
            txtPasswordAdmin.IsEnabled = true;
            btnCancelAdmin.Visibility = Visibility.Visible;
            btnSimpanAdmin.Visibility = Visibility.Visible;
            btnTambahAdmin.IsEnabled = false;
            btnUbahAdmin.IsEnabled = false;
            btnHapusAdmin.IsEnabled = false;
            btnTambahCust.IsEnabled = false;
            btnUbahCust.IsEnabled = false;
            btnHapusCust.IsEnabled = false;
        }

        private void btnTambahCust_Click(object sender, RoutedEventArgs e)
        {
            dgCust.SelectedIndex = -1;
            txtUsernameCust.IsEnabled = true;
            txtPasswordCust.IsEnabled = true;
            btnCancelCust.Visibility = Visibility.Visible;
            btnSimpanCust.Visibility = Visibility.Visible;
            btnTambahAdmin.IsEnabled = false;
            btnUbahAdmin.IsEnabled = false;
            btnHapusAdmin.IsEnabled = false;
            btnTambahCust.IsEnabled = false;
            btnUbahCust.IsEnabled = false;
            btnHapusCust.IsEnabled = false;
        }

        private void btnUbahAdmin_Click(object sender, RoutedEventArgs e)
        {
            txtUsernameAdmin.IsEnabled = true;
            txtPasswordAdmin.IsEnabled = true;
            btnCancelAdmin.Visibility = Visibility.Visible;
            btnSimpanAdmin.Visibility = Visibility.Visible;
            btnTambahAdmin.IsEnabled = false;
            btnUbahAdmin.IsEnabled = false;
            btnHapusAdmin.IsEnabled = false;
            btnTambahCust.IsEnabled = false;
            btnUbahCust.IsEnabled = false;
            btnHapusCust.IsEnabled = false;
            update = true;
            control.SetOldUserAdmin();
        }

        private void btnUbahCust_Click(object sender, RoutedEventArgs e)
        {
            txtUsernameCust.IsEnabled = true;
            txtPasswordCust.IsEnabled = true;
            btnCancelCust.Visibility = Visibility.Visible;
            btnSimpanCust.Visibility = Visibility.Visible;
            btnTambahAdmin.IsEnabled = false;
            btnUbahAdmin.IsEnabled = false;
            btnHapusAdmin.IsEnabled = false;
            btnTambahCust.IsEnabled = false;
            btnUbahCust.IsEnabled = false;
            btnHapusCust.IsEnabled = false;
            update = true;
            control.SetOldUserCust();
        }

        private void btnHapusAdmin_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("Apakah anda yakin menghapus user " + txtUsernameAdmin.Text + " ?", "Hapus User", MessageBoxButton.YesNo);
            if (mbr == MessageBoxResult.Yes)
            {
                if (control.DeleteAdmin())
                {
                    MessageBox.Show("User berhasil dihapus");
                    aturInput();
                }
                else
                {
                    MessageBox.Show("Terdapat Kesalahan. User gagal dihapus");
                }
            }
        }

        private void btnHapusCust_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("Apakah anda yakin menghapus user " + txtUsernameCust.Text + " ?", "Hapus User", MessageBoxButton.YesNo);
            if (mbr == MessageBoxResult.Yes)
            {
                if (control.DeleteCustomer())
                {
                    MessageBox.Show("User berhasil dihapus");
                    aturInput();
                }
                else
                {
                    MessageBox.Show("Terdapat Kesalahan. User gagal dihapus");
                }
            }
        }

        private void btnSimpanAdmin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsernameAdmin.Text == "" || txtPasswordAdmin.Text == "")
            {
                MessageBox.Show("Username/password tidak boleh kosong");
            }
            else
            {
                if (update == true)
                {
                    if (control.UpdateAdmin())
                    {
                        MessageBox.Show("User berhasil diubah");
                        aturInput();
                        update = false;
                    }
                    else
                    {
                        MessageBox.Show("Terdapat kesalahan. User gagal diubah");
                    }
                }
                else
                {
                    if (control.InsertAdmin())
                    {
                        MessageBox.Show("User berhasil ditambahkan");
                        aturInput();
                        dgAdmin.SelectedIndex = dgAdmin.Items.Count - 1;
                    }
                    else
                    {
                        MessageBox.Show("Terdapat kesalahan. User gagal Ditambahkan");
                    }
                }
            }
        }

        private void btnSimpanCust_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsernameCust.Text == "" || txtPasswordCust.Text == "")
            {
                MessageBox.Show("Username/password tidak boleh kosong");
            }
            else
            {
                if (update == true)
                {
                    if (control.UpdateCustomer())
                    {
                        MessageBox.Show("User berhasil diubah");
                        aturInput();
                        update = false;
                    }
                    else
                    {
                        MessageBox.Show("Terdapat kesalahan. User gagal diubah");
                    }
                }
                else
                {
                    if (control.InsertCustomer())
                    {
                        MessageBox.Show("User berhasil ditambahkan");
                        aturInput();
                        dgAdmin.SelectedIndex = dgAdmin.Items.Count - 1;
                    }
                    else
                    {
                        MessageBox.Show("Terdapat kesalahan. User gagal Ditambahkan");
                    }
                }
            }
        }

        private void btnCancelAdmin_Click(object sender, RoutedEventArgs e)
        {
            txtUsernameAdmin.Text = "";
            txtPasswordAdmin.Text = "";
            aturInput();
            dgAdmin.SelectedIndex = 0;
        }

        private void btnCancelCust_Click(object sender, RoutedEventArgs e)
        {
            txtUsernameCust.Text = "";
            txtPasswordCust.Text = "";
            aturInput();
            dgCust.SelectedIndex = 0;
        }
    }
}
