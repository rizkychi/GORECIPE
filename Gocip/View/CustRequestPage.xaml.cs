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
using System.Text.RegularExpressions;

namespace Gocip.View
{
    /// <summary>
    /// Interaction logic for CustRequestPage.xaml
    /// </summary>
    public partial class CustRequestPage : Page
    {
        private Controller.DataFeedbackControl ReqControl;

        public CustRequestPage()
        {
            InitializeComponent();
            ReqControl = new Controller.DataFeedbackControl(this);
        }

        private void txtNama_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtNama.Text == "Nama Lengkap")
            {
                txtNama.Text = "";
            }
        }

        private void txtNama_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtNama.Text == "")
            {
                txtNama.Text = "Nama Lengkap";
            }
        }

        private void PhoneNumber(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtPhone_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtPhone.Text == "Nomor Telepon")
            {
                txtPhone.Text = "";
            }
        }

        private void txtPhone_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtPhone.Text == "")
            {
                txtPhone.Text = "Nomor Telepon";
            }
        }

        private void txtPesan_GotFocus(object sender, RoutedEventArgs e)
        {
            string desc = new TextRange(txtPesan.Document.ContentStart, txtPesan.Document.ContentEnd).Text;
            desc = desc.Substring(0, desc.Length - 2);
            if (desc == "Kritik dan Saran")
            {
                txtPesan.Document.Blocks.Clear();
                txtPesan.Document.Blocks.Add(new Paragraph(new Run("")));
            }
        }

        private void txtPesan_LostFocus(object sender, RoutedEventArgs e)
        {
            string desc = new TextRange(txtPesan.Document.ContentStart, txtPesan.Document.ContentEnd).Text;
            desc = desc.Substring(0, desc.Length - 2);
            if (desc == "")
            {
                txtPesan.Document.Blocks.Clear();
                txtPesan.Document.Blocks.Add(new Paragraph(new Run("Kritik dan Saran")));
            }
        }

        private void btnKirim_Click(object sender, RoutedEventArgs e)
        {
            string desc = new TextRange(txtPesan.Document.ContentStart, txtPesan.Document.ContentEnd).Text;
            desc = desc.Substring(0, desc.Length - 2);

            if (txtNama.Text == "" || txtNama.Text == "Nama Lengkap")
            {
                MessageBox.Show("Nama lengkap tidak boleh kosong");
            }
            else if (txtPhone.Text == "" || txtPhone.Text == "Nomor Telepon")
            {
                MessageBox.Show("Nomor telepon tidak boleh kosong");
            }
            else if (desc == "" || desc == "Kritik dan Saran")
            {
                MessageBox.Show("Kritik dan saran tidak boleh kosong");
            }
            else
            {
                if (ReqControl.InsertFeedback(desc) == true)
                {
                    MessageBox.Show("Kritik dan saran anda telah terkirim");
                    txtNama.Text = "Nama Lengkap";
                    txtPhone.Text = "Nomor Telepon";
                    txtPesan.Document.Blocks.Clear();
                    txtPesan.Document.Blocks.Add(new Paragraph(new Run("Kritik dan Saran")));
                }
                else
                {
                    MessageBox.Show("Terdapat kesalahan. Kritik dan saran anda tidak terkirim");
                }
            }
        }
    }
}
