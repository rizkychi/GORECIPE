using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gocip.Controller
{
    class MainControl
    {
        private Model.MainModel MainModel;
        private Model.DataRecipeModel RecipeModel;
        private View.HomePage MainView;

        public MainControl(View.HomePage MainView)
        {
            this.MainView = MainView;
            MainModel = new Model.MainModel();
            RecipeModel = new Model.DataRecipeModel();
        }

        public void SelectAll()
        {
            MainView.lblCat_Number.Content = MainModel.TotalCategory();
            MainView.lblFeed_Number.Content = MainModel.TotalFeed();
            MainView.lblIng_Number.Content = MainModel.TotalIngredient();
            MainView.lblRecipe_Number.Content = MainModel.TotalRecipe();
            MainView.lblUser_Number.Content = MainModel.TotalUser();
            MainView.lblViews_Number.Content = MainModel.TotalView();

            System.Data.DataSet ds = MainModel.SelectFavRecipe();
            MainView.lblFavRecipe_Number.Content = ds.Tables[0].Rows[0]["polling"].ToString();
            MainView.lblFavRecipe_Name.Content = ds.Tables[0].Rows[0]["name"].ToString();

            ds = MainModel.SelectExpensiveRecipe();
            MainView.lblMostExpensive_Number.Content = ds.Tables[0].Rows[0]["cost"].ToString();
            MainView.lblMostExpensive_Name.Content = ds.Tables[0].Rows[0]["name"].ToString();

            SelectROTD();
            RecipeToCMB();
        }

        public void SelectROTD()
        {
            System.Data.DataSet ds = MainModel.SelectROTD();

            MainView.dgROTD.ItemsSource = ds.Tables[0].DefaultView;
        }

        public void RecipeToCMB()
        {
            System.Data.DataSet ds = RecipeModel.SelectRecipe();

            MainView.cmbROTD.ItemsSource = ds.Tables[0].DefaultView;
            MainView.cmbROTD.SelectedValuePath = ds.Tables[0].Columns["id_recipe"].ToString();
            MainView.cmbROTD.DisplayMemberPath = ds.Tables[0].Columns["name"].ToString();
        }

        public bool InsertROTD()
        {
            return MainModel.InsertROTD((int)MainView.cmbROTD.SelectedValue);
        }

        public bool DeleteROID()
        {
            System.Data.DataRow dr = ((System.Data.DataRowView)(MainView.dgROTD.SelectedValue)).Row;
            return MainModel.DeleteROTD((int)dr[0]);
        }
    }
}
