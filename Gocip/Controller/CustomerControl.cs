using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Media.Imaging;
using QRCoder;

namespace Gocip.Controller
{
    class CustomerControl
    {
        private View.CustRecipeDetail DetailView;
        private View.CustHomePage HomeView;
        private View.CustPopularPage PopView;
        private View.CustSearchRecipe SearchView;
        private View.CustCategoryPage CatView;
        private Model.DataRecipeModel RecipeModel;
        private Model.KategoriModel CatModel;

        public CustomerControl(View.CustRecipeDetail DetailView)
        {
            this.DetailView = DetailView;
            RecipeModel = new Model.DataRecipeModel();
        }

        public CustomerControl(View.CustHomePage HomeView)
        {
            this.HomeView = HomeView;
            RecipeModel = new Model.DataRecipeModel();
        }

        public CustomerControl(View.CustPopularPage PopView)
        {
            this.PopView = PopView;
            RecipeModel = new Model.DataRecipeModel();
        }

        public CustomerControl(View.CustSearchRecipe SearchView)
        {
            this.SearchView = SearchView;
            RecipeModel = new Model.DataRecipeModel();
        }

        public CustomerControl(View.CustCategoryPage CatView)
        {
            this.CatView = CatView;
            RecipeModel = new Model.DataRecipeModel();
            CatModel = new Model.KategoriModel();
        }

        public DataSet ShowLatestRecipe()
        {
            return RecipeModel.ShowLatestRecipe();
        }

        public DataSet ShowPopularRecipe()
        {
            return RecipeModel.ShowPopularRecipe();
        }

        public DataSet ShowSearchRecipe()
        {
            return RecipeModel.ShowSearchRecipe(SearchView.txtSearchBox.Text);
        }

        public void ShowRecipeOfTheDay()
        {
            try
            {
                DataSet ds = RecipeModel.ShowRecipeOfTheDay();
                DataRow dr = ds.Tables[0].Rows[0];

                if (ds.Tables[0].Rows.Count >= 2)
                {
                    HomeView.lblrotd1.Visibility = System.Windows.Visibility.Hidden;
                    HomeView.lblrotd2.Visibility = System.Windows.Visibility.Hidden;
                }
                else if (ds.Tables[0].Rows.Count == 1)
                {
                    HomeView.lblrotd1.Visibility = System.Windows.Visibility.Visible;
                    HomeView.lblrotd2.Visibility = System.Windows.Visibility.Hidden;
                }
                else
                {
                    HomeView.lblrotd1.Visibility = System.Windows.Visibility.Visible;
                    HomeView.lblrotd2.Visibility = System.Windows.Visibility.Visible;
                }

                BitmapImage bmp = new BitmapImage();
                var ImgPath = Environment.CurrentDirectory + "/" + dr["picture"].ToString();
                bmp.BeginInit();
                bmp.UriSource = new Uri(ImgPath);
                bmp.EndInit();

                HomeView.RecipeOTD_1.Source = bmp;
                HomeView.RecipeOTD_1_Name.Text = dr["name"].ToString();
                HomeView.RecipeOTD_1.Uid = dr["id_recipe"].ToString();

                dr = ds.Tables[0].Rows[1];

                bmp = new BitmapImage();
                ImgPath = Environment.CurrentDirectory + "/" + dr["picture"].ToString();
                bmp.BeginInit();
                bmp.UriSource = new Uri(ImgPath);
                bmp.EndInit();

                HomeView.RecipeOTD_2.Source = bmp;
                HomeView.RecipeOTD_2_Name.Text = dr["name"].ToString();
                HomeView.RecipeOTD_2.Uid = dr["id_recipe"].ToString();
            }
            catch (Exception)
            {
                
            }
        }

        public void SelectRecipe(int id)
        {
            DataSet ds = RecipeModel.SelectDetailRecipe(id);
            DataSet cat = RecipeModel.SelectDetailRecipe_Cat(id);
            DataSet ing = RecipeModel.SelectDetailRecipe_Ing(id);

            string ImgPath;
            BitmapImage bmp = new BitmapImage();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DetailView.txtMakanan.Text = dr["name"].ToString();
                DetailView.txtDeskripsi.Text = dr["description"].ToString();
                DetailView.lblKategori.Content = "";
                DetailView.lblTotal.Content = String.Format("Rp {0,0:# ### ###},-", dr["cost"]);
                DetailView.lblPoll.Content = "\u2764 " + dr["polling"];


                string text = "\u2022    ";
                text += dr["method"].ToString();
                text = text.Replace("\n", "\n\u2022    ");
                DetailView.txtCaraMasak.Text = text;

                string cats = "";
                int it = 0;
                foreach (DataRow category in cat.Tables[0].Rows)
                {
                    if (it != 0)
                    {
                        cats += ", ";
                    }
                    cats += category["name"].ToString();
                    it++;
                }

                DetailView.ListViewBahan.ItemsSource = ing.Tables[0].DefaultView;

                DetailView.lblKategori.Content = cats;
                //image
                ImgPath = Environment.CurrentDirectory + "/" + dr["picture"].ToString();
                bmp.BeginInit();
                bmp.UriSource = new Uri(ImgPath);
                bmp.EndInit();
                DetailView.imgMakanan.Source = bmp;
                //qrcode
                BitmapImage qr = new BitmapImage();
                if (dr["video"].ToString() != "")
                {
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(dr["video"].ToString(), QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    System.Drawing.Bitmap qrCodeImage = qrCode.GetGraphic(20);

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();  // no using here! BitmapImage will dispose the stream after loading
                    qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                    qr.BeginInit();
                    qr.CacheOption = BitmapCacheOption.OnLoad;
                    qr.StreamSource = ms;
                    qr.EndInit();
                    DetailView.imgQRCode.Source = qr;
                }

                DetailView.lblKetQR.Text += dr["name"];

                break;
            }
        }

        public DataSet SearchCategory(string text)
        {
            return CatModel.SearchCategory(text);
        }

        public DataSet ShowCategoryRecipe(int id)
        {
            return RecipeModel.ShowCategoryRecipe(id);
        }
    }
}
