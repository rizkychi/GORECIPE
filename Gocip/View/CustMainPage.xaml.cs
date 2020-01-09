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
    /// Interaction logic for CustMainPage.xaml
    /// </summary>
    public partial class CustMainPage : Window
    {
        public CustMainPage()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            WindowState = WindowState.Maximized;
        }

        private void lblBeranda_MouseDown(object sender, MouseButtonEventArgs e)
        {
            frame.Navigate(new View.CustHomePage());
        }

        private void lblKategori_MouseDown(object sender, MouseButtonEventArgs e)
        {
            frame.Navigate(new View.CustCategoryPage());
        }

        private void lblMenuPopuler_MouseDown(object sender, MouseButtonEventArgs e)
        {
            frame.Navigate(new View.CustPopularPage());
        }

        private void frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            myscroll.ScrollToTop();
        }

        private void lblContact_MouseDown(object sender, MouseButtonEventArgs e)
        {
            frame.Navigate(new View.CustRequestPage());
        }

        private void btnSearch_MouseDown(object sender, MouseButtonEventArgs e)
        {
            frame.Navigate(new View.CustSearchRecipe());
        }

        private void btnSearch_MouseEnter(object sender, MouseEventArgs e)
        {
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.Opacity = 0.75;
        }

        private void btnSearch_MouseLeave(object sender, MouseEventArgs e)
        {
            btnSearch.Opacity = 1;
        }

        private void btnExit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.Show();
            this.Close();
        }

        private void btnExit_MouseEnter(object sender, MouseEventArgs e)
        {
            btnExit.Cursor = Cursors.Hand;
            btnExit.Opacity = 0.75;
        }

        private void btnExit_MouseLeave(object sender, MouseEventArgs e)
        {
            btnExit.Opacity = 1;
        }
    }
}
