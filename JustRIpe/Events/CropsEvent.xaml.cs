﻿using System;
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
    /// <summary>
    /// Interaction logic for CropsEvent.xaml
    /// </summary>
    public partial class CropsEvent : UserControl
    {
        string connectionString = Properties.Settings.Default.DBAccess;

        public CropsEvent()
        {
            InitializeComponent();
            cropsDataGrid.Visibility = Visibility.Hidden;
            fertilisersPlanDataGrid.Visibility = Visibility.Hidden;
        }

        // Fills the data grid for displaying Crops currently in cultivation
        private void FillDataGridCrops()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT cropName FROM Crops WHERE currentStatus = 1", sqlCon);
                DataTable CropsDataSet = new DataTable();
                sqlData.Fill(CropsDataSet);
                cropsDataGrid.ItemsSource = CropsDataSet.DefaultView;
            }


        }
        // Fills the data grid for displaying
        private void FillDataGridFertilisersPlan()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT cropDestined, fertiliserName, ammountNeeded FROM Fertilisers", sqlCon);
                DataTable FertilisersDataSet = new DataTable();
                sqlData.Fill(FertilisersDataSet);
                fertilisersPlanDataGrid.ItemsSource = FertilisersDataSet.DefaultView;
            }


        }
        // Fills the data grid for displaying
        private void FillDataGridFertilisersStock()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT fertiliserName, stockNeeded FROM Fertilisers", sqlCon);
                DataTable FertilisersDataSet = new DataTable();
                sqlData.Fill(FertilisersDataSet);
                fertilisersPlanDataGrid.ItemsSource = FertilisersDataSet.DefaultView;
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
