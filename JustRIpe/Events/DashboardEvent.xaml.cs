using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Threading;

namespace JustRIpe
{
    /// <summary>
    /// Interaction logic for DashboardEvent.xaml
    /// </summary>
    public partial class DashboardEvent : UserControl
    {
        public DashboardEvent()
        {
            InitializeComponent();
            startClock();
        }

        private void startClock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += tickevent;
            timer.Start();

        }
        public void tickevent(object sender, EventArgs e)
        {
            Clocklbl.Content = DateTime.Now.ToString(@"hh\:mm");
        }
    }
}
