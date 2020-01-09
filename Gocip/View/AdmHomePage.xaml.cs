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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private Controller.MainControl MainControl;

        public HomePage()
        {
            InitializeComponent();
            MainControl = new Controller.MainControl(this);
        }

        private void lblViews_MouseDown(object sender, MouseButtonEventArgs e)
        {
            View.DataRecipePage v = new DataRecipePage();
            NavigationService.Navigate(v);
        }

        private void lblFeed_MouseDown(object sender, MouseButtonEventArgs e)
        {
            View.DataFeedbackPage v = new DataFeedbackPage();
            NavigationService.Navigate(v);
        }

        private void lblUser_MouseDown(object sender, MouseButtonEventArgs e)
        {
            View.DataUserPage v = new DataUserPage();
            NavigationService.Navigate(v);
        }

        private void lblRecipe_MouseDown(object sender, MouseButtonEventArgs e)
        {
            View.DataRecipePage v = new DataRecipePage();
            NavigationService.Navigate(v);
        }

        private void lblIng_MouseDown(object sender, MouseButtonEventArgs e)
        {
            View.DataIngredientPage v = new DataIngredientPage();
            NavigationService.Navigate(v);
        }

        private void lblCat_MouseDown(object sender, MouseButtonEventArgs e)
        {
            View.DataKategoriPage v = new DataKategoriPage();
            NavigationService.Navigate(v);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MainControl.SelectAll();
        }

        private void btnTambah_Slider_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnHapus_Slider_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTambah_ROTD_Click(object sender, RoutedEventArgs e)
        {
            if (cmbROTD.SelectedIndex < 0)
            {
                MessageBox.Show("Pilih resep terlebih dahulu.");
            }
            else if (dgROTD.Items.Count > 1)
            {
                MessageBox.Show("Maksimal resep hari ini adalah dua.");
            }
            else
            {
                if (MainControl.InsertROTD() == true)
                {
                    MessageBox.Show("Resep telah ditambahkan");
                    cmbROTD.Text = "- Pilih Resep Masakan -";
                    MainControl.SelectROTD();
                    dgROTD.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Terdapat kesalahan. Resep gagal ditambahkan");
                }
            }
        }

        private void btnHapus_ROTD_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("Apakah anda yakin menghapus resep berikut dari Resep Hari Ini?", "Hapus Resep", MessageBoxButton.YesNo);
            if (mbr == MessageBoxResult.Yes)
            {
                if (MainControl.DeleteROID())
                {
                    MessageBox.Show("Resep berhasil dihapus");
                    MainControl.SelectROTD();
                    dgROTD.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Terdapat Kesalahan. Resep gagal dihapus");
                }
            }
        }

        private void dgSlider_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void dgROTD_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void cmbROTD_LostFocus(object sender, RoutedEventArgs e)
        {
            if (cmbROTD.Text == "")
            {
                cmbROTD.Text = "- Pilih Resep Masakan -";
            }
        }

        private void cmbROTD_GotFocus(object sender, RoutedEventArgs e)
        {
            if (cmbROTD.Text == "- Pilih Resep Masakan -")
            {
                cmbROTD.Text = "";
            }
        }
    }
}
