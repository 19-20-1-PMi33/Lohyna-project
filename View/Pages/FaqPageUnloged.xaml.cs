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
using DataServices;

namespace View.Pages
{
    /// <summary>
    /// Interaction logic for FaqPageUnloged.xaml
    /// </summary>
    public partial class FaqPageUnloged : Page
    {
        private readonly Authorisation authorisation = new Authorisation(new SQLiteDataService());
        public FaqPageUnloged()
        {
            InitializeComponent();
            navbar.button_register.Click += LogInNavbar_Button_register_Click;
            navbar.button_login.Click += LogInToApplicationNavigationTransition;
            navbar.button_FAQ.Click += LogInNavbar_Button_FAQ_Click;
            navbar.button_FAQ.Style = Application.Current.Resources["MenuButtonActive"] as Style;
        }

        private void LogInNavbar_Button_FAQ_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/FaqPageUnloged.xaml", UriKind.Relative));
        }

        private void LogInToApplicationNavigationTransition(object sender, RoutedEventArgs e)
        {
            if (authorisation.IsCorrectPersonData(navbar.usernameTextBox.Text, navbar.passwordTextBox.Password))
            {
                App.setUser(navbar.usernameTextBox.Text);
                this.NavigationService.Navigate(new Uri("Pages/ProfilePage.xaml", UriKind.Relative));
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("You don't have an account here. Register?",
                                            "Confirmation",
                                            MessageBoxButton.YesNoCancel,
                                            MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    this.NavigationService.Navigate(new Uri("Pages/RegisterPage.xaml", UriKind.Relative));
                }
            }
        }

        private void LogInNavbar_Button_register_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/RegisterPage.xaml", UriKind.Relative));
        }
    }
}
