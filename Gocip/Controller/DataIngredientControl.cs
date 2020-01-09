using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Gocip.Controller
{
    class DataIngredientControl
    {
        private View.DataIngredientPage IngView;
        private Model.DataIngredientModel IngModel;

        public DataIngredientControl(View.DataIngredientPage IngView)
        {
            IngModel = new Model.DataIngredientModel();
            this.IngView = IngView;
        }

        public string RemoveComma(string text)
        {
            string result = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '.')
                    break;
                result += text[i];
            }

            return result;
        }

        public void SelectIngredient()
        {
            DataSet ds = IngModel.SelectIngredient();
            IngView.dgBahan.ItemsSource = ds.Tables[0].DefaultView;
        }
        public void SearchIngredient()
        {
            DataSet ds = IngModel.SearchIngredient(IngView.txtSearch.Text);
            IngView.dgBahan.ItemsSource = ds.Tables[0].DefaultView;
        }
        public bool InsertIngredient()
        {
            IngModel.SetIngredient_Name(IngView.txtIngredientName.Text);
            IngModel.SetIngredient_Unit(IngView.txtUnit.Text);
            IngModel.SetIngredient_Price(double.Parse(RemoveComma(IngView.txtPrice.Text)));
            return IngModel.InsertIngredient();
        }
        public bool UpdateIngredient()
        {
            DataRow dr = ((System.Data.DataRowView)(IngView.dgBahan.SelectedValue)).Row;
            IngModel.SetIngredient_ID((int)dr[0]);
            IngModel.SetIngredient_Name(IngView.txtIngredientName.Text);
            IngModel.SetIngredient_Unit(IngView.txtUnit.Text);
            IngModel.SetIngredient_Price(double.Parse(RemoveComma(IngView.txtPrice.Text)));
            return IngModel.UpdateIngredient();
        }
        public bool DeleteIngredient()
        {
            DataRow dr = ((System.Data.DataRowView)(IngView.dgBahan.SelectedValue)).Row;
            IngModel.SetIngredient_ID((int)dr[0]);
            return IngModel.DeleteIngredient();
        }
    }
}
