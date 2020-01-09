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
using Microsoft.Win32;

namespace Gocip.View
{
    /// <summary>
    /// Interaction logic for DataRecipeInsert.xaml
    /// </summary>
    public partial class DataRecipeInsert : Page
    {
        private Controller.DataRecipeControl RecipeControl;

        public DataRecipeInsert()
        {
            InitializeComponent();
            btnSimpan_Tambah.Visibility = Visibility.Visible;
            RecipeControl = new Controller.DataRecipeControl(this);
            RecipeControl.IngredientToCombobox();
            dgBahan.ItemsSource = RecipeControl.SelectIngredient().Tables[0].DefaultView;
            dgKategori.ItemsSource = RecipeControl.SelectCategory().Tables[0].DefaultView;
        }

        public DataRecipeInsert(string title, string desc, string pict, string vid, string method)
        {
            InitializeComponent();
            btnSimpan_Ubah.Visibility = Visibility.Visible;
            RecipeControl = new Controller.DataRecipeControl(this);
            RecipeControl.IngredientToCombobox();
            lblJudul.Content = "Ubah Resep";
            txtRecipeName.Text = title;
            txtDeskripsi.Document.Blocks.Clear();
            txtCaraMasak.Document.Blocks.Clear();
            txtDeskripsi.Document.Blocks.Add(new Paragraph(new Run(desc)));
            txtCaraMasak.Document.Blocks.Add(new Paragraph(new Run(method)));
            txtVideo.Text = vid;
            lblImgPath.Content = pict;
            if (pict != "")
            {
                lblImgUploadName.Content = lblImgPath.Content.ToString().Substring(13, lblImgPath.Content.ToString().Length - 13);
            }
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            string date = DateTime.Now.ToString("yyyyMMdd_HHmm_");
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {

                /*if (lblImgPath.Content.ToString() != "" && System.IO.File.Exists(Environment.CurrentDirectory + "/" + lblImgPath.Content.ToString()) == true)
                {
                    System.IO.File.Delete(Environment.CurrentDirectory + "/" + lblImgPath.Content.ToString());
                    lblImgPath.Content = "";
                }*/

                var fileNameToSave = op.FileName;
                var imagePath = @"Image/Recipe/" + date + op.SafeFileName;
                lblImgUploadName.Content = op.SafeFileName;
                lblImgPath.Content = imagePath;
                System.IO.File.Copy(fileNameToSave, imagePath, true);


               /* BitmapImage image = new BitmapImage();
                var path = Environment.CurrentDirectory + "/" + imagePath;
                image.BeginInit();
                image.UriSource = new Uri(path);
                image.EndInit();
                lblimage.Source = image;
                lblimage.Stretch = Stretch.Fill;*/
            }
        }

        private void txtJumlah_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtJumlah.Text == "Jumlah")
            {
                txtJumlah.Text = "0";
            }
        }

        private void txtJumlah_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtJumlah.Text == "" || txtJumlah.Text == "0")
            {
                txtJumlah.Text = "Jumlah";
            }
        }

        private void cmbBahan_LostFocus(object sender, RoutedEventArgs e)
        {
            cmbPrice.SelectedIndex = cmbBahan.SelectedIndex;
            cmbUnit.SelectedIndex = cmbBahan.SelectedIndex;
        }

        private void btnTambahBahan_Click(object sender, RoutedEventArgs e)
        {
            if (cmbBahan.SelectedValue == null)
            {
                MessageBox.Show("Pilih Bahan terlebih dahulu");
            }
            else if(cmbSatuan.SelectedValue == null)
            {
                MessageBox.Show("Pilih Satuan terlebih dahulu");
            }
            else
            {
                if (RecipeControl.InsertIngredient())
                {
                    dgBahan.SelectedIndex = dgBahan.Items.Count - 1;
                }
                else
                {
                    MessageBox.Show("Bahan sudah ditambahkan");
                }
            }
        }

        private void btnHapusBahan_Click(object sender, RoutedEventArgs e)
        {
            if (dgBahan.SelectedIndex < 0)
            {
                MessageBox.Show("Tidak ada data bahan");
            }
            else
            {
                MessageBoxResult mbr = MessageBox.Show("Apakah anda yakin menghapus bahan ini?", "Hapus Bahan", MessageBoxButton.YesNo);
                if (mbr == MessageBoxResult.Yes)
                {
                    if (RecipeControl.DeleteIngredient())
                    {
                        dgBahan.SelectedIndex = dgBahan.Items.Count - 1;
                        MessageBox.Show("Bahan berhasil dihapus");
                    }
                    else
                    {
                        MessageBox.Show("Terdapat Kesalahan. Bahan gagal dihapus");
                    }
                }
            }
        }

        private void cmbKategoriUtama_LostFocus(object sender, RoutedEventArgs e)
        {
            RecipeControl.CategoryToCombobox();
            cmbKategori.Text = "- Nama Kategori -";
        }

        private void btnTambahKategori_Click(object sender, RoutedEventArgs e)
        {
            if (cmbKategori.SelectedValue == null)
            {
                MessageBox.Show("Pilih Kategori terlebih dahulu");
            }
            else
            {
                if (RecipeControl.InsertCategory())
                {
                    //RecipeControl.SelectCategory();
                    dgKategori.SelectedIndex = dgKategori.Items.Count - 1;
                }
                else
                {
                    MessageBox.Show("Kategori sudah ditambahkan");
                }
            }
        }

        private void btnHapusKategori_Click(object sender, RoutedEventArgs e)
        {
            if (dgKategori.SelectedIndex < 0)
            {
                MessageBox.Show("Tidak ada data kategori");
            }
            else
            {
                MessageBoxResult mbr = MessageBox.Show("Apakah anda yakin menghapus kategori ini?", "Hapus Kategori", MessageBoxButton.YesNo);
                if (mbr == MessageBoxResult.Yes)
                {
                    if (RecipeControl.DeleteCategory())
                    {
                        dgKategori.SelectedIndex = dgKategori.Items.Count - 1;
                        MessageBox.Show("Kategori berhasil dihapus");
                    }
                    else
                    {
                        MessageBox.Show("Terdapat Kesalahan. Kategori gagal dihapus");
                    }
                }
            }
        }

        private void dgKategori_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void txtRecipeName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtRecipeName.Text == "Masukkan nama resep")
            {
                txtRecipeName.Text = "";
            }
        }

        private void txtDeskripsi_GotFocus(object sender, RoutedEventArgs e)
        {
            string desc = new TextRange(txtDeskripsi.Document.ContentStart, txtDeskripsi.Document.ContentEnd).Text;
            desc = desc.Substring(0, desc.Length - 2);
            if (desc == "Deskripsi resep. (maks 300 karakter)")
            {
                txtDeskripsi.Document.Blocks.Clear();
                txtDeskripsi.Document.Blocks.Add(new Paragraph(new Run("")));
            }
        }

        private void txtCaraMasak_GotFocus(object sender, RoutedEventArgs e)
        {
            string method = new TextRange(txtCaraMasak.Document.ContentStart, txtCaraMasak.Document.ContentEnd).Text;
            method = method.Substring(0, method.Length - 2);
            if (method == "Langkah - langkah memasak. (Pisahkan tiap langkah dengan Enter)")
            {
                txtCaraMasak.Document.Blocks.Clear();
                txtCaraMasak.Document.Blocks.Add(new Paragraph(new Run("")));
            }
        }

        private void btnBatal_Click(object sender, RoutedEventArgs e)
        {
            if (lblImgPath.Content.ToString() != "")
            {
                System.IO.File.Delete(Environment.CurrentDirectory + "/" + lblImgPath.Content.ToString());
                lblImgPath.Content = "";
            }
            View.DataRecipePage recipe = new View.DataRecipePage();
            NavigationService.Navigate(recipe);
        }

        private void txtVideo_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtVideo.Text == "Masukkan link video")
            {
                txtVideo.Text = "http://";
            }
            txtVideo.SelectionStart = txtVideo.Text.Length;
            txtVideo.SelectionLength = 0; 
        }

        private void btnSimpan_Tambah_Click(object sender, RoutedEventArgs e)
        {
            if (cmbSatuan.Text == "secukupnya")
            {
                txtJumlah.Text = "0";
                txtJumlah.IsEnabled = false;
            }
            else
            {
                txtJumlah.IsEnabled = true;
            }

            mydesc.Content = new TextRange(txtDeskripsi.Document.ContentStart, txtDeskripsi.Document.ContentEnd).Text;
            mymethod.Content = new TextRange(txtCaraMasak.Document.ContentStart, txtCaraMasak.Document.ContentEnd).Text;

            string desc = mydesc.Content.ToString().Substring(0, mydesc.Content.ToString().Length - 2);
            string method = mymethod.Content.ToString().Substring(0, mymethod.Content.ToString().Length - 2);

            mydesc.Content = desc;
            mymethod.Content = method;

            if (txtRecipeName.Text == "" || txtRecipeName.Text == "Masukkan nama resep")
            {
                MessageBox.Show("Isikan nama resep terlebih dahulu");
            }
            else if (desc == "" || desc == "Deskripsi resep. (maks 300 karakter)")
            {
                MessageBox.Show("Isikan deskripsi resep terlebih dahulu");
            }
            else if (dgBahan.SelectedIndex < 0)
            {
                MessageBox.Show("Isikan bahan resep terlebih dahulu");
            }
            else if (dgKategori.SelectedIndex < 0)
            {
                MessageBox.Show("Isikan kategori resep terlebih dahulu");
            }
            else if (method == "" || method == "Langkah - langkah memasak. (Pisahkan tiap langkah dengan Enter)")
            {
                MessageBox.Show("Isikan cara masak resep terlebih dahulu");
            }
            else
            {
                if (RecipeControl.InsertRecipe())
                {
                    MessageBox.Show("Resep berhasil ditambahkan");
                    View.DataRecipePage recipe = new View.DataRecipePage();
                    NavigationService.Navigate(recipe);
                }
                else
                {
                    MessageBox.Show("Terdapat kesalahan. Resep gagal ditambahkan");
                }
            }
        }

        private void btnSimpan_Ubah_Click(object sender, RoutedEventArgs e)
        {
            if (cmbSatuan.Text == "secukupnya")
            {
                txtJumlah.Text = "0";
                txtJumlah.IsEnabled = false;
            }
            else
            {
                txtJumlah.IsEnabled = true;
            }

            mydesc.Content = new TextRange(txtDeskripsi.Document.ContentStart, txtDeskripsi.Document.ContentEnd).Text;
            mymethod.Content = new TextRange(txtCaraMasak.Document.ContentStart, txtCaraMasak.Document.ContentEnd).Text;

            string desc = mydesc.Content.ToString().Substring(0, mydesc.Content.ToString().Length - 2);
            string method = mymethod.Content.ToString().Substring(0, mymethod.Content.ToString().Length - 2);

            mydesc.Content = desc;
            mymethod.Content = method;

            if (txtRecipeName.Text == "" || txtRecipeName.Text == "Masukkan nama resep")
            {
                MessageBox.Show("Isikan nama resep terlebih dahulu");
            }
            else if (desc == "" || desc == "Deskripsi resep. (maks 300 karakter)")
            {
                MessageBox.Show("Isikan deskripsi resep terlebih dahulu");
            }
            else if (dgBahan.SelectedIndex < 0)
            {
                MessageBox.Show("Isikan bahan resep terlebih dahulu");
            }
            else if (dgKategori.SelectedIndex < 0)
            {
                MessageBox.Show("Isikan kategori resep terlebih dahulu");
            }
            else if (method == "" || method == "Langkah - langkah memasak. (Pisahkan tiap langkah dengan Enter)")
            {
                MessageBox.Show("Isikan cara masak resep terlebih dahulu");
            }
            else
            {
                if (RecipeControl.UpdateRecipe())
                {
                    MessageBox.Show("Resep berhasil diubah");
                    View.DataRecipePage recipe = new View.DataRecipePage();
                    NavigationService.Navigate(recipe);
                }
                else
                {
                    MessageBox.Show("Terdapat kesalahan. Resep gagal diubah");
                }
            }
        }

        private void cmbSatuan_LostFocus(object sender, RoutedEventArgs e)
        {
            if (cmbSatuan.Text == "secukupnya")
            {
                txtJumlah.Text = "0";
                txtJumlah.IsEnabled = false;
            }
            else
            {
                txtJumlah.IsEnabled = true;
            }
        }
    }
}
