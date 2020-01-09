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
    /// Interaction logic for DataKategoriPage.xaml
    /// </summary>
    public partial class DataKategoriPage : Page
    {
        private Controller.KategoriControl CatControl;
        private bool update;

        public DataKategoriPage()
        {
            InitializeComponent();
            CatControl = new Controller.KategoriControl(this);
            aturInput();
            update = false;
        }

        private void aturInput()
        {
            txtCategoryMain.IsEnabled = false;
            txtCategoryName.IsEnabled = false;
            btnCancel.Visibility = Visibility.Hidden;
            btnSimpan.Visibility = Visibility.Hidden;
            btnHapus.IsEnabled = true;
            btnTambah.IsEnabled = true;
            btnUbah.IsEnabled = true;
            CatControl.SelectCategory();
            dgKategori.SelectedIndex = 0;
        }

        private void btnHapus_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr =  MessageBox.Show("PERHATIAN!\nJika anda menghapus kategori ini maka kategori yang berkaitan di daftar resep juga akan terhapus.\n\n Apakah anda yakin menghapus kategori " + txtCategoryName.Text + " ?", "Hapus Kategori", MessageBoxButton.YesNo);
            if (mbr == MessageBoxResult.Yes)
            {
                if (CatControl.DeleteCategory())
                {
                    MessageBox.Show("Kategori berhasil dihapus");
                    CatControl.SelectCategory();
                    dgKategori.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Terdapat Kesalahan. Kategori gagal dihapus");
                }
            }
        }

        private void btnSimpan_Click(object sender, RoutedEventArgs e)
        {
            if (txtCategoryName.Text == "")
            {
                MessageBox.Show("Nama kategori tidak boleh kosong");
            }
            else
            {
                if (update == true)
                {
                    if (CatControl.UpdateCategory())
                    {
                        MessageBox.Show("Kategori berhasil diubah");
                        aturInput();
                        update = false;
                    }
                    else
                    {
                        MessageBox.Show("Terdapat kesalahan. Kategori gagal diubah");
                    }
                }
                else
                {
                    if (CatControl.InsertCategory())
                    {
                        MessageBox.Show("Kategori berhasil ditambahkan");
                        aturInput();
                        dgKategori.SelectedIndex = dgKategori.Items.Count - 1;
                    }
                    else
                    {
                        MessageBox.Show("Terdapat kesalahan. Kategori gagal Ditambahkan");
                    }
                }
            }
        }

        private void btnTambah_Click(object sender, RoutedEventArgs e)
        {
            dgKategori.SelectedIndex = -1;
            txtCategoryMain.IsEnabled = true;
            txtCategoryName.IsEnabled = true;
            txtCategoryMain.SelectedIndex = 0;
            btnCancel.Visibility = Visibility.Visible;
            btnSimpan.Visibility = Visibility.Visible;
            btnUbah.IsEnabled = false;
            btnHapus.IsEnabled = false;
            btnTambah.IsEnabled = false;
        }

        private void btnUbah_Click(object sender, RoutedEventArgs e)
        {
            txtCategoryMain.IsEnabled = true;
            txtCategoryName.IsEnabled = true;
            btnCancel.Visibility = Visibility.Visible;
            btnSimpan.Visibility = Visibility.Visible;
            btnUbah.IsEnabled = false;
            btnHapus.IsEnabled = false;
            btnTambah.IsEnabled = false;
            update = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtCategoryName.Text = "";
            aturInput();
            dgKategori.SelectedIndex = 0;
        }

        private void dgKategori_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void txtSearch_OnKeyDown(object sender, KeyEventArgs e)
        {
            CatControl.SearchCategory();
            dgKategori.SelectedIndex = 0;
        }

        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text == "Cari")
            {
                txtSearch.Text = "";
            }
        }
    }
}
