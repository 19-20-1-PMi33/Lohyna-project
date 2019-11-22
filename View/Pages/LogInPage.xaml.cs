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
using ViewModel;

namespace View.Pages
{
    /// <summary>
    /// Interaction logic for LogInPage.xaml
    /// </summary>
    public partial class LogInPage : Page
    {
        public LogInPage()
        {
            InitializeComponent();
            navbar.button_register.Click += LogInNavbar_Button_register_Click;
            navbar.button_login.Click += LogInNavbar_Buttom_login_Click;
            navbar.button_FAQ.Click += LogInNavbar_Button_FAQ_Click;
            searchBar.textSearch.KeyDown += SearchBar_TextSearch_KeyDown;
        }

        private void SearchBar_TextSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter&&!String.IsNullOrWhiteSpace(searchBar.textSearch.Text))
            {
                App.LastSearch = searchBar.textSearch.Text;
                this.NavigationService.Navigate(new Uri("Pages/SearchPage.xaml", UriKind.Relative));
            }
        }

        //we must write navigation in wpf app, because of system.windows.controls
        private void LogInNavbar_Buttom_login_Click(object sender, RoutedEventArgs e)
        {
            //add if (authorise)
            this.NavigationService.Navigate(new Uri("Pages/ProfilePage.xaml", UriKind.Relative));
        }

        private void LogInNavbar_Button_register_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/RegisterPage.xaml", UriKind.Relative));
        }
        private void LogInNavbar_Button_FAQ_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/FaqPageUnloged.xaml", UriKind.Relative));
        }

    }
}
