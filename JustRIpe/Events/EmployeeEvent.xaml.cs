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
    /// Interaction logic for EmployeeEvent.xaml
    /// </summary>
    public partial class EmployeeEvent : UserControl
    {
        public EmployeeEvent()
        {
            InitializeComponent();
            employeelist.ItemsSource = DatabaseStatements.displayEmployees("SELECT firstname, lastname, Email, phone, role FROM Employees").Tables[0].DefaultView;
        }
    }
}
