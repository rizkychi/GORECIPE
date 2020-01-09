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
    /// Interaction logic for DataRecipePage.xaml
    /// </summary>
    public partial class DataRecipePage : Page
    {
        private Controller.DataRecipeControl RecipeControl;

        public DataRecipePage()
        {
            InitializeComponent();
            RecipeControl = new Controller.DataRecipeControl(this);
            RecipeControl.SelectRecipe();
        }

        private void btnTambah_Click(object sender, RoutedEventArgs e)
        {
            View.DataRecipeInsert ins = new View.DataRecipeInsert();
            NavigationService.Navigate(ins);
        }

        private void btnUbah_Click(object sender, RoutedEventArgs e)
        {
            System.Data.DataRow dr = ((System.Data.DataRowView)(dgRecipe.SelectedValue)).Row;
            View.DataRecipeInsert ins = new View.DataRecipeInsert(dr["name"].ToString(), 
                                                                dr["description"].ToString(), 
                                                                dr["picture"].ToString(),
                                                                dr["video"].ToString(),
                                                                dr["method"].ToString());

            RecipeControl.Update((int)dr[0]);
            ins.txtRecipe_ID.Text = dr[0].ToString();
            ins.dgBahan.ItemsSource = RecipeControl.SelectIngredient().Tables[0].DefaultView;
            ins.dgKategori.ItemsSource = RecipeControl.SelectCategory().Tables[0].DefaultView;

            NavigationService.Navigate(ins);
        }

        private void btnHapus_Click(object sender, RoutedEventArgs e)
        {
            System.Data.DataRow dr = ((System.Data.DataRowView)(dgRecipe.SelectedValue)).Row;
            MessageBoxResult mbr = MessageBox.Show("Apakah anda yakin menghapus resep " + dr["name"] + " ?", "Hapus Kategori", MessageBoxButton.YesNo);
            if (mbr == MessageBoxResult.Yes)
            {
                if (RecipeControl.DeleteRecipe())
                {
                    MessageBox.Show("Resep berhasil dihapus");
                    RecipeControl.SelectRecipe();
                    dgRecipe.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Terdapat Kesalahan. Resep gagal dihapus");
                }
            }
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
            RecipeControl.SearchRecipe();
            dgRecipe.SelectedIndex = 0;
        }

        private void dgRecipe_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
    }
}
