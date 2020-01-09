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
    /// Interaction logic for AdmMainPage.xaml
    /// </summary>
    public partial class AdmMainPage : Window
    {
        public AdmMainPage()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            WindowState = WindowState.Maximized;
            lblBreadcrumb.Content = "";
        }

        private void Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.Show();
            this.Close();
        }

        private void lblBeranda_MouseDown(object sender, MouseButtonEventArgs e)
        {
            frame.Navigate(new View.HomePage());
            lblBreadcrumb.Content = "";
        }

        private void lblDataUser_MouseDown(object sender, MouseButtonEventArgs e)
        {
            frame.Navigate(new View.DataUserPage());
            lblBreadcrumb.Content = "Data User";
        }

        private void lblKategori_MouseDown(object sender, MouseButtonEventArgs e)
        {
            frame.Navigate(new View.DataKategoriPage());
            lblBreadcrumb.Content = "Kategori";
        }

        private void lblResep_MouseDown(object sender, MouseButtonEventArgs e)
        {
            frame.Navigate(new View.DataRecipePage());
            lblBreadcrumb.Content = "Resep";
        }

        private void lblBahan_MouseDown(object sender, MouseButtonEventArgs e)
        {
            frame.Navigate(new View.DataIngredientPage());
            lblBreadcrumb.Content = "Bahan";
        }

        private void frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            myscroll.ScrollToTop();
        }

        private void lblFeedback_MouseDown(object sender, MouseButtonEventArgs e)
        {
            frame.Navigate(new View.DataFeedbackPage());
            lblBreadcrumb.Content = "Pesan";
        }

        private void Exit_MouseEnter(object sender, MouseEventArgs e)
        {
            Exit.Cursor = Cursors.Hand;
            Exit.Opacity = 0.75;
        }

        private void Exit_MouseLeave(object sender, MouseEventArgs e)
        {
            Exit.Opacity = 1;
        }
    }
}
