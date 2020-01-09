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
    /// Interaction logic for DataFeedbackPage.xaml
    /// </summary>
    public partial class DataFeedbackPage : Page
    {
        private Controller.DataFeedbackControl FeedControl;

        public DataFeedbackPage()
        {
            InitializeComponent();
            FeedControl = new Controller.DataFeedbackControl(this);
            FeedControl.SelectFeedback();
        }

        private void btnLihat_Click(object sender, RoutedEventArgs e)
        {
            System.Data.DataRow dr = ((System.Data.DataRowView)(dgFeedBack.SelectedValue)).Row;
            MessageBox.Show(dr["feedback_date"].ToString() + "\n\nNama\t: " + dr["name"].ToString() + "\nHP\t: " + dr["phone"].ToString() + "\n\n" + dr["feedback"].ToString(), "Lihat Pesan");
        }

        private void btnHapus_Click(object sender, RoutedEventArgs e)
        {
            System.Data.DataRow dr = ((System.Data.DataRowView)(dgFeedBack.SelectedValue)).Row;
            MessageBoxResult mbr = MessageBox.Show("Apakah anda yakin menghapus pesan dari " + dr["name"] + " ?", "Hapus Pesan", MessageBoxButton.YesNo);
            if (mbr == MessageBoxResult.Yes)
            {
                if (FeedControl.DeleteFeedback())
                {
                    MessageBox.Show("Pesan berhasil dihapus");
                    FeedControl.SelectFeedback();
                    dgFeedBack.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Terdapat Kesalahan. Pesan gagal dihapus");
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
            FeedControl.SearchFeedback();
            dgFeedBack.SelectedIndex = 0;
        }

        private void dgFeedBack_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
    }
}
