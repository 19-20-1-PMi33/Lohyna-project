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
using View.Widget;

namespace View
{
    /// <summary>
    /// Interaction logic for search_page.xaml
    /// </summary>
    public partial class search_page : UserControl
    {
        List<SearchItem> items;
        public search_page()
        {
            items = new List<SearchItem>();
            for(int i = 0; i < 4; i++)
            {
                SearchItem temp = new SearchItem();
                temp.Height = 160;
                if (i % 2 == 1)
                {
                    temp.grid.Background = new SolidColorBrush(Colors.LightGray);
                }
                items.Add(temp);
            }
            InitializeComponent();
            items.ForEach(x => stack.Children.Add(x));
        }
    }
}
