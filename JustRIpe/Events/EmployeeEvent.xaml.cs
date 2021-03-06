﻿using System;
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
    {   /// <summary>
        /// In the Employee usercontrol below is the statement that connects
        /// Name, Email, Phone, Role in to the datagrid in the App from the database
        /// written by Author : Abdelrahman Ahmed
        /// </summary>
        public EmployeeEvent()
        {
            InitializeComponent();
            employeelist.ItemsSource = DatabaseStatements.displayEmployees("SELECT firstname as 'First Name', lastname as 'Last Name', Email as 'E-Mail', phone as 'Phone Number', role as 'Role', status as 'Status' FROM Employees").Tables[0].DefaultView;
        }
    }
}
