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

namespace JustRIpe
{
    /// <summary>
    /// Interaction logic for UserEvent.xaml
    /// </summary>
    public partial class UserEvent : UserControl
    {
        public UserEvent()
        {
            InitializeComponent();
            UserlistGrid.ItemsSource = DatabaseStatements.GetUsers("SELECT username, phone, email, role FROM Users").Tables[0].DefaultView;

        }
    }
}
