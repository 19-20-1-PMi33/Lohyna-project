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
using System.Windows.Forms;
using ViewModel;
using DataServices;

namespace View.Pages
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        private RegisterPageVM viewModel;
        private RegisterPageVM logic;
        private readonly Authorisation authorisation = new Authorisation(new SQLiteDataService());
        public RegisterPage()
        {
            viewModel = new RegisterPageVM(new SQLiteDataService());
            InitializeComponent();
            navbar.button_register.Click += RegisterTransition;
            navbar.button_login.Click += ProfileTransition;
            navbar.button_FAQ.Click += FAQTransition;
            content.buttonCancel.Click += GoBack;
            content.buttonUploadPhoto.Click += UploadPhoto;
            content.buttonRegister.Click += Register;
        }

        private bool validateValues()
        {
            return viewModel.validateValues(content.editName.Text, content.editSurname.Text, content.editZal.Text, content.editUsername.Text, content.editPassword.Password, content.editRepPassword.Password);
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            if (validateValues())
            {
                if(viewModel.registerUser(content.editName.Text, content.editSurname.Text, content.editZal.Text, content.editUsername.Text, content.editPassword.Password))
                {
                    this.NavigationService.Navigate(new Uri("Pages/ProfilePage.xaml", UriKind.Relative));
                }
            }
        }

        private void UploadPhoto(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(content.editZal.Text))
            {
                OpenFileDialog imagePicker = new OpenFileDialog();
                imagePicker.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                imagePicker.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg";
                if (imagePicker.ShowDialog() == DialogResult.OK)
                {
                    BitmapImage tmpBitMap = new BitmapImage();
                    tmpBitMap.BeginInit();
                    tmpBitMap.CacheOption = BitmapCacheOption.OnLoad;
                    tmpBitMap.UriSource = new Uri("../../"+viewModel.copyImage(imagePicker.FileName, content.editZal.Text),UriKind.RelativeOrAbsolute);
                    tmpBitMap.EndInit();
                    content.profilePhoto.Source = tmpBitMap;
                }
            }
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void FAQTransition(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/FaqPageUnloged.xaml", UriKind.Relative));
        }

        private void ProfileTransition(object sender, RoutedEventArgs e)
        {
            if (authorisation.IsCorrectPersonData(navbar.usernameTextBox.Text, navbar.passwordTextBox.Password))
            {
                this.NavigationService.Navigate(new Uri("Pages/ProfilePage.xaml", UriKind.Relative));
            }
            else
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("You don't have an account here. Register?",
                                          "Confirmation",
                                          MessageBoxButton.YesNoCancel,
                                          MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    this.NavigationService.Navigate(new Uri("Pages/RegisterPage.xaml", UriKind.Relative));
                }
            }
        }

        private void RegisterTransition(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/RegisterPage.xaml", UriKind.Relative));
        }
    }
}
