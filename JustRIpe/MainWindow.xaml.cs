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
using System.Windows.Threading;
using System.Text.RegularExpressions;



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
            ///this indicates that the loading bar is on but hidden
            /// written by author : Abdelrahman Ahmed
            progbar.IsIndeterminate = true;
            progbar.Opacity = 0;
        }

        /// <summary>
        /// this statement is used to Verify the username and password match with the database
        /// otherwise return the message of incorrect details.
        /// written by author : Abdelrahman Ahmed  
        /// </summary>
        private void LoginInit()
        {
            if (LoginAuth.VerifyLogin(Username_txt.Text, Password_txt.Password))
            {
                MainEvent window = new MainEvent();
                window.Show();
                this.Close();




            }
            else
            {
                progbar.Opacity = 0;
                MessageBox.Show("Incorrect details. Please try again.");
            }
        }

        /// <summary>
        /// this functionality is used for the designed close button in MainWindow.Xaml
        /// written by author : Abdelrahman Ahmed 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        /// <summary>
        /// this functionality is used for the designed Minimise button in MainWindow.Xaml
        /// written by author : Abdelrahman Ahmed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinimiseButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// The DragMove functionality is used to drag the window
        /// written by author : Abdelrahman Ahmed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch {
               
            }
        }

        /// <summary>
        /// the Sign-in button Click is used with async await to use the login bar animation
        /// and initialise the login
        /// written by author : Abdelrahman Ahmed 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SignInButton_Click(object sender, RoutedEventArgs e)
        {

            progbar.Opacity = 1;

            await Task.Delay(200);
            LoginInit();

        }

        /// <summary>
        /// the keydown is used in the password box for the user's convenience 
        /// to click enter rather than using the mouse for the login
        /// written by author : Abdelrahman Ahmed 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Password_txt_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key != Key.Enter)
                return;

            SignInButton_Click(sender, e);            

        }


        /// <summary>
        /// the keydown is used in the password box for the user's convenience 
        /// to click enter rather than using the mouse for the login
        /// written by author : Abdelrahman Ahmed 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Username_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)

                return;
            SignInButton_Click(sender, e);

        }

        /// <summary>
        /// the username text preview is used to check and block certain character
        /// using REGEX Regular Expressions
        /// written by author : Abdelrahman Ahmed
        /// ref: https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex?view=netframework-4.7.2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Username_txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regular = new Regex("['=]");
            e.Handled = regular.IsMatch(e.Text);
        }

        /// <summary>
        /// the password text preview is used to check and block certain character
        /// using REGEX Regular Expressions
        /// written by author : Abdelrahman Ahmed
        /// ref: https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex?view=netframework-4.7.2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Password_txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regular = new Regex("['=]");
            e.Handled = regular.IsMatch(e.Text);
        }
    }
}
