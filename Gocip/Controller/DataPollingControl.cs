using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gocip.Controller
{
    class DataPollingControl
    {
        private MainWindow LoginView;
        private View.CustRecipeDetail DetailView;
        private Model.DataPollingModel PollModel;

        public DataPollingControl(View.CustRecipeDetail DetailView)
        {
            this.DetailView = DetailView;
            PollModel = new Model.DataPollingModel();
        }

        public DataPollingControl(MainWindow LoginView)
        {
            this.LoginView = LoginView;
            PollModel = new Model.DataPollingModel();
        }

        public void SetPoll_Username(string uname)
        {
            PollModel.SetUsername(uname);
        }


        public bool InsertPoll(int id)
        {
            PollModel.SetRecipe_Id(id);

            return PollModel.InsertFeedback();
        }
    }
}
