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
using Microsoft.Extensions.Logging;
using ViewModel;
using View.Widget;

namespace View
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window,INavigation
	{
        public UIElement curPage { get; set; } = null;

        public UIElement lastPage { get; set; } = null;

        Navbar navbar;
        public MainWindow()
		{
            navbar = new Navbar();
            ILogger logger = new Logger();
            logger.LogInformation("Test info");
            one();
			InitializeComponent();
            navbar.button_Profile.Click += Navbar_Button_Profile_Click;
            navbar.button_TimeTable.Click += Navbar_Button_TimeTable_Click;
            navbar.button_Notes.Click += Navbar_Button_Notes_Click;
            navbar.button_FAQ.Click += Navbar_Button_FAQ_Click;
            logInNavbar.button_FAQ.Click += Navbar_Button_FAQ_Click;
            logInNavbar.button_logIn.Click += LogInNavbar_Button_logIn_Click;
            logInNavbar.button_register.Click += LogInNavbar_Button_register_Click;
		}

        private void LogInNavbar_Button_register_Click(object sender, RoutedEventArgs e)
        {
            RegisterPage temp = new RegisterPage();
            temp.button_cancel.Click += RegisterPage_Button_cancel_Click;
            temp.button_Register.Click += LogInNavbar_Button_logIn_Click;
            navigateTo(temp);
        }

        private void RegisterPage_Button_cancel_Click(object sender, RoutedEventArgs e)
        {
            navigateBack();
        }

        private void LogInNavbar_Button_logIn_Click(object sender, RoutedEventArgs e)
        {
            Grid.SetColumn(navbar, 0);
            Grid.SetRow(navbar, 0);
            Grid.SetRowSpan(navbar, 2);
            grid.Children.Remove(logInNavbar);
            grid.Children.Add(navbar);
            navigateTo(new ProfilePage());
        }

        private void one()
        {
            ILogger logger = new Logger();
            using (logger.BeginScope("first level of logging"))
            {
                logger.LogInformation("info");
                using (logger.BeginScope("second level of logging"))
                {
                    logger.LogDebug("debug");
                }
            }
        }

        public void navigateTo(UIElement where)
        {
            Grid.SetColumn(where, 1);
            Grid.SetRow(where, 1);
            lastPage = curPage;
            if (curPage != null)
            {
                this.grid.Children.Remove(curPage);
            }
            this.grid.Children.Add(where);
            curPage = where;
        }

        public void navigateBack()
        {
            if (curPage != null)
            {
                this.grid.Children.Remove(curPage);
            }
            if (lastPage != null)
            {
                this.grid.Children.Add(lastPage);
            }
            curPage = lastPage;
        }

        public void openWindow(Window wind)
        {
            wind.Show();
        }


        private void Navbar_Button_FAQ_Click(object sender, RoutedEventArgs e)
        {
            navigateTo(new faq_page());
        }

        private void Navbar_Button_Notes_Click(object sender, RoutedEventArgs e)
        {
            NotesPage2 temp = new NotesPage2();
            temp.button_Add.MouseDown += NotesPage_Button_Add_MouseDown;  
            navigateTo(temp);
        }

        private void NotesPage_Button_Add_MouseDown(object sender, MouseButtonEventArgs e)
        {
            openWindow(new NoteItem2());
        }

        private void Navbar_Button_TimeTable_Click(object sender, RoutedEventArgs e)
        {
            navigateTo(new TimeTablePage());
        }

        private void Navbar_Button_Profile_Click(object sender, RoutedEventArgs e)
        {
            navigateTo(new ProfilePage());
        }
    }
}
