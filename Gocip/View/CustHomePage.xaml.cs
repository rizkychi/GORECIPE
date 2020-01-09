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
using System.Windows.Threading;
using System.Configuration;
using System.Windows.Media.Animation;

namespace Gocip.View
{
    /// <summary>
    /// Interaction logic for CustHomePage.xaml
    /// </summary>
    public partial class CustHomePage : Page
    {
        private Controller.CustomerControl RecipeControl;
        private DispatcherTimer timerImageChange;
        private Image[] ImageControls;
        private List<ImageSource> Images = new List<ImageSource>();
        private static string[] ValidImageExtensions = new[] { ".png", ".jpg", ".jpeg", ".bmp", ".gif" };
        private static string[] TransitionEffects = new[] { "Fade" };
        private string TransitionType, strImagePath = "";
        private int CurrentSourceIndex, CurrentCtrlIndex, EffectIndex = 0, IntervalTimer = 1;


        public CustHomePage()
        {
            InitializeComponent();
            RecipeControl = new Controller.CustomerControl(this);

            //Initialize Image control, Image directory path and Image timer.
            IntervalTimer = Convert.ToInt32(ConfigurationManager.AppSettings["IntervalTime"]);
            strImagePath = ConfigurationManager.AppSettings["ImagePath"];
            ImageControls = new[] { myImage, myImage2 };

            LoadImageFolder(strImagePath);

            timerImageChange = new DispatcherTimer();
            timerImageChange.Interval = new TimeSpan(0, 0, IntervalTimer);
            timerImageChange.Tick += new EventHandler(timerImageChange_Tick);
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
            l.Padding = new Thickness(8,3,8,3);
            l.Margin = t;
            l.Height = 2*fontsize;
            l.FontWeight = FontWeights.Regular;
            l.Foreground = Brushes.White;
            l.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(color)); ;
            l.HorizontalAlignment = h;

            return l;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TileItem.Children.Clear();
            PlaySlideShow();
            timerImageChange.IsEnabled = true;

            System.Data.DataSet ds = RecipeControl.ShowLatestRecipe();

            foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
            {
                DockPanel dock = addItem(dr);
                TileItem.Children.Add(dock);
                dock.MouseDown += new MouseButtonEventHandler(this.Dock_MouseDown);
                dock.MouseEnter += new MouseEventHandler(this.Dock_MouseEnter);
                dock.MouseLeave += new MouseEventHandler(this.Dock_MouseLeave);
            }

            RecipeControl.ShowRecipeOfTheDay();

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PlaySlideShow();
            timerImageChange.IsEnabled = true;
        }

        private void RecipeOTD_1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            View.CustRecipeDetail detail = new View.CustRecipeDetail(RecipeOTD_1.Uid.ToString());
            NavigationService.Navigate(detail);
        }

        private void RecipeOTD_2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            View.CustRecipeDetail detail = new View.CustRecipeDetail(RecipeOTD_2.Uid.ToString());
            NavigationService.Navigate(detail);
        }

        private void RecipeOTD_1_Name_MouseDown(object sender, MouseButtonEventArgs e)
        {
            View.CustRecipeDetail detail = new View.CustRecipeDetail(RecipeOTD_1.Uid.ToString());
            NavigationService.Navigate(detail);
        }

        private void RecipeOTD_2_Name_MouseDown(object sender, MouseButtonEventArgs e)
        {
            View.CustRecipeDetail detail = new View.CustRecipeDetail(RecipeOTD_2.Uid.ToString());
            NavigationService.Navigate(detail);
        }

        private void RecipeOTD_1_MouseEnter(object sender, MouseEventArgs e)
        {
            RecipeOTD_1.Cursor = Cursors.Hand;
            RecipeOTD_1_Name.Cursor = Cursors.Hand;
            RecipeOTD_1.Opacity = 0.75;
            RecipeOTD_1_Name.Opacity = 0.55;
        }

        private void RecipeOTD_2_MouseEnter(object sender, MouseEventArgs e)
        {
            RecipeOTD_2.Cursor = Cursors.Hand;
            RecipeOTD_2_Name.Cursor = Cursors.Hand;
            RecipeOTD_2.Opacity = 0.75;
            RecipeOTD_2_Name.Opacity = 0.55;
        }

        private void RecipeOTD_1_Name_MouseEnter(object sender, MouseEventArgs e)
        {
            RecipeOTD_1.Cursor = Cursors.Hand;
            RecipeOTD_1_Name.Cursor = Cursors.Hand;
            RecipeOTD_1.Opacity = 0.75;
            RecipeOTD_1_Name.Opacity = 0.55;

            
        }

        private void RecipeOTD_2_Name_MouseEnter(object sender, MouseEventArgs e)
        {
            RecipeOTD_2.Cursor = Cursors.Hand;
            RecipeOTD_2_Name.Cursor = Cursors.Hand;
            RecipeOTD_2.Opacity = 0.75;
            RecipeOTD_2_Name.Opacity = 0.55;
        }

        private void RecipeOTD_1_MouseLeave(object sender, MouseEventArgs e)
        {
            RecipeOTD_1.Opacity = 1;
            RecipeOTD_1_Name.Opacity = 0.8;
        }

        private void RecipeOTD_2_MouseLeave(object sender, MouseEventArgs e)
        {
            RecipeOTD_2.Opacity = 1;
            RecipeOTD_2_Name.Opacity = 0.8;
        }

        private void RecipeOTD_1_Name_MouseLeave(object sender, MouseEventArgs e)
        {
            RecipeOTD_1.Opacity = 1;
            RecipeOTD_1_Name.Opacity = 0.8;
        }

        private void RecipeOTD_2_Name_MouseLeave(object sender, MouseEventArgs e)
        {
            RecipeOTD_2.Opacity = 1;
            RecipeOTD_2_Name.Opacity = 0.8;
        }

        private void LoadImageFolder(string folder)
        {
            ErrorText.Visibility = Visibility.Collapsed;
            var sw = System.Diagnostics.Stopwatch.StartNew();
            if (!System.IO.Path.IsPathRooted(folder))
                folder = System.IO.Path.Combine(Environment.CurrentDirectory, folder);
            if (!System.IO.Directory.Exists(folder))
            {
                ErrorText.Text = "The specified folder does not exist: " + Environment.NewLine + folder;
                ErrorText.Visibility = Visibility.Visible;
                return;
            }
            Random r = new Random();
            var sources = from file in new System.IO.DirectoryInfo(folder).GetFiles().AsParallel()
                          where ValidImageExtensions.Contains(file.Extension, StringComparer.InvariantCultureIgnoreCase)
                          orderby r.Next()
                          select CreateImageSource(file.FullName, true);
            Images.Clear();
            Images.AddRange(sources);
            sw.Stop();
            Console.WriteLine("Total time to load {0} images: {1}ms", Images.Count, sw.ElapsedMilliseconds);
        }

        private ImageSource CreateImageSource(string file, bool forcePreLoad)
        {
            if (forcePreLoad)
            {
                var src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri(file, UriKind.Absolute);
                src.CacheOption = BitmapCacheOption.OnLoad;
                src.EndInit();
                src.Freeze();
                return src;
            }
            else
            {
                var src = new BitmapImage(new Uri(file, UriKind.Absolute));
                src.Freeze();
                return src;
            }
        }

        private void timerImageChange_Tick(object sender, EventArgs e)
        {
            PlaySlideShow();
        }

        private void PlaySlideShow()
        {
            try
            {
                if (Images.Count == 0)
                    return;
                var oldCtrlIndex = CurrentCtrlIndex;
                CurrentCtrlIndex = (CurrentCtrlIndex + 1) % 2;
                CurrentSourceIndex = (CurrentSourceIndex + 1) % Images.Count;

                Image imgFadeOut = ImageControls[oldCtrlIndex];
                Image imgFadeIn = ImageControls[CurrentCtrlIndex];
                ImageSource newSource = Images[CurrentSourceIndex];
                imgFadeIn.Source = newSource;

                TransitionType = TransitionEffects[EffectIndex].ToString();

                Storyboard StboardFadeOut = (Resources[string.Format("{0}Out", TransitionType.ToString())] as Storyboard).Clone();
                StboardFadeOut.Begin(imgFadeOut);
                Storyboard StboardFadeIn = Resources[string.Format("{0}In", TransitionType.ToString())] as Storyboard;
                StboardFadeIn.Begin(imgFadeIn);
            }
            catch (Exception) { }
        }
    }
}