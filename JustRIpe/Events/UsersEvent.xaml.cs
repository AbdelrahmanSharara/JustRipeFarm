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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;


namespace JustRIpe
{
    /// <summary>
    /// Interaction logic for UsersEvent.xaml
    /// </summary>
    public partial class UsersEvent : UserControl
    {
        string connectionString = Properties.Settings.Default.DBAccess;
        public UsersEvent()
        {
            InitializeComponent(); //storageDataGrid.ItemsSource =
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {

                sqlCon.Open(); //establishing sql connection
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM Users", sqlCon); //sql statement
                DataTable UsersDSet = new DataTable(); //defining dataset

                sqlData.Fill(UsersDSet); //filling database
                usersDataGrid.ItemsSource = UsersDSet.DefaultView;
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