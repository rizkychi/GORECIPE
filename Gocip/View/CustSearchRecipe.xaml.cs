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
    /// Interaction logic for CustSearchRecipe.xaml
    /// </summary>
    public partial class CustSearchRecipe : Page
    {
        private Controller.CustomerControl RecipeControl;

        public CustSearchRecipe()
        {
            InitializeComponent();
            RecipeControl = new Controller.CustomerControl(this);
        }


        DockPanel addItem(System.Data.DataRow dr)
        {
            DockPanel item = new DockPanel();
            item.Name = "ItemShow";
            item.Uid = dr["id_recipe"].ToString();
            item.Width = 240;
            item.Height = 270;
            item.HorizontalAlignment = HorizontalAlignment.Left;
            item.Margin = new Thickness(10, 10, 10, 10);
            item.Background = Brushes.White;

            BitmapImage bmp = new BitmapImage();
            var ImgPath = Environment.CurrentDirectory + "/" + dr["picture"].ToString();
            bmp.BeginInit();
            bmp.UriSource = new Uri(ImgPath);
            bmp.EndInit();

            Image Img = new Image();
            Img.Source = bmp;
            Img.Width = 230;
            Img.Height = 200;
            Img.VerticalAlignment = VerticalAlignment.Top;
            Img.Margin = new Thickness(5, 5, 5, 5);
            Img.Stretch = Stretch.Fill;

            DockPanel.SetDock(Img, Dock.Top);
            item.Children.Add(Img);

            TextBlock lbl = new TextBlock();
            lbl.Text = dr["name"].ToString();
            lbl.Foreground = Brushes.Black;
            lbl.Margin = new Thickness(5, -60, 5, 8);
            lbl.FontSize = 20;
            lbl.Width = 230;
            lbl.TextWrapping = TextWrapping.Wrap;
            lbl.FontWeight = FontWeights.SemiBold;
            lbl.TextAlignment = TextAlignment.Center;
            lbl.VerticalAlignment = VerticalAlignment.Center;

            DockPanel.SetDock(lbl, Dock.Bottom);
            item.Children.Add(lbl);

            Thickness t1 = new Thickness();
            Thickness t2 = new Thickness();
            t1.Top = -55; t2.Top = -425;
            t1.Right = 15; t2.Left = 15;

            Label price = addLabel(14, "Rp. " + dr["cost"].ToString(), "#8BC34A", t1, HorizontalAlignment.Right);
            Label love = addLabel(14, "\u2764 " + dr["polling"].ToString(), "#f44336", t2, HorizontalAlignment.Left);


            DockPanel.SetDock(price, Dock.Top);
            DockPanel.SetDock(love, Dock.Top);
            item.Children.Add(price);
            item.Children.Add(love);

            return item;
        }

        Label addLabel(int fontsize, string text, string color, Thickness t, HorizontalAlignment h)
        {
            Label l = new Label();
            l.Content = text;
            l.Name = "LabelItem";
            l.FontSize = fontsize;
            l.Padding = new Thickness(8, 3, 8, 3);
            l.Margin = t;
            l.Height = 2 * fontsize;
            l.FontWeight = FontWeights.Regular;
            l.Foreground = Brushes.White;
            l.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(color)); ;
            l.HorizontalAlignment = h;

            return l;
        }

        private void Dock_MouseDown(object sender, EventArgs e)
        {
            DockPanel cur = (DockPanel)sender;
            View.CustRecipeDetail detail = new View.CustRecipeDetail(cur.Uid.ToString());
            NavigationService.Navigate(detail);
        }

        private void Dock_MouseEnter(object sender, EventArgs e)
        {
            DockPanel cur = (DockPanel)sender;
            cur.Cursor = Cursors.Hand;
            cur.Opacity = 0.75;
        }

        private void Dock_MouseLeave(object sender, EventArgs e)
        {
            DockPanel cur = (DockPanel)sender;
            cur.Opacity = 1;
        }

        private void btnCari_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TileItem.Children.Clear();
            if (txtSearchBox.Text != "")
            {
                System.Data.DataSet ds = RecipeControl.ShowSearchRecipe();

                foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
                {
                    DockPanel dock = addItem(dr);
                    TileItem.Children.Add(dock);
                    dock.MouseDown += new MouseButtonEventHandler(this.Dock_MouseDown);
                    dock.MouseEnter += new MouseEventHandler(this.Dock_MouseEnter);
                    dock.MouseLeave += new MouseEventHandler(this.Dock_MouseLeave);
                }

                if (ds.Tables[0].Rows.Count != 0)
                {
                    lblNotFound.Visibility = Visibility.Hidden;
                }
                else
                {
                    lblNotFound.Visibility = Visibility.Visible;
                }
            }
            else
            {
                lblNotFound.Visibility = Visibility.Visible;
            }
        }

        private void btnCari_MouseEnter(object sender, MouseEventArgs e)
        {
            btnCari.Cursor = Cursors.Hand;
        }

        private void txtSearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearchBox.Text == "Cari Resep Disini") 
            {
                txtSearchBox.Text = "";
            }
        }

        private void txtSearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearchBox.Text == "")
            {
                txtSearchBox.Text = "Cari Resep Disini";
            }
        }

        private void txtSearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                btnCari_MouseDown(sender, new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left));
            }
        }
    }
}
