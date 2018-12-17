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
    /// Interaction logic for SalesEvent.xaml
    /// </summary>
    public partial class SalesEvent : UserControl
    {
        public SalesEvent()
        {

            InitializeComponent();
            salesgrid.ItemsSource = DatabaseStatements.displaysales("SELECT name as 'Name', email as 'Email', country as 'Country', type as 'Product', quantity as 'Quantity', weeks as 'Weekly Incrument' FROM Sales").Tables[0].DefaultView;

        }
    }
}
