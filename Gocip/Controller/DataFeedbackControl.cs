using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gocip.Controller
{
    class DataFeedbackControl
    {
        private View.CustRequestPage ReqView;
        private View.DataFeedbackPage FeedView;
        private Model.DataFeedbackModel ReqModel;

        public DataFeedbackControl(View.CustRequestPage ReqView)
        {
            this.ReqView = ReqView;
            ReqModel = new Model.DataFeedbackModel();
        }

        public DataFeedbackControl(View.DataFeedbackPage FeedView)
        {
            this.FeedView = FeedView;
            ReqModel = new Model.DataFeedbackModel();
        }

        public bool InsertFeedback(string text)
        {
            ReqModel.SetFeedback_Name(ReqView.txtNama.Text);
            ReqModel.SetFeedback_Phone(ReqView.txtPhone.Text);
            ReqModel.SetFeedback_Message(text);

            return ReqModel.InsertFeedback();
        }

        public void SelectFeedback()
        {
            System.Data.DataSet ds = ReqModel.SelectFeedback();

            FeedView.dgFeedBack.ItemsSource = ds.Tables[0].DefaultView;
        }

        public void SearchFeedback()
        {
            System.Data.DataSet ds = ReqModel.SearchFeedback(FeedView.txtSearch.Text);

            FeedView.dgFeedBack.ItemsSource = ds.Tables[0].DefaultView;
        }

        public bool DeleteFeedback()
        {
            System.Data.DataRow dr = ((System.Data.DataRowView)(FeedView.dgFeedBack.SelectedValue)).Row;
            ReqModel.SetFeedback_Id((int)dr[0]);
            return ReqModel.DeleteFeedback();
        }
    }
}
