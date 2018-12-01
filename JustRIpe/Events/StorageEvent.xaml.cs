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
using System.Configuration;
using System.Data;

namespace JustRIpe
{
    /// <summary>
    /// Interaction logic for StorageEvent.xaml
    /// </summary>
    public partial class StorageEvent : UserControl
    {
        string connectionString = Properties.Settings.Default.DBAccess;
        public StorageEvent()
        {
            InitializeComponent(); //storageDataGrid.ItemsSource =
            FillStorageDataGrid();
        }

        private void Load_table_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FillStorageDataGrid()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                
                sqlCon.Open(); //establishing sql connection
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM Storage", sqlCon); //sql statement for storage main
                DataTable StorageDSet = new DataTable(); //defining storage dataset

                sqlData.Fill(StorageDSet); //filling storage database
                
                storageDataGrid.ItemsSource = StorageDSet.DefaultView;
            }

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open(); //establishing sql connection
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM Crops", sqlCon); //sql statement for storage main
                DataTable CropStock = new DataTable(); //defining crop stock dataset

                sqlData.Fill(CropStock); // filling crop stock

                cropsDataGrid.ItemsSource = CropStock.DefaultView;
            }

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open(); //establishing sql connection
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM Vehicles", sqlCon); //sql statement for storage main
                DataTable VehStock = new DataTable(); //defining veh stock dataset

                sqlData.Fill(VehStock); // filling crop stock

                vehiclesDataGrid.ItemsSource = VehStock.DefaultView;
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

        private void StorageDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
