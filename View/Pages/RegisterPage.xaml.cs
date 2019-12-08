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
            navbar.button_register.Click += LogInNavbar_Button_register_Click;
            navbar.button_login.Click += LogInNavbar_Buttom_login_Click;
            navbar.button_FAQ.Click += LogInNavbar_Button_FAQ_Click;
            content.button_cancel.Click += Content_Button_cancel_Click;
            content.button_upload_photo.Click += Content_Button_upload_photo_Click;
            content.button_Register.Click += Content_Button_Register_Click;
            navbar.button_register.Click += LogInRegisterNavigationTransition;
            navbar.button_login.Click += LogInToApplicationNavigationTransition;
            navbar.button_FAQ.Click += FAQNavigationTransition;
        }

        private bool validateValues()
        {
            return viewModel.validateValues(content.edit_Name.Text, content.edit_Surname.Text, content.edit_Zal.Text, content.edit_Username.Text, content.edit_Password.Password, content.edit_RepPassword.Password);
        }

        private void Content_Button_Register_Click(object sender, RoutedEventArgs e)
        {
            if (validateValues())
            {
                if(viewModel.registerUser(content.edit_Name.Text, content.edit_Surname.Text, content.edit_Zal.Text, content.edit_Username.Text, content.edit_Password.Password))
                {
                    this.NavigationService.Navigate(new Uri("Pages/ProfilePage.xaml", UriKind.Relative));
                }
            }
        }

        private void Content_Button_upload_photo_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(content.edit_Zal.Text))
            {
                OpenFileDialog imagePicker = new OpenFileDialog();
                imagePicker.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                imagePicker.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg";
                if (imagePicker.ShowDialog() == DialogResult.OK)
                {
                    BitmapImage tmpBitMap = new BitmapImage();
                    tmpBitMap.BeginInit();
                    tmpBitMap.CacheOption = BitmapCacheOption.OnLoad;
                    tmpBitMap.UriSource = new Uri("../../"+viewModel.copyImage(imagePicker.FileName, content.edit_Zal.Text),UriKind.RelativeOrAbsolute);
                    tmpBitMap.EndInit();
                    content.profile_photo.Source = tmpBitMap;
                }
            }
        }

        private void Content_Button_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void LogInNavbar_Button_FAQ_Click(object sender, RoutedEventArgs e)
        private void FAQNavigationTransition(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/FaqPageUnloged.xaml", UriKind.Relative));
        }

        private void LogInToApplicationNavigationTransition(object sender, RoutedEventArgs e)
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

        private void LogInRegisterNavigationTransition(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/RegisterPage.xaml", UriKind.Relative));
        }
    }
}
