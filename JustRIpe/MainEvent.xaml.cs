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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace JustRIpe
{
    /// <summary>
    /// Interaction logic for MainEvent.xaml
    /// </summary>
    public partial class MainEvent : Window
    {
        /// <summary>
        /// after initialise component the uername appears on the top of the window
        /// and then the switch case is used to display certain properities 
        /// depending if the user is an admin or not
        /// written by author : Abdelrahman Ahmed 
        /// </summary>
        public MainEvent()
        {
            
            InitializeComponent();
            UserView.Text =  LoginAuth.displayuser();
            switch (LoginAuth.permcheck())
            {
                case "admin":
                    Users.IsEnabled = true;
                    break;
                case "user":
                    Users.IsEnabled = false;
                    break;
                default:
                    break;

            }
        }

       
            private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Exitbt_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenMenu_Click(object sender, RoutedEventArgs e)
        {
            OpenMenu.Visibility = Visibility.Collapsed;
            CloseMenu.Visibility = Visibility.Visible;
        }

        private void CloseMenu_Click(object sender, RoutedEventArgs e)
        {
            OpenMenu.Visibility = Visibility.Visible;
            CloseMenu.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// The Following method is used to display all the usercontrol tabs
        /// in a list form using switch case that changes when the user click on a different
        /// usercontrol button.
        /// written by author : Abdelrahman Ahmed 
        /// ref: https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.selectionchangedeventargs?view=netframework-4.7.2
        /// using selection event changer with children to ass new tab and clear the previous one. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            UserControl tab = null;
            EventCenter.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {

                case "Dashboard":
                    tab = new DashboardEvent();
                    EventCenter.Children.Add(tab);
                    break;

                case "Storage":
                    tab = new StorageEvent();
                    EventCenter.Children.Add(tab);
                    break;

                case "Crops":
                    tab = new CropsEvent();
                    EventCenter.Children.Add(tab);
                    break;
                case "Delivery":
                    tab = new DeliveryEvent();
                    EventCenter.Children.Add(tab);
                    break;
                case "Timetable":
                    tab = new TimetableEvent();
                    EventCenter.Children.Add(tab);
                    break;
               case "Users":
                   tab = new UserEvent();
                   EventCenter.Children.Add(tab);
                   break;
                default:
                    break;

            }
        }

        private void Signoutbt_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();

        }
    }
}
   
