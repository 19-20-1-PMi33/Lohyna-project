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
using System.IO;

namespace View
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        Widget.RegisterPage regPage;
        Navbar nav;
        UIElement current_page;
		public MainWindow()
		{
			InitializeComponent();
            regPage = new Widget.RegisterPage();
            regPage.button_cancel.Click += ButtonCancelClicked;
            regPage.button_Register.Click += ButtonRegisterClicked;
            reg.but_reg.Click += registerNow_Clicked;
            log.but_log.Click += ButtonLogClicked;
            nav = new Navbar();
            current_page = reg;
		}
        protected void registerNow_Clicked(Object sender, RoutedEventArgs e)
        {
            grid.Children.Remove(current_page);
            Grid.SetRow(regPage, 1);
            Grid.SetColumn(regPage, 1);
            grid.Children.Add(regPage);
            current_page = regPage;
        }
        protected void ButtonCancelClicked(Object sender, RoutedEventArgs e)
        {
            grid.Children.Remove(current_page);
            current_page = reg;
            Grid.SetRow(reg, 1);
            Grid.SetColumn(reg, 1);
            grid.Children.Add(reg);
        }
        protected void ButtonLogClicked(Object sender, RoutedEventArgs e)
        {
            if (log.text_user.Text == "admin" && log.text_pass.Password == "12345")
            {
                grid.Children.Remove(log);
                grid.Children.Remove(current_page);
                current_page = null;
                Grid.SetRow(nav, 0);
                Grid.SetRowSpan(nav, 2);
                Grid.SetColumn(nav, 0);
                grid.Children.Add(nav);
            }
        }
        protected void ButtonRegisterClicked(Object sender, RoutedEventArgs e)
        {
            grid.Children.Remove(log);
            grid.Children.Remove(current_page);
            current_page = null;
            Grid.SetRow(nav, 0);
            Grid.SetRowSpan(nav, 2);
            Grid.SetColumn(nav, 0);
            grid.Children.Add(nav);
        }
    }
}
