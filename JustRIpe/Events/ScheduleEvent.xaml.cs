using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using JustRIpe.DB;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JustRIpe.Events
{
    /// <summary>
    /// Interaction logic for ScheduleEvent.xaml
    /// with datagrid for the sales
    /// written by author Abdelrahman Ahmed.
    /// </summary>
    public partial class ScheduleEvent : UserControl
    {
        public ScheduleEvent()
        {
            InitializeComponent();
            schedulegrid.ItemsSource = DatabaseStatements.displaySchdeule("SELECT name as 'Name', type as 'Fertisiler Type', quantity as 'Quantity', area as 'Area', date as 'Date', priority as 'Priority' FROM schedule").Tables[0].DefaultView;
        }
    }
}
