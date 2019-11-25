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

namespace View.Pages
{
    /// <summary>
    /// Interaction logic for TimeTablePage.xaml
    /// </summary>
    public partial class TimeTablePage : Page
    {
        public TimeTablePage()
        {
            InitializeComponent();
            //navbar.button_Profile.Click += Navbar_Button_Profile_Click;
            //navbar.button_FAQ.Click += Navbar_Button_FAQ_Click;
            //navbar.button_Notes.Click += Navbar_Button_Notes_Click;
            //navbar.button_TimeTable.Click += Navbar_Button_TimeTable_Click;
            //navbar.button_TimeTable.Style = Application.Current.Resources["MenuButtonActive"] as Style;
        }

        //private void Navbar_Button_TimeTable_Click(object sender, RoutedEventArgs e)
        //{
        //    this.NavigationService.Navigate(new Uri("Pages/TimeTablePage.xaml", UriKind.Relative));
        //}

        //private void Navbar_Button_Notes_Click(object sender, RoutedEventArgs e)
        //{
        //    this.NavigationService.Navigate(new Uri("Pages/NotesPage.xaml", UriKind.Relative));
        //}

        //private void Navbar_Button_FAQ_Click(object sender, RoutedEventArgs e)
        //{
        //    this.NavigationService.Navigate(new Uri("Pages/FaqPageLoged.xaml", UriKind.Relative));
        //}

        //private void Navbar_Button_Profile_Click(object sender, RoutedEventArgs e)
        //{
        //    this.NavigationService.Navigate(new Uri("Pages/ProfilePage.xaml", UriKind.Relative));
        //}
    }
}
