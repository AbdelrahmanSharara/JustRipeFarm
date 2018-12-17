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
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace JustRIpe
{
    public partial class CropsEvent : UserControl
    {
        string connectionString = Properties.Settings.Default.DBAccess;

        public CropsEvent()
        {
            InitializeComponent();
            ButtonsVisibility();
            cropsDataGrid.Visibility = Visibility.Hidden;
            fertilisersPlanDataGrid.Visibility = Visibility.Hidden;
        }

        // Display crops currently in cultivation
        private void FillDataGridCrops()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT cropName FROM Crops WHERE currentStatus = 1", sqlCon);
                DataTable CropsDataSet = new DataTable();
                sqlData.Fill(CropsDataSet); //CROPS DATA SET
                cropsDataGrid.ItemsSource = CropsDataSet.DefaultView;
            }
        }

        //Method for filling the fertilisers data grid
        private void FillDataGridFertilisersGeneral(string sqlStatement)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter(sqlStatement, sqlCon);
                DataTable FertilisersDataSet = new DataTable();
                sqlData.Fill(FertilisersDataSet); //FERTILISERS DATA SET
                fertilisersPlanDataGrid.ItemsSource = FertilisersDataSet.DefaultView;
            }
        }

        // Display fertilisers plan
        private void FillDataGridFertilisersPlan()
        {
            string sqlStatement = "SELECT cropDestined, fertiliserName, ammountNeeded FROM Fertilisers";
            FillDataGridFertilisersGeneral(sqlStatement);
        }

        // Display fertilisers stock
        private void FillDataGridFertilisersStock()
        {
            string sqlStatement = "SELECT fertiliserName, stockNeeded FROM Fertilisers";
            FillDataGridFertilisersGeneral(sqlStatement);
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

        //Displaying buttons accordingly to user's role
        private void ButtonsVisibility()
        {
            //Getting the logged in user's role (admin or user)
            string currentRole = LoginAuth.displayRole();

            //admin = Manager Role
            if (currentRole == "admin")
            {
                //Display all buttons
                Button_Crops_Cultivation.Visibility = Visibility.Visible;
                Button_Fertiliser_Plan.Visibility = Visibility.Visible;
                Button_Fertiliser_Stock.Visibility = Visibility.Visible;
            }
            //user = Labourer Role
            if (currentRole == "user")
            {
                //Display only one button, "Fertiliser Plan"
                Button_Crops_Cultivation.Visibility = Visibility.Hidden;
                Button_Fertiliser_Plan.Visibility = Visibility.Visible;
                Button_Fertiliser_Stock.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        // Button for Crops current in cultivation
        {
            fertilisersPlanDataGrid.Visibility = Visibility.Hidden;
            cropsDataGrid.Visibility = Visibility.Visible;
            FillDataGridCrops();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        // Button for amount and type fertiliser needed
        {
            cropsDataGrid.Visibility = Visibility.Hidden;
            fertilisersPlanDataGrid.Visibility = Visibility.Visible;
            FillDataGridFertilisersPlan();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        // Button for feritiliser stock
        {
            cropsDataGrid.Visibility = Visibility.Hidden;
            fertilisersPlanDataGrid.Visibility = Visibility.Visible;
            FillDataGridFertilisersStock();
        }
    }
}
