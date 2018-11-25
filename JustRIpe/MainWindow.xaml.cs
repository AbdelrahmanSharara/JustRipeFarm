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

namespace JustRIpe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //verify the login using the database 
        private void LoginInit()
        {
            if (LoginAuth.VerifyLogin(Username_txt.Text, Password_txt.Password))
            {
                MessageBox.Show("Login successful!");
                MainEvent window = new MainEvent();
                window.Show();
                this.Close();
                    



            }
            else
            { MessageBox.Show("Incorrect details. Please try again."); }
        }

        //The close button
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
           Application.Current.Shutdown();
        }
        //The minimise button 
        private void MinimiseButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        //Draggable Window from the grid bar
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {


            LoginInit();
           
        }
        
        //Enter button can initialise the login procedure
        private void Password_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter)
                return;
                SignInButton_Click(sender, e);
        }

        
    }
}
