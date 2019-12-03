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
using ViewModel;
using DataServices.Services;
using DataServices;

namespace View.Pages
{
    /// <summary>
    /// Interaction logic for LogInPage.xaml
    /// </summary>
    public partial class LogInPage : Page
    {
        private Authorisation authorisation = new Authorisation(new SQLiteDataService());
        public LogInPage()
        {
            InitializeComponent();
            navbar.button_register.Click += LogInNavbar_Button_register_Click;
            navbar.button_login.Click += LogInNavbar_Buttom_login_Click;
            navbar.button_FAQ.Click += LogInNavbar_Button_FAQ_Click;
        }

        private void LogInNavbar_Buttom_login_Click(object sender, RoutedEventArgs e)
        {
            if (authorisation.IsCorrectPersonData(navbar.usernameTextBox.Text, navbar.passwordTextBox.Password))
            {
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
        private void LogInNavbar_Button_FAQ_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/FaqPageUnloged.xaml", UriKind.Relative));
        }

    }
}
