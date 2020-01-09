using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Gocip.Controller
{
    class KategoriControl
    {
        private Model.KategoriModel CatModel;
        private View.DataKategoriPage CatView;

        public KategoriControl(View.DataKategoriPage CatView)
        {
            CatModel = new Model.KategoriModel();
            this.CatView = CatView;
        }

        public void SelectCategory()
        {
            DataSet ds = CatModel.SelectCategory();
            CatView.dgKategori.ItemsSource = ds.Tables[0].DefaultView;
        }
        public void SearchCategory()
        {
            DataSet ds = CatModel.SearchCategory(CatView.txtSearch.Text);
            CatView.dgKategori.ItemsSource = ds.Tables[0].DefaultView;
        }
        public bool InsertCategory()
        {
            CatModel.SetCategory_Name(CatView.txtCategoryName.Text);
            CatModel.SetCategory_Main(CatView.txtCategoryMain.Text);
            return CatModel.InsertCategory();
        }
        public bool UpdateCategory()
        {
            DataRow dr = ((System.Data.DataRowView)(CatView.dgKategori.SelectedValue)).Row;
            CatModel.SetCategory_ID((int)dr[0]);
            CatModel.SetCategory_Name(CatView.txtCategoryName.Text);
            CatModel.SetCategory_Main(CatView.txtCategoryMain.Text);
            return CatModel.UpdateCategory();
        }
        public bool DeleteCategory()
        {
            DataRow dr = ((System.Data.DataRowView)(CatView.dgKategori.SelectedValue)).Row;
            CatModel.SetCategory_ID((int)dr[0]);
            return CatModel.DeleteCategory();
        }
    }
}
