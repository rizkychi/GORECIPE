using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Gocip.Controller
{
    class DataRecipeControl
    {
        private Model.DataRecipeModel RecipeModel;
        private Model.DataIngredientModel IngModel;
        private Model.KategoriModel CatModel;
        private View.DataRecipePage RecipeView;
        private View.DataRecipeInsert RecipeIns;

        public DataRecipeControl(View.DataRecipePage RecipeView)
        {
            RecipeModel = new Model.DataRecipeModel();
            this.RecipeView = RecipeView;
        }

        public DataRecipeControl(View.DataRecipeInsert RecipeIns)
        {
            RecipeModel = new Model.DataRecipeModel();
            IngModel = new Model.DataIngredientModel();
            CatModel = new Model.KategoriModel();
            this.RecipeIns = RecipeIns;
        }

        public void SelectRecipe()
        {
            DataSet ds = RecipeModel.SelectRecipe();
            RecipeView.dgRecipe.ItemsSource = ds.Tables[0].DefaultView;
        }

        public void SearchRecipe()
        {
            DataSet ds = RecipeModel.SearchRecipe(RecipeView.txtSearch.Text);
            RecipeView.dgRecipe.ItemsSource = ds.Tables[0].DefaultView;
        }

        public void Update(int id)
        {
            RecipeModel.ShowDetail(id);
            RecipeModel.SetRecipe_ID(id);
        }

        public bool InsertRecipe()
        {
            RecipeModel.SetRecipe_Name(RecipeIns.txtRecipeName.Text);
            RecipeModel.SetRecipe_Description(RecipeIns.mydesc.Content.ToString());
            RecipeModel.SetRecipe_Method(RecipeIns.mymethod.Content.ToString());
            RecipeModel.SetRecipe_Picture(RecipeIns.lblImgPath.Content.ToString());
            RecipeModel.SetRecipe_Video(RecipeIns.txtVideo.Text);

            return RecipeModel.InsertRecipe();
        }

        public bool UpdateRecipe()
        {
            RecipeModel.SetRecipe_Name(RecipeIns.txtRecipeName.Text);
            RecipeModel.SetRecipe_Description(RecipeIns.mydesc.Content.ToString());
            RecipeModel.SetRecipe_Method(RecipeIns.mymethod.Content.ToString());
            RecipeModel.SetRecipe_Picture(RecipeIns.lblImgPath.Content.ToString());
            if (RecipeIns.txtVideo.Text == "Masukkan link video" || RecipeIns.txtVideo.Text == "http://")
            {
                RecipeModel.SetRecipe_Video("");
            }
            else
            {
                RecipeModel.SetRecipe_Video(RecipeIns.txtVideo.Text);
            }

            return RecipeModel.UpdateRecipe(Int32.Parse(RecipeIns.txtRecipe_ID.Text));
        }

        public bool DeleteRecipe()
        {
            DataRow dr = ((System.Data.DataRowView)(RecipeView.dgRecipe.SelectedValue)).Row;
            RecipeModel.SetRecipe_ID((int)dr[0]);
            return RecipeModel.DeleteRecipe();
        }

        /* recipe insert */
        public void IngredientToCombobox()
        {
            DataSet ds = IngModel.SelectIngredient();

            RecipeIns.cmbBahan.ItemsSource = ds.Tables[0].DefaultView;
            RecipeIns.cmbBahan.SelectedValuePath = ds.Tables[0].Columns["id_ingredient"].ToString();
            RecipeIns.cmbBahan.DisplayMemberPath = ds.Tables[0].Columns["name"].ToString();

            RecipeIns.cmbPrice.ItemsSource = ds.Tables[0].DefaultView;
            RecipeIns.cmbPrice.SelectedValuePath = ds.Tables[0].Columns["id_ingredient"].ToString();
            RecipeIns.cmbPrice.DisplayMemberPath = ds.Tables[0].Columns["price"].ToString();

            RecipeIns.cmbUnit.ItemsSource = ds.Tables[0].DefaultView;
            RecipeIns.cmbUnit.SelectedValuePath = ds.Tables[0].Columns["id_ingredient"].ToString();
            RecipeIns.cmbUnit.DisplayMemberPath = ds.Tables[0].Columns["unit"].ToString();
        }

        public DataSet SelectIngredient()
        {
            return RecipeModel.GetDetailIngredient();
            //RecipeIns.dgBahan.ItemsSource = RecipeModel.GetDetailIngredient().Tables[0].DefaultView;
        }

        public bool InsertIngredient()
        {
            return RecipeModel.InsertIngredient((int)RecipeIns.cmbBahan.SelectedValue,
                                                RecipeIns.cmbBahan.Text, 
                                                RecipeIns.cmbSatuan.Text, 
                                                double.Parse(RecipeIns.txtJumlah.Text), 
                                                double.Parse(RecipeIns.cmbPrice.Text), 
                                                RecipeIns.cmbUnit.Text);
        }

        public bool DeleteIngredient()
        {
            return RecipeModel.DeleteIngredient(RecipeIns.dgBahan.SelectedIndex);
        }

        public void CategoryToCombobox()
        {
            DataSet ds = CatModel.SearchCategory(RecipeIns.cmbKategoriUtama.Text);

            RecipeIns.cmbKategori.ItemsSource = ds.Tables[0].DefaultView;
            RecipeIns.cmbKategori.SelectedValuePath = ds.Tables[0].Columns["id_category"].ToString();
            RecipeIns.cmbKategori.DisplayMemberPath = ds.Tables[0].Columns["name"].ToString();
        }

        public DataSet SelectCategory()
        {
            return RecipeModel.GetDetailCategory();
           // DataSet ds = RecipeModel.SelectCategory();

           // RecipeIns.dgKategori.ItemsSource = ds.Tables[0].DefaultView;
        }

        public bool InsertCategory()
        {
            return RecipeModel.InsertCategory((int)RecipeIns.cmbKategori.SelectedValue, RecipeIns.cmbKategori.Text, RecipeIns.cmbKategoriUtama.Text);
        }

        public bool DeleteCategory()
        {
            return RecipeModel.DeleteCategory(RecipeIns.dgKategori.SelectedIndex);
        }
    }
}
