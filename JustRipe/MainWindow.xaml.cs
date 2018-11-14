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

        private void LoginInit()
        {
          //  MessageBox.Show("un=" + Username_txt.Text + "**pwd=" + Password_txt.Password);
            if (LoginAuth.VerifyLogin(Username_txt.Text, Password_txt.Password))
            {
                MessageBox.Show("correct details");
                MainEvent window = new MainEvent();
                window.Show();
                this.Close();
                    


            }
            else
            { MessageBox.Show("incorrect details"); }
        }

        
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
           Application.Current.Shutdown();
        }

        private void MinimiseButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {

            LoginInit();
           

        }
    }
}
