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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace JustRIpe
{
    /// <summary>
    /// Interaction logic for TimetableEvent.xaml
    /// </summary>
    public partial class TimetableEvent : UserControl
    {
        public TimetableEvent()
        {
            InitializeComponent();
            FillEventDataGrid();
        }

        string connectionString = Properties.Settings.Default.DBAccess;

        private void FillEventDataGrid()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {

                sqlCon.Open(); //establishing sql connection
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM Events", sqlCon);
                    //("SELECT eventID, `Crops`.`cropName`, `Vehicles`.`vehicleName`, eventName, eventDescription, eventDate, eventTime FROM `Events` LEFT JOIN `Crops` ON `Events`.`cropID` = `Crops`.`cropsID`", sqlCon); //sql statement for event main
                DataTable TimetableDSet = new DataTable(); //defining storage dataset

                sqlData.Fill(TimetableDSet); //filling timetable database

                eventsDataGrid.ItemsSource = TimetableDSet.DefaultView;
            }

        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
        }
    }
}


