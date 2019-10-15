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

namespace View
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        List<String> test;
		public MainWindow()
		{
			InitializeComponent();
            search_bar.text_search.TextChanged += Text_search_TextChanged;
            search_bar.text_search.LostFocus += Text_search_LostFocus;
            test = new List<string>();
            test.Add("Roman Levkovych");
		}

        private void Text_search_LostFocus(object sender, RoutedEventArgs e)
        {
            this.search.clear();
            this.search.Visibility = Visibility.Hidden;
        }

        private void Text_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox text = (TextBox)sender;
            if (text.Text.Length > 3 && !String.IsNullOrWhiteSpace(text.Text))
            {
                foreach(string i in test)
                {
                    if (i.StartsWith(text.Text))
                    {
                        if (this.search.Visibility == Visibility.Hidden)
                        {
                            this.search.Visibility = Visibility.Visible;
                        }
                        if (search.stack.Children.Count < 4)
                            search.addSearchItem(new Widget.SearchItem());
                    }
                }
            }
        }
    }
}
