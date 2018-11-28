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
        public MainEvent()
        {
            InitializeComponent();
         
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
                    tab = new UsersEvent();
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
   
