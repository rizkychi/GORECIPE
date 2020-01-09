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
using QRCoder;


namespace Gocip.View
{
    /// <summary>
    /// Interaction logic for CustRecipeDetail.xaml
    /// </summary>
    public partial class CustRecipeDetail : Page
    {
        private Controller.CustomerControl CustControl;
        private Controller.DataPollingControl PollControl;

        public CustRecipeDetail(string id)
        {
            InitializeComponent();
            CustControl = new Controller.CustomerControl(this);
            PollControl = new Controller.DataPollingControl(this);
            PollControl.InsertPoll(Int32.Parse(id));
            CustControl.SelectRecipe(Int32.Parse(id));
        }
    }
}
