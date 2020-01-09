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

namespace Gocip.View
{
    /// <summary>
    /// Interaction logic for DataIngredientPage.xaml
    /// </summary>
    public partial class DataIngredientPage : Page
    {
        private Controller.DataIngredientControl IngControl;
        private bool update;

        public DataIngredientPage()
        {
            InitializeComponent();
            IngControl = new Controller.DataIngredientControl(this);
            aturInput();
            update = false;
        }

        private void aturInput()
        {
            txtIngredientName.IsEnabled = false;
            txtPrice.IsEnabled = false;
            txtUnit.IsEnabled = false;
            btnCancel.Visibility = Visibility.Hidden;
            btnSimpan.Visibility = Visibility.Hidden;
            btnHapus.IsEnabled = true;
            btnTambah.IsEnabled = true;
            btnUbah.IsEnabled = true;
            IngControl.SelectIngredient();
            dgBahan.SelectedIndex = 0;
        }

        private void btnTambah_Click(object sender, RoutedEventArgs e)
        {
            dgBahan.SelectedIndex = -1;
            txtIngredientName.IsEnabled = true;
            txtPrice.IsEnabled = true;
            txtUnit.IsEnabled = true;
            txtUnit.SelectedIndex = 0;
            btnCancel.Visibility = Visibility.Visible;
            btnSimpan.Visibility = Visibility.Visible;
            btnUbah.IsEnabled = false;
            btnHapus.IsEnabled = false;
            btnTambah.IsEnabled = false;
        }

        private void btnUbah_Click(object sender, RoutedEventArgs e)
        {
            txtIngredientName.IsEnabled = true;
            txtPrice.IsEnabled = true;
            txtUnit.IsEnabled = true;
            btnCancel.Visibility = Visibility.Visible;
            btnSimpan.Visibility = Visibility.Visible;
            btnUbah.IsEnabled = false;
            btnHapus.IsEnabled = false;
            btnTambah.IsEnabled = false;
            update = true;
        }

        private void btnHapus_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("PERHATIAN!\nJika anda menghapus bahan ini maka bahan yang berkaitan di daftar resep juga akan terhapus.\n\nApakah anda yakin menghapus bahan " + txtIngredientName.Text + " ?", "Hapus Bahan", MessageBoxButton.YesNo);
            if (mbr == MessageBoxResult.Yes)
            {
                if (IngControl.DeleteIngredient())
                {
                    MessageBox.Show("Bahan berhasil dihapus");
                    IngControl.SelectIngredient();
                    dgBahan.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Terdapat Kesalahan. Bahan gagal dihapus");
                }
            }
        }

        private void btnSimpan_Click(object sender, RoutedEventArgs e)
        {
            if (txtIngredientName.Text == "")
            {
                MessageBox.Show("Nama bahan tidak boleh kosong");
            }
            else if (txtPrice.Text == "")
            {
                MessageBox.Show("Harga bahan tidak boleh kosong");
            }
            else
            {
                if (update == true)
                {
                    if (IngControl.UpdateIngredient())
                    {
                        MessageBox.Show("Bahan berhasil diubah");
                        aturInput();
                        update = false;
                    }
                    else
                    {
                        MessageBox.Show("Terdapat kesalahan. Bahan gagal diubah");
                    }
                }
                else
                {
                    if (IngControl.InsertIngredient())
                    {
                        MessageBox.Show("Bahan berhasil ditambahkan");
                        aturInput();
                        dgBahan.SelectedIndex = dgBahan.Items.Count - 1;
                    }
                    else
                    {
                        MessageBox.Show("Terdapat kesalahan. Bahan gagal Ditambahkan");
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtIngredientName.Text = "";
            txtPrice.Text = "";
            aturInput();
            dgBahan.SelectedIndex = 0;
        }

        private void dgBahan_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text == "Cari")
            {
                txtSearch.Text = "";
            }
        }

        private void txtSearch_OnKeyDown(object sender, KeyEventArgs e)
        {
            IngControl.SearchIngredient();
            dgBahan.SelectedIndex = 0;
        }
    }
}
